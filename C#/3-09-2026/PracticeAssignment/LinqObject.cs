namespace PracticeAssignment;

public class LinqObject
{
    public static void LinqObjectMain()
    {
        List<int> numbers = new List<int>
        {
            10,20,30,40,50,10,19,21
        };

        // var result = numbers.Where(n=> n>10);

        List<int> result = new List<int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] > 20)
            {
                result.Add(numbers[i]);
            }
        }

        foreach (int number in result)
        {
            Console.WriteLine(number);
        }
    }

    public static void LinqObjectMainSquer()
    {
        List<int> numbers = new List<int>
        {
            10,20,30,40,50,10,19,21
        };

        // var result = numbers.Select(n=> n * n);

        List<int> result = new List<int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] > 20)
            {
                result.Add(numbers[i] * numbers[i]);
            }
        }

        foreach (int number in result)
        {
            Console.WriteLine(number);
        }
    }

    public static void LinqObjectSortMain()
    {
        List<int> numbers = new List<int>
        {
            10,20,30,40,50,10,19,21
        };

        // var result = numbers.OrderBy(n=> n);

        var result = numbers.OrderByDescending(n => n);

        foreach (int number in result)
        {
            Console.WriteLine(number);
        }
    }

    // Student class
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }

    // Custom method to check teenager
    public static bool IsTeenAger(Student stud)
    {
        return stud.Age > 12 && stud.Age < 20;
    }

    public static void LinqObjectStudentMain()
    {
        // 1. STUDENT COLLECTION
        IList<Student> studentList = new List<Student>()
    {
        new Student() {StudentID = 1 , StudentName = "Krish" , Age = 20},
        new Student() {StudentID = 2 , StudentName = "Meet" , Age = 13},
        new Student() {StudentID = 3 , StudentName = "Smit" , Age = 21},
        new Student() {StudentID = 4 , StudentName = "Jerry" , Age = 9},
        new Student() {StudentID = 5 , StudentName = "Tom" , Age = 10},
        new Student() {StudentID = 6 , StudentName = "Maulic" , Age = 30},
        new Student() {StudentID = 7 , StudentName = "Raj" , Age = 23},
        new Student() {StudentID = 8 , StudentName = "Jeel" , Age = 22},
        new Student() {StudentID = 9 , StudentName = "Preet" , Age = 18},
        new Student() {StudentID = 10 , StudentName = "Kartaviya" , Age = 17},
    };


        // 2. BASIC SELECT

        var filteredResult =
            from s in studentList
            select s;

        Console.WriteLine("ALL STUDENTS");

        foreach (Student std in filteredResult)
        {
            Console.WriteLine(
                "ID: " + std.StudentID +
                " Name: " + std.StudentName +
                " Age: " + std.Age
            );
        }


        // 3. WHERE

        filteredResult =
            from s in studentList
            where s.Age > 12 && s.Age <= 18
            select s;

        Console.WriteLine("\nAGE BETWEEN 13 AND 18");

        foreach (Student std in filteredResult)
        {
            Console.WriteLine(
                "ID: " + std.StudentID +
                " Name: " + std.StudentName +
                " Age: " + std.Age
            );
        }


        // 4. FUNC / DELEGATE

        Func<Student, bool> isTeenAger = delegate (Student s)
        {
            return s.Age > 12 && s.Age < 19;
        };

        filteredResult =
            from s in studentList
            where isTeenAger(s)
            select s;

        Console.WriteLine("\nUSING FUNC / DELEGATE");

        foreach (Student std in filteredResult)
        {
            Console.WriteLine(
                "ID: " + std.StudentID +
                " Name: " + std.StudentName +
                " Age: " + std.Age
            );
        }


        // 5. CUSTOM METHOD

        filteredResult =
            from s in studentList
            where IsTeenAger(s)
            select s;

        Console.WriteLine("\n USING CUSTOM METHOD ");

        foreach (Student std in filteredResult)
        {
            Console.WriteLine(
                "ID: " + std.StudentID +
                " Name: " + std.StudentName +
                " Age: " + std.Age
            );
        }


        // 6. LAMBDA EXPRESSION + WHERE

        filteredResult =
            studentList.Where(s => s.Age > 12 && s.Age < 20);

        Console.WriteLine("\n USING LAMBDA + WHERE");

        foreach (Student std in filteredResult)
        {
            Console.WriteLine(
                "ID: " + std.StudentID +
                " Name: " + std.StudentName +
                " Age: " + std.Age
            );
        }


        // 7. ORDER BY

        filteredResult =
            from s in studentList
            orderby s.Age descending, s.StudentName
            select s;

        Console.WriteLine("\n ORDER BY AGE DESCENDING ");

        foreach (Student std in filteredResult)
        {
            Console.WriteLine(
                "ID: " + std.StudentID +
                " Name: " + std.StudentName +
                " Age: " + std.Age
            );
        }


        // 8. FIRST OR DEFAULT

        Student stdFirst =
            (from s in studentList
             where s.Age > 12 && s.Age < 20
             select s).FirstOrDefault();

        Console.WriteLine("\n FIRST OR DEFAULT ");

        if (stdFirst != null)
        {
            Console.WriteLine(
                "ID: " + stdFirst.StudentID +
                " Name: " + stdFirst.StudentName +
                " Age: " + stdFirst.Age
            );
        }


        // 9. LAST OR DEFAULT

        Student stdLast =
            (from s in studentList
             where s.Age > 12 && s.Age < 20
             select s).LastOrDefault();

        Console.WriteLine("\n===== LAST OR DEFAULT =====");

        if (stdLast != null)
        {
            Console.WriteLine(
                "ID: " + stdLast.StudentID +
                " Name: " + stdLast.StudentName +
                " Age: " + stdLast.Age
            );
        }


        // 10. SINGLE OR DEFAULT

        Student stdSingle =
            (from s in studentList
             where s.Age == 12
             select s).SingleOrDefault();

        Console.WriteLine("\n===== SINGLE OR DEFAULT =====");

        if (stdSingle != null)
        {
            Console.WriteLine(
                "ID: " + stdSingle.StudentID +
                " Name: " + stdSingle.StudentName +
                " Age: " + stdSingle.Age
            );
        }
        else
        {
            Console.WriteLine("No student found.");
        }


        // 11. ORDER BY DESCENDING + THEN BY

        var orderedResult =
            studentList
            .OrderByDescending(s => s.Age)
            .ThenBy(s => s.StudentName);

        Console.WriteLine("\n===== ORDER BY DESCENDING + THEN BY =====");

        foreach (Student std in orderedResult)
        {
            Console.WriteLine(
                "ID: " + std.StudentID +
                " Name: " + std.StudentName +
                " Age: " + std.Age
            );
        }


        // 12. GROUP BY AGE

        var groupedResult =
            from s in studentList
            group s by s.Age;

        Console.WriteLine("\nGROUP BY AGE ");

        foreach (var ageGroup in groupedResult)
        {
            Console.WriteLine("\nAge Group: " + ageGroup.Key);

            Console.WriteLine(
                "Maximum Student ID: " +
                ageGroup.Max(s => s.StudentID)
            );

            Console.WriteLine(
                "Number of Students: " +
                ageGroup.Count()
            );

            foreach (Student std in ageGroup)
            {
                Console.WriteLine(
                    "ID: " + std.StudentID +
                    " Name: " + std.StudentName +
                    " Age: " + std.Age
                );
            }
        }


        // 13. AGGREGATE FUNCTIONS

        Console.WriteLine("\nAGGREGATE FUNCTIONS");

        Console.WriteLine(
            "Sum of Ages: " +
            studentList.Sum(s => s.Age)
        );

        Console.WriteLine(
            "Maximum Age: " +
            studentList.Max(s => s.Age)
        );

        Console.WriteLine(
            "Minimum Age: " +
            studentList.Min(s => s.Age)
        );

        Console.WriteLine(
            "Average Age: " +
            studentList.Average(s => s.Age)
        );
    }
}