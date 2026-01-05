using System;
using System.Data.Entity.Validation;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ManteHos.Entities;
using ManteHos.Persistence;
using System.Net;
using System.Reflection.Emit;
using System.Xml.Linq;
using System.Data.Entity;

namespace DBTest
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                new Program();
            }
            catch (Exception e)
            {
                printError(e);
            }
            Console.WriteLine("\nPulse una tecla para salir");
            Console.ReadLine();
        }

        static void printError(Exception e)
        {
            while (e != null)
            {
                if (e is DbEntityValidationException)
                {
                    DbEntityValidationException dbe = (DbEntityValidationException)e;

                    foreach (var eve in dbe.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
                e = e.InnerException;
            }
        }


        Program()
        {
            IDAL dal = new EntityFrameworkDAL(new ManteHosDbContext());

            CreateSampleDB(dal);
            PrintSampleDB(dal);
        }


        private void CreateSampleDB(IDAL dal)
        {
            dal.RemoveAllData();

            Console.WriteLine("CREANDO LOS DATOS Y ALMACENANDOLOS EN LA BD");
            Console.WriteLine("===========================================");

            Console.WriteLine("\n// CREACIÓN DE PERSONAS");
            //public Course(string descr, string name)

            Head head = new Head("Ibañez", "h1", "h1");
            dal.Insert<Head>(head);
            dal.Commit();

            Master tfmotu = new Master("Bárcenas", "m1", "m1");
            dal.Insert<Master>(tfmotu);
            dal.Commit();

            Master master2 = new Master("He-Man", "m2", "m2");
            dal.Insert<Master>(master2);
            dal.Commit();

            Operator op1 = new Operator("Pepe Gotera", "o1", "o1", Shift.Morning);
            dal.Insert<Operator>(op1);
            dal.Commit();

            Employee empleado1 = new Employee("Sacarino", "e2", "e2");
            dal.Insert<Employee>(empleado1);
            dal.Commit();

            //
            // Populate here the rest of the database
            //
            dal.Delete<Master>(tfmotu);
            dal.Commit();

            dal.Delete<Head>(head);
            dal.Commit();

            Head h1 = new Head("Juan Palomo", "h1", "h1");
            dal.Insert<Head>(h1);
            dal.Commit();

            Master master1 = new Master("Chelo", "m1", "m1");
            dal.Insert<Master>(master1);
            dal.Commit();

            Area a1 = new Area("Reparaciones", master2);
            dal.Insert<Area>(a1);
            dal.Commit();

            Area a2 = new Area("Informática", master1);
            dal.Insert<Area>(a2);
            dal.Commit();

            Employee e1 = new Employee("Toud", "e1", "e1");
            dal.Insert<Employee>(e1);
            dal.Commit();

            dal.Delete<Employee>(empleado1);
            dal.Commit();

            Part p1 = new Part("41037", 35, "Tornillo", 10, "ud", 1);
            dal.Insert<Part>(p1);
            dal.Commit();
            Part p2 = new Part("850", 9, "Teclado", 4, "ud", 30);
            dal.Insert<Part>(p2);
            dal.Commit();

            Incident i1 = new Incident("Reparaciones", "Se ha roto una puerta", DateTime.Today, e1, Priority.Medium);
            dal.Insert<Incident>(i1);
            dal.Commit();
            Incident i2 = new Incident("Contabilidad", "Hay dos teclados que no funcionan correctamente", DateTime.UtcNow, e1,  Priority.High);
            dal.Insert<Incident>(i2);
            dal.Commit();

            WorkOrder o1 = new WorkOrder(DateTime.Now, i2);
            o1.AddOperator(op1);
            o1.AddUsedPart(2, p2);
            dal.Insert<WorkOrder>(o1);
            dal.Commit();

            UsedPart up1 = new UsedPart(2, p2);
            dal.Insert<UsedPart>(up1);
            dal.Commit();


            
            Incident i4 = new Incident("Informática", "string description", DateTime.Now.Date , e1, Priority.Low, Status.Accepted);
            
            dal.Insert<Incident>(i4);
            dal.Commit();
            i4.acceptIncident(Priority.Medium, a2);
            dal.Commit();

            // caso para cerrar orden de trabajo
            Incident i5 = new Incident("Informática", "Ordenador roto", DateTime.Now.AddDays(-3).Date, e1);
            dal.Insert<Incident>(i5);
            dal.Commit();
            i5.acceptIncident(Priority.High, a2);
            dal.Commit();
            WorkOrder o3 = new WorkOrder(DateTime.Now.AddDays(-2).Date, i5);
            o3.AddOperator(op1);
            o3.AddUsedPart(2, p2);
            dal.Insert<WorkOrder>(o3);
            dal.Commit();


        }

        // Copiar a partir de aquí
        private void PrintSampleDB(IDAL dal)
        {
            Console.WriteLine("\n\nMOSTRANDO LOS DATOS DE LA BD");
            Console.WriteLine("============================\n");

            Console.WriteLine("\nPersonas creadas:");
            foreach (Employee p in dal.GetAll<Employee>())
                Console.WriteLine("   FullName: " + p.FullName + " Id: " + p.Id + " Password: " + p.Password);

            // Show the rest of the database
            Console.WriteLine("\nPiezas creadas:");
            foreach (Part p in dal.GetAll<Part>())
                Console.WriteLine("   Code: " + p.Code + " Description: " + p.Description + " CurrentQuantity: " + p.CurrentQuantity);

            Console.WriteLine("\nÁreas, Indicencias, Órdenes de trabajo y piezas pedidas creadas:");
            foreach (Area a in dal.GetAll<Area>())
            {
                Console.WriteLine("   Name: " + a.Name);
                foreach (Incident i in a.Incidents)
                {
                    Console.WriteLine("      Incident Id: " + i.Id + " ReportDate: " + i.ReportDate + " Description: " + i.Description);
                    WorkOrder o = i.WorkOrder;
                    if (o != null)
                    {
                        Console.WriteLine("          WorkOrder Id: " + o.Id + " StartDate: " + o.StartDate);
                        foreach (UsedPart up in o.UsedParts)
                        {
                            Console.WriteLine("             Part Description: " + up.Part.Description + " Quantity: " + up.Quantity);
                        }
                    }

                }
            }


        }

    }

}

