using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using ManteHos.Entities;
using ManteHos.Persistence;


namespace ManteHos.Services
{
    public class ManteHosService : IManteHosService
    {
        private readonly IDAL dal;
        private Employee currentUser;
        private Incident currentIncident;

        public ManteHosService(IDAL dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Borra todos los datos de la BD
        /// </summary>
        public void RemoveAllData()
        {
            dal.RemoveAllData();
        }

        /// <summary>
        /// Salva todos los cambios que haya habido en el contexto de la aplicación desde la última vez que se hizo Commit
        /// </summary>
        /// 

        public void login(string ID, string password)
        {
            if (string.IsNullOrWhiteSpace(ID) || string.IsNullOrWhiteSpace(password))
                throw new LoginException("ID o contraseña vacíos");

            Employee emp = dal.GetById<Employee>(ID);

            if (emp == null)
                throw new LoginException("ID no existe");

            if (emp.Password != password)
                throw new LoginException("Contraseña incorrecta");

            // LOGIN EXITOSO
            currentUser = emp;
        }

        /// </summary>
        public void Commit()
        {
            dal.Commit();
        }

        /// <summary>
        /// Inicializa los datos para que haya ciertos datos para poder usarlos luego
        /// </summary>
        public void DBInitialization()
        {
            RemoveAllData();

            // Dar de alta ciertos datos relevantes para el sistema
            Head head = new Head("Ibañez", "h1", "h1");
            AddPerson(head);
            Master tfmotu = new Master("Bárcenas", "m1", "m1");
            AddPerson(tfmotu);
            Master master2 = new Master("He-Man", "m2", "m2");
            AddPerson(master2);
            Master master3 = new Master("Picasso", "m3", "m3");
            AddPerson(master3);
            Operator op1 = new Operator("Pepe Gotera", "o1", "o1", Shift.Morning);
            AddPerson(op1);
            Operator op2 = new Operator("Otilio", "o2", "o2", Shift.Morning);
            AddPerson(op2);
            Operator op3 = new Operator("Rompetechos", "o3", "o3", Shift.Night);
            AddPerson(op3);

            Employee empleado1 = new Employee("Sacarino", "e1", "e1");
            AddPerson(empleado1);
            Employee empleado2 = new Employee("Pepe García", "e2", "e2");
            AddPerson(empleado2);

            Area a1 = new Area("Mecánica", tfmotu);
            AddArea(a1);
            Area a2 = new Area("Electricidad", master2);
            AddArea(a2);
            Area a3 = new Area("Pintura", master3);
            AddArea(a3);

            Part p1 = new Part("Esc50", 5, "Placa de escayola para techo", 1, "Placa de 50x30cms", 5);
            AddPart(p1);
            Part p2 = new Part("TM8", 3000, "Tornillo métrica 8", 100, "Tornillo", 0.01F);
            AddPart(p2);
            Part p3 = new Part("ClimaEst", 4, "Cristal Climalit de ventana estándar", 0, "Cristal 75x100cms", 200);
            AddPart(p3);


            


        }

        public void AddPerson(Employee person)
        {
            // Restricción: No puede haber dos personas con el mismo Id
            if (dal.GetById<Employee>(person.Id) == null)
            {
                dal.Insert<Employee>(person);
                dal.Commit();
            }
            else throw new ServiceException("Person with Id " + person.Id + " already exists.");
        }

        public void AddArea(Area area)
        {
            // Restricción: No puede haber dos áreas con el mismo Nombre
            if (!dal.GetWhere<Area>(x => x.Name == area.Name).Any())
            {
                dal.Insert<Area>(area);
                dal.Commit();
            }
            else throw new ServiceException("Area with Name " + area.Name + " already exists.");
        }

        public void AddPart(Part part)
        {
            // Restricción: No puede haber dos piezas con la misma descripción
            if (!dal.GetWhere<Part>(x => x.Description == part.Description).Any())
            {
                dal.Insert<Part>(part);
                dal.Commit();
            }
            else throw new ServiceException("Part with Description " + part.Description + " already exists.");
        }

        //
        // Resto de metodos necesarios para el servicio
        //
        public Employee userLogued()
        {
            return currentUser;
        }

        
        public void setCurrentUser(Employee e)
        {
            currentUser = e;
        }

        public void logOut()
        {
            currentUser = null;
        }

        public void AddIncident(Incident incident)
        {
            if (incident.Equals(dal.GetById<Incident>(incident.Id))) throw new IncidentException("Incident with ID " + incident.Id + "already exists.");

            dal.Insert(incident);
            dal.Commit();
        }

        public void AddIncident(string department, string description, DateTime reportDate,
            Employee reporter, Priority priority = Priority.Low, Status status = Status.Created)
        {
            /*
            if(!dal.GetWhere<Incident>(x => x.Department == department).Any())
            {
                throw new IncidentException("No existe un departamento con nombre: " + department + ".");
            }
            */
            Incident i = new Incident(department, description, reportDate, reporter, priority, status);

            AddIncident(i);
        }

        public List<Incident>getAllPendingIncidents()
        {
            Employee e = userLogued();

            if (e is Head)
            {

                List<Incident> list = dal.GetWhere<Incident>(i => i.Status == Status.Created).ToList();

                return list;

            }
            throw new IncidentException("Don't have the enough permissions");

        }

        public List<Area> getAreaList()
        {
            List<Area> areaList = new List<Area>(dal.GetAll<Area>());
            return areaList;
        }

        
        

        public void acceptedIncident(Incident incident, Area area, Priority priority)
        {
            if (area == null)
                throw new ServiceException("Area does not exists");

            incident.acceptIncident(priority, area);
            dal.Commit();
        }

        

        public void rejectedIncident(Incident incident, String reason)
        {
            incident.rejectIncident(reason);
            dal.Commit();
        }

        public Area findAreaByName(string name)
        {
            Area a1 = dal.GetById<Area>(name);
            return a1;
        }


        public IList<Incident> getAllAcceptedIncidents()
        {
            Employee user = userLogued();

            if (!(user is Master))
                throw new ServiceException("Don't have the enough permissions");

            Master master = (Master)user;

            // Get accepted incidents from the master's area
            List<Incident> incidents = dal.GetWhere<Incident>(
                i => i.Area.Id == master.Area.Id && i.Status == Status.Accepted
            ).ToList();

            return incidents;
        }


        public IList<Incident> AssignOperatorToWorkOrder()
        {
            Employee user = userLogued();

            if (!(user is Master))
                throw new ServiceException("Don't have the enough permissions");

            Master m = (Master)user;
            Area a = m.Area;



            List<Incident> incList = a.notCompletedIncidents();
            return incList;

            //    throw new WorkOrderException("Incidence not found");


            //    if (incident.Area.Id != master.Area.Id)
            //        throw new WorkOrderException("La incidencia no pertenece al área del maestro");


            //    WorkOrder workOrder = incident.WorkOrder;
            //    if (workOrder == null)
            //    {
            //        if (!confirmation)
            //            throw new WorkOrderException("La incidencia no tiene orden de trabajo. ¿Desea crear una?");

            //        workOrder = new WorkOrder(DateTime.Now, incident);
            //        dal.Insert(workOrder);
            //        incident.WorkOrder = workOrder;
            //    }

            //    if (workOrder.Operators.Any(op => op.Id == operatorId))
            //        throw new WorkOrderException("Operator already asigned.");


            //    workOrder.Operators.Add(operatorToAssign);
            //    operatorToAssign.WorkOrders.Add(workOrder);

            //    dal.Commit();
            //}
        }

        public List<Operator> asignedOperators(Incident i)
        {
            WorkOrder wo = i.WorkOrder;
            if (wo == null)
            {
                throw new ServiceException("No hay orden de trabajo asociada");
            }
            List<Operator> list = new List<Operator>(wo.Operators);
            return list;
        }
        public String incidentDescription(Incident i)
        {
            String d = i.Description;
            return d;
        }
        public List<Operator> availableOperators(Incident i)
        {
            List<Operator> list = new List<Operator>(dal.GetAll<Operator>());
            return list;
        }
        public void addOperator(WorkOrder wo, Operator op)
        {
            if (wo.Operators.Count == 0)
            {
                wo.AddOperator(op);
            }
            if (wo.Operators.FirstOrDefault().Shift != op.Shift)
            {
                throw new InvalidOperationException("El operario que quiere asignar tiene un turno distinto al que está asignado");
            }
            wo.AddOperator(op);
        }
        public void createWorkOrder(Incident i)
        {
            i.AddWorkOrder();
        }

        public List<WorkOrder> getOrdersFromOperator()
        {
            Employee user = userLogued();

            if(!(user is Operator)) { throw new ServiceException("Don't have enough permissions"); }

            Operator op = (Operator)user;

            List<WorkOrder> notFinishedWorkOrders = op.WorkOrders.Where(wo => wo.EndDate == null).ToList();

            return notFinishedWorkOrders;

        }

        public void closeOrder(String reason, Incident incident)
        {
            incident.WorkOrder.stablishRepairReport(reason);
            dal.Commit();
        }
        public void quitarOperator(Operator op, WorkOrder wo)
        {
            wo.removeOp(op);
        }
        public void asignarIncidente(Incident i)
        {
            currentIncident = i;
        }
        public Incident getCurrentIncident()
        {
            return currentIncident;
        }
        public void CreateWorkOrderForCurrentIncident()
        {
            if (currentIncident == null) throw new InvalidOperationException("No hay incidente seleccionado");
            if (currentIncident.WorkOrder != null) return;

            currentIncident.WorkOrder = new WorkOrder();

            dal.Commit();
        }

        public void AssignEndDateForWorkOrder(WorkOrder workOrder, DateTime endDate)
        {
            workOrder.EndDate = endDate;
        }

        public void stablishRepairReportForWorkOrder(WorkOrder workOrder, String reason)
        {
            workOrder.stablishRepairReport(reason);
        }
    }

}
