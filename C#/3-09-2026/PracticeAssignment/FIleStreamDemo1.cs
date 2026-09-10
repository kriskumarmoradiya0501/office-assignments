using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeAssignment
{
    public class FIleStreamDemo1
    {
        public static void FIleStreamDemo1Main()
        {
            Console.WriteLine("Enter Your choose : ");

            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    FileStream fs = new FileStream(@"D:\office\C#\3-09-2026\FileStreamTest.txt", FileMode.Append, FileAccess.Write);

                    StreamWriter sw = new StreamWriter(fs);
                    Console.WriteLine("Press 2 for creating file : "+
                    "Press 3 For Writing in file : "+
                    "Press 4 For read content from file"+
                    "Press 5 "
                    );
                    Console.WriteLine("Enter text what you want to add in file : ");

                    string str = Console.ReadLine();

                    sw.WriteLine(str);

                    sw.Flush();

                    sw.Close();

                    fs.Close();
                break;
                case 2 :
                    string path = @"D:\office\C#\3-09-2026\FileStreamTest.txt";
                    File.WriteAllText(path,"Hello Bhai from WriteAllText ");
                    Console.WriteLine("File Created Succesfully");
                break;
                case 3:
                    using(StreamWriter writer = new StreamWriter(@"D:\office\C#\3-09-2026\FileStreamTest.txt"))
                    {
                        writer.WriteLine("Line 1 ");
                        writer.WriteLine("Line 2 ");
                    }
                    Console.WriteLine("Data Writtenm to file.");
                break;
                case 4:
                    using(StreamReader reader = new StreamReader(@"D:\office\C#\3-09-2026\FileStreamTest.txt"))
                    {
                        string content = reader.ReadToEnd();
                        Console.WriteLine("File Content : ");
                        Console.WriteLine(content);
                    }
                break;
                default :
                    Console.WriteLine("Invalid input.");
                break;
            }
        }
    }
}