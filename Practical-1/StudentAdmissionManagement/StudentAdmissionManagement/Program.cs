using System;

namespace StudentAdmissionManagement
{
    class Student
    {
        private int id;
        private string name;
        private string course;
        private double fees;

        public Student(int id, string name, string course, double fees)
        {
            this.id = id;
            this.name = name;
            this.course = course;
            this.fees = fees;
        }

        public void DisplayDetails()
        {
            Console.WriteLine("------ Student Admission Details ------");
            Console.WriteLine("Student ID : " + id);
            Console.WriteLine("Student Name : " + name);
            Console.WriteLine("Course : " + course);
            Console.WriteLine("Fees : " + fees);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student(122, "Tejas Andodariya", "Computer Engineering", 85000);
            Student s2 = new Student(123, "King of Universe", " Engineering", 75000);

            s1.DisplayDetails();
            s2.DisplayDetails();

            Console.ReadKey();
        }
    }
}