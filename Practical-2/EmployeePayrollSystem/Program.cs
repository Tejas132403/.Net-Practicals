using System;

namespace EmployeePayrollSystem
{
    // Interface
    interface ISalary
    {
        void CalculateSalary();
    }

    // Base Class
    class Employee
    {
        protected int empId;
        protected string empName;

        public Employee(int id, string name)
        {
            empId = id;
            empName = name;
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine("Employee ID : " + empId);
            Console.WriteLine("Employee Name : " + empName);
        }
    }

    // Derived Class
    class FullTimeEmployee : Employee, ISalary
    {
        private double basicSalary;
        private double bonus;
        private double totalSalary;

        public FullTimeEmployee(int id, string name, double basicSalary, double bonus)
            : base(id, name)
        {
            this.basicSalary = basicSalary;
            this.bonus = bonus;
        }

        public void CalculateSalary()
        {
            totalSalary = basicSalary + bonus;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();

            Console.WriteLine("Basic Salary : " + basicSalary);
            Console.WriteLine("Bonus : " + bonus);
            Console.WriteLine("Total Salary : " + totalSalary);
            Console.WriteLine("====================================");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FullTimeEmployee emp1 = new FullTimeEmployee(122,"Tejas Andodariya",5000000,5000000);

            FullTimeEmployee emp2 = new FullTimeEmployee(1, "KING", 60000, 9000);


            emp1.CalculateSalary();
            emp2.CalculateSalary();

            Console.WriteLine("===== Employee Payroll Details =====");

            emp1.DisplayDetails();
            emp2.DisplayDetails();

            

            Console.ReadKey();
        }
    }
}