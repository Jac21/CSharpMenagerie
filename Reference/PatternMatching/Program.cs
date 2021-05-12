using System;

namespace PatternMatching
{
    public class Program
    {
        public static void Main()
        {
            // Constant Patterns - comparing a field to a constant value
            var employee = new Employee
            {
                Id = 1,
                Name = "Jeremy Cantu",
                Age = 27
            };

            if (employee.Age is 27)
            {
                Console.WriteLine($"{employee.Name} has an age of zero");
            }

            // Null Patterns  
            var employeeWithNull = new Employee
            {
                Id = 1,
                Age = 30
            };

            if (employeeWithNull.Name is null)
            {
                Console.WriteLine($"The employee with Id: {employeeWithNull.Id} has a name that is null");
            }

            ////Negated Patterns  
            //var employeeWithoutNull = new Employee() {Id = 1, Name = "John Doe", Age = 30};

            //if (employeeWithoutNull.Name is not null)
            //Console.WriteLine($"{employeeWithoutNull.Name} name is not null");

            // Type Patterns  
            var employeeType = new Employee
            {
                Id = 1,
                Name = "Jeremy Cantu",
                Age = 30
            };

            if (employeeType is { } emp)
            {
                Console.WriteLine($" Employee name is {emp.Name}");
            }

            // Property Patterns
            if (employee is { Age: 30 })
            {
                Console.WriteLine($" Employe age is {employee.Age}");
            }

            //if (employee is { Age:  >25 })
            //    Console.WriteLine($" Employee age: {employee.Age} is greater than 25");

            Console.ReadKey();
        }
    }
}