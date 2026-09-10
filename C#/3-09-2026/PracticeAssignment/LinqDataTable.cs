using System.Data;

namespace PracticeAssignment;

public class LinqDataTable
{
    public static void LinqDataTableMain()
    {
        DataTable studentTable = new DataTable("Students");

        studentTable.Columns.Add("StudentID", typeof(int));
        studentTable.Columns.Add("StudentName", typeof(string));
        studentTable.Columns.Add("Age", typeof(int));

        studentTable.Rows.Add(1, "Krish", 20);
        studentTable.Rows.Add(2, "Raj", 20);
        studentTable.Rows.Add(1, "Jay", 15);
        studentTable.Rows.Add(2, "Preet", 13);
        studentTable.Rows.Add(1, "Jill", 17);
        studentTable.Rows.Add(2, "Meet", 18);
        studentTable.Rows.Add(1, "Kartaviya", 25);
        studentTable.Rows.Add(2, "Lalit", 26);
        studentTable.Rows.Add(1, "Tom", 30);
        studentTable.Rows.Add(2, "Jerry", 9);

        foreach(DataRow row in studentTable.Rows)
        {
            Console.WriteLine("ID : "+row["StudentID"]+" Name : "+row["StudentName"]+" Age : "+row["Age"]);
        }

        var result = from row in studentTable.AsEnumerable() where row.Field<int>("Age") > 15 select row;

        foreach(DataRow row in result)
        {
            Console.WriteLine(
                "ID : "+row.Field<int>("StudentID")+" Name : "+row.Field<string>("StudentName")+" Age : "+row.Field<int>("Age")
            );
        }
    }
}
