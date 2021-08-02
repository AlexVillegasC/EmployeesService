using Employee.Domain;
using Properties.Data;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Connecting and Setting up the Database Context");


            if (!context.Database.CanConnect())
            {
                Console.WriteLine($"On the Solution Explorer, please open the EmployeeContext.cs and setup your own DB Server connstring");
                Console.ReadKey();
                context.Database.EnsureCreated();
                GetEmployees("Before Add:");
                AddEmployee();
                GetEmployees("After Add:");
                Console.ReadKey();
            }
        }

        private static EmployeeContext context = new EmployeeContext();

        private static void GetEmployees(string text)
        {
            var employees = context.Employees.ToList();
            Console.WriteLine($"{text}: Employees count is {employees.Count}");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FirstName);
            }
        }

        private static void AddEmployee()
        {
            var employee1 = new Employees { FirstName = "Alex", RecordState = State.Active };
            var employee2 = new Employees { FirstName = "Bagheera", RecordState = State.Active };
            var employee3 = new Employees { FirstName = "Sam", RecordState = State.Deleted };
            context.Employees.Add(employee1);
            context.Employees.Add(employee2);
            context.Employees.Add(employee3);
            context.SaveChanges();
        }
    }
}
