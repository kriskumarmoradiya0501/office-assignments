namespace PracticeAssignment;
using System.IO;
using System.Text;
public class FileStreamDemo
{
    public static void FileStreamMain()
    {
        try
        {
            
        FileStream fs = new FileStream(    
            @"D:\office\C#\3-09-2026\FileStreamTest.txt",
            FileMode.OpenOrCreate,
            FileAccess.Write
        );
        string data = "Hello";

        byte[] bytes = Encoding.UTF8.GetBytes(data);

        for(int i = 0 ; i < bytes.Length; i++)
        {
            Console.WriteLine(bytes[i]);
        }

        Console.WriteLine(Encoding.UTF8.GetBytes(data));
    
        fs.Write(bytes,2,3);
        // here 2 repesent off set and 3 represent number of count 
        // you can simply write 0 and bytes.length
        
        fs.Close();
        
        
        // FileStream fs = new FileStream(    
        //     @"D:\office\C#\3-09-2026\FileStreamTest.txt",
        //     FileMode.CreateNew,
        //     FileAccess.Write
        // );
        // string data = "Hello";

        // byte[] bytes = Encoding.UTF8.GetBytes(data);

        // for(int i = 0 ; i < bytes.Length; i++)
        // {
        //     Console.WriteLine(bytes[i]);
        // }

        // Console.WriteLine(Encoding.UTF8.GetBytes(data));
    
        // fs.Write(bytes,2,3);
        // // here 2 repesent off set and 3 represent number of count 
        // // you can simply write 0 and bytes.length
        
        // fs.Close();

            // FileStream fs = new FileStream(    
            //     @"D:\office\C#\3-09-2026\FileStreamTest.txt",
            //     FileMode.Create,
            //     FileAccess.Write
            // );
            // string data = "Hello";

            // byte[] bytes = Encoding.UTF8.GetBytes(data);

            // for(int i = 0 ; i < bytes.Length; i++)
            // {
            //     Console.WriteLine(bytes[i]);
            // }

            // Console.WriteLine(Encoding.UTF8.GetBytes(data));

            // fs.Write(bytes,2,3);
            // // here 2 repesent off set and 3 represent number of count 
            // // you can simply write 0 and bytes.length

            // fs.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Error : "+e.Message);
        }
    }
}
