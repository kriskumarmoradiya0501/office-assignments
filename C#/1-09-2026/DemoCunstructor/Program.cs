// See https://aka.ms/new-console-template for more information
namespace Program1
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Marks { get; set; }


        // Static Constructor
        static Student()
        {
            Console.WriteLine("Welcome to Student Management System!");
        }


        // Default Constructor
        public Student()
        {
            ID = 0;
            Name = "Unknown";
            Marks = 0;
        }


        // Parameterized Constructor
        public Student(int id, string name, double marks)
        {
            ID = id;
            Name = name;
            Marks = marks;
        }


        // Copy Constructor
        public Student(Student student)
        {
            ID = student.ID;
            Name = student.Name;
            Marks = student.Marks;
        }


        // Private Constructor
        private Student(int id, string name, double marks, bool privateCreation)
        {
            ID = id;
            Name = name;
            Marks = marks;
        }


        // Static Method to create Student
        public static Student CreateStudent(int id, string name, double marks)
        {
            return new Student(id, name, marks, true);
        }


        // Display Student Details
        public void DisplayDetails()
        {
            Console.WriteLine($"ID     : {ID}");
            Console.WriteLine($"Name   : {Name}");
            Console.WriteLine($"Marks  : {Marks}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Default Constructor
            Console.WriteLine("DEFAULT CONSTRUCTOR");

            Student s1 = new Student();

            s1.DisplayDetails();


            // 2. Parameterized Constructor
            Console.WriteLine("\nPARAMETERIZED CONSTRUCTOR");

            Student s2 = new Student(101, "Rahul", 85.5);

            s2.DisplayDetails();


            // 3. Copy Constructor
            Console.WriteLine("\n COPY CONSTRUCTOR ");

            Student s3 = new Student(s2);

            s3.DisplayDetails();


            // 4. Private Constructor using Static Method
            Console.WriteLine("\nPRIVATE CONSTRUCTOR");

            Student s4 = Student.CreateStudent(102, "Amit", 90);

            s4.DisplayDetails();
        }
    }

}