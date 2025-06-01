using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_4_OperatorOverloading
{
    internal class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public static double Premium { get; set; }
        public int WorkExperience { get; set; }
        public string Position { get; set; } // Added Position property
        public int OverdueOrder { get; set; } // Added OverdueOrder property


        public Employee(string name, string position, int age, double salary, int workExperince, int overdueOrder)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Premium = 0; // Default value for Premium
            WorkExperience = workExperince; // Default value for WorkExperience
            Position = position; // Initialize Position
            OverdueOrder = overdueOrder;

        }



        public static Employee operator +(Employee emp1, Employee emp2)
        {
            if (emp1.WorkExperience >= 0 && emp1.WorkExperience <= 1)
            {
                return new Employee
                    (
                        emp1.Name,
                        emp1.Position,
                        emp1.Age,
                        emp1.Salary + (emp2.Salary * 0 / 100),
                        emp1.WorkExperience,
                        emp1.OverdueOrder
                    );
            }
            else if (emp1.WorkExperience > 1 && emp1.WorkExperience <= 2)
            {
                return new Employee
                    (
                        emp1.Name,
                        emp1.Position,
                        emp1.Age,
                        emp1.Salary + (emp2.Salary * 10 / 100),
                        emp1.WorkExperience,
                        emp1.OverdueOrder
                    );
            }
            else if (emp1.WorkExperience > 2 && emp1.WorkExperience <= 5)
            {
                return new Employee
                    (
                        emp1.Name,
                        emp1.Position,
                        emp1.Age,
                        emp1.Salary + (emp2.Salary * 20 / 100),
                        emp1.WorkExperience,
                        emp1.OverdueOrder
                    );
            }
            else if (emp1.WorkExperience > 5 && emp1.WorkExperience <= 10)
            {
                return new Employee
                    (
                        emp1.Name,
                        emp1.Position,
                        emp1.Age,
                        emp1.Salary + (emp2.Salary * 30 / 100),
                        emp1.WorkExperience,
                        emp1.OverdueOrder
                    );
            }
            else
            {
                return new Employee
                    (
                        emp1.Name,
                        emp1.Position,
                        emp1.Age,
                        emp1.Salary + (emp2.Salary * 40 / 100),
                        emp1.WorkExperience,
                        emp1.OverdueOrder
                    );
            }
        } // Overloaded operator for adding premium based on work experience
        public static Employee operator -(Employee emp1, Employee emp2)
        {
            if (emp1.OverdueOrder == 0)
            {
                return new Employee
               (
                   emp1.Name,
                   emp1.Position,
                   emp1.Age,
                   emp1.Salary - (emp2.Salary * 0 / 100),
                   emp1.WorkExperience,
                   emp1.OverdueOrder
               );
            }
            else if (emp1.OverdueOrder == 1)
            {
                return new Employee
                (
                    emp1.Name,
                    emp1.Position,
                    emp1.Age,
                    emp1.Salary - (emp2.Salary * 10 / 100),
                    emp1.WorkExperience,
                    emp1.OverdueOrder
                );
            }
            else if (emp1.OverdueOrder == 2)
            {
                return new Employee
                (
                    emp1.Name,
                    emp1.Position,
                    emp1.Age,
                    emp1.Salary - (emp2.Salary * 20 / 100),
                    emp1.WorkExperience,
                    emp1.OverdueOrder
                );
            }
            else
            {
                return new Employee
                (
                    emp1.Name,
                    emp1.Position,
                    emp1.Age,
                    emp1.Salary - (emp2.Salary * (emp1.OverdueOrder * 10) / 100),
                    emp1.WorkExperience,
                    emp1.OverdueOrder

                );
            }

        } // Overloaded operator for subtracting overdue orders from salary
        public static bool operator >(Employee emp1, Employee emp2)
        {
            return emp1.Salary > emp2.Salary;
        } // Overloaded operator for comparing salaries
        public static bool operator <(Employee emp1, Employee emp2)
        {
            return emp1.Salary < emp2.Salary;
        } // Overloaded operator for comparing salaries
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            return (emp1.Salary == emp2.Salary);
        } // Overloaded operator for checking equality of salaries
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return emp1.Salary != emp2.Salary;
        } // Overloaded operator for checking inequality of salaries


        public void DisplayInfo()

        {
            Employee Employee = new(Name, Position, Age, Salary, WorkExperience, OverdueOrder); // Create a new Employee object to use the overloaded operator
            Employee Employee1 = Employee + Employee; // Use the overloaded operator to calculate the new salary with premium
            Employee Employee2 = Employee1 - Employee; // Use the overloaded operator to calculate the new salary with overdue orders

            int premium = (int)(Employee1.Salary - Employee.Salary); // Calculate the premium amount
            int fine = (int)(Employee2.Salary - Employee1.Salary); // Calculate the overdue order fine

            Console.WriteLine($"Name: {Employee1.Name}, Position: {Employee1.Position}\n" +
                $"Age: {Employee1.Age}\n" +
                $"Overdue Orders: {Employee2.OverdueOrder}\n" +
                $"Salary: {Employee.Salary} Premium: {premium} Fine: {fine} Total: {Employee2.Salary}\n" +
                $"Work Experience: {WorkExperience} years");
            
            if (Employee == Employee2 && Employee2.OverdueOrder == 0)
            {
                Console.WriteLine($"This work is good.\n");
            }
            else if (Employee2 > Employee)
            {
                Console.WriteLine($"This work is good.\n");
            }
            else if (Employee2 < Employee1)
            {
                Console.WriteLine($"This work is bad.\n");
            }
            else
            {
                Console.WriteLine($"This work is average.\n");
            }
            Console.WriteLine("----------------------------------\n");
        }
    }

    internal class Accountant : Employee
    {
        public new string Name { get; set; }
        public new int Age { get; set; }
        public new double Salary { get; set; }
        public static new double Premium { get; set; }
        public new int WorkExperience { get; set; }
        public new string Position { get; set; } // Added Position property
        public new int OverdueOrder { get; set; } // Added OverdueOrder property


        public Accountant(string name, string position, int age, double salary, int workExperince, int overdueOrder) : base(name, position, age, salary, workExperince, overdueOrder)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Premium = 0; // Default value for Premium
            WorkExperience = workExperince; // Default value for WorkExperience
            Position = position; // Initialize Position
            OverdueOrder = overdueOrder;
        }


    }

    internal class Manager : Employee
    {
        public new string Name { get; set; }
        public new int Age { get; set; }
        public new double Salary { get; set; }
        public static new double Premium { get; set; }
        public new int WorkExperience { get; set; }
        public new string Position { get; set; } // Added Position property
        public new int OverdueOrder { get; set; } // Added OverdueOrder property
        public Manager(string name, string position, int age, double salary, int workExperince, int overdueOrder) : base(name, position, age, salary, workExperince, overdueOrder)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Premium = 0; // Default value for Premium
            WorkExperience = workExperince; // Default value for WorkExperience
            Position = position; // Initialize Position
            OverdueOrder = overdueOrder;
        }
    }

    internal class Developer : Employee
    {
        public new string Name { get; set; }
        public new int Age { get; set; }
        public new double Salary { get; set; }
        public static new double Premium { get; set; }
        public new int WorkExperience { get; set; }
        public new string Position { get; set; } // Added Position property
        public new int OverdueOrder { get; set; } // Added OverdueOrder property
        public Developer(string name, string position, int age, double salary, int workExperince, int overdueOrder) : base(name, position, age, salary, workExperince, overdueOrder)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Premium = 0; // Default value for Premium
            WorkExperience = workExperince; // Default value for WorkExperience
            Position = position; // Initialize Position
            OverdueOrder = overdueOrder;
        }
    }


} // End of namespace HomeWork_4_OperatorOverloading






