using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManteHos.Entities;


namespace ManteHos.Services
{
    public interface IManteHosService
    {
        void RemoveAllData();
        void Commit();

        // Necesario para la inicialización de la BD
        void DBInitialization();

        //
        // A partir de aquí los necesarios para los CU solicitados
        //
        Employee userLogued();
        void login(String ID, String password);
        void setCurrentUser(Employee e);
        void logOut();
        void AddIncident(Incident incident);
        void AddIncident(string department, string description, DateTime reportDate,
            Employee reporter, Priority priority = Priority.Low, Status status = Status.Created);
        List<Incident> getAllPendingIncidents();
        List<Area> getAreaList();
        void acceptedIncident(Incident incident, Area area, Priority priority);
        void rejectedIncident(Incident incident, String reason);
        Area findAreaByName(string name);
        IList<Incident> getAllAcceptedIncidents();
        IList<Incident> AssignOperatorToWorkOrder();
        List<Operator> asignedOperators(Incident i);
        String incidentDescription(Incident i);
        List<Operator> availableOperators(Incident i);
        void addOperator(WorkOrder wo, Operator op);
        List<WorkOrder> getOrdersFromOperator();
        void closeOrder(String reason, Incident incident);
        void createWorkOrder(Incident i);

        void asignarIncidente(Incident i);

        Incident getCurrentIncident();
        void CreateWorkOrderForCurrentIncident();

        void quitarOperator(Operator op, WorkOrder wo);

        void AssignEndDateForWorkOrder(WorkOrder workOrder, DateTime endDate);
        void stablishRepairReportForWorkOrder(WorkOrder workOrder, String reason);




    }
}
