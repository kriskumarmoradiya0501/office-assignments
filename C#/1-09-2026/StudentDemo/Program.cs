// See https://aka.ms/new-console-template for more information

namespace Program1
{
    public class Student
    {
        // Static field
        private static int totalStudents = 0;

        // Properties
        public string Name { get; set; }
        public int Age { get; set; }

        private char grade;

        public char Grade
        {
            get
            {
                return grade;
            }

            set
            {
                if (value != 'A' && value != 'B' && value != 'C')
                {
                    throw new Exception("Invalid Grade! Grade must be A, B, or C.");
                }

                grade = value;
            }
        }

        // Constructor
        public Student(string name, int age, char grade)
        {
            Name = name;
            Age = age;
            Grade = grade;

            totalStudents++;
        }

        // Method to display information
        public void DisplayInformation()
        {
            Console.WriteLine("Name : " + Name);
            Console.WriteLine("Age  : " + Age);
            Console.WriteLine("Grade: " + Grade);
            Console.WriteLine("Total Students : " + totalStudents);
            Console.WriteLine("");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student s1 = new Student("Rahul", 20, 'A');
                Student s2 = new Student("Amit", 21, 'B');
                Student s3 = new Student("Raj", 19, 'C');

                s1.DisplayInformation();
                s2.DisplayInformation();
                s3.DisplayInformation();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

}