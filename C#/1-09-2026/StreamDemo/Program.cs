// using System;
// using System.IO;

// namespace FileWriting_SW
// {
//     class FileWrite
//     {
//         public void WriteData()
//         {
//             FileStream fs = new FileStream("d:\\text.txt", FileMode.Append, FileAccess.Write);
//             StreamWriter sw = new StreamWriter(fs);

//             Console.WriteLine("Enter first text:");
//             string str1 = Console.ReadLine();
//             sw.WriteLine(str1);

//             // Flush ensures this line is written immediately
//             sw.Flush();
//             Console.WriteLine("Flushed: First line saved, but stream still open.");

//             Console.WriteLine("Enter second text:");
//             string str2 = Console.ReadLine();
//             sw.WriteLine(str2); // still works because stream is open

//             // Now close
//             sw.Close();
//             fs.Close();
//             Console.WriteLine("Closed: Stream disposed, cannot write anymore.");

//             // If you try this, it will throw an error:
//             // sw.WriteLine("This will fail after Close");
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             FileWrite wr = new FileWrite();
//             wr.WriteData();
//         }
//     }
// }


// using System;
// using System.IO;

// namespace FileReading_SR
// {
//     class FileRead
//     {
//         public void ReadData()
//         {
//             // Open file for reading
//             FileStream fs = new FileStream("d:\\text.txt", FileMode.Open, FileAccess.Read);
//             StreamReader sr = new StreamReader(fs);

//             Console.WriteLine("Program to show content of test file");

//             // Move to beginning of stream
//             sr.BaseStream.Seek(0, SeekOrigin.Begin);

//             // Read line by line
//             string str = sr.ReadLine();
//             while (str != null)
//             {
//                 Console.WriteLine(str);
//                 str = sr.ReadLine();
//             }

//             // Pause so user can see output
//             Console.ReadLine();

//             // Close reader and stream
//             sr.Close();
//             fs.Close();
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             FileRead fr = new FileRead();
//             fr.ReadData();
//         }
//     }
// }

using System;
using System.IO;

namespace FileReading_SR
{
    class FileRead
    {
        public void ReadSecondLine()
        {
            // Open file for reading
            FileStream fs = new FileStream("d:\\text.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            Console.WriteLine("Program to show only the second line of test file");

            // Skip the first line
            string firstLine = sr.ReadLine();

            // Read the second line
            string secondLine = sr.ReadLine();

            if (secondLine != null)
                Console.WriteLine("Second line: " + secondLine);
            else
                Console.WriteLine("File does not have a second line.");

            sr.Close();
            fs.Close();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FileRead fr = new FileRead();
            fr.ReadSecondLine();
        }
    }
}
