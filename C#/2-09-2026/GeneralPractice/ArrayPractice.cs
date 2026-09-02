namespace GeneralPractice;

public class ArrayPractice
{
    public static void SingleArray()
    {
        int[] a;

        Console.WriteLine("Enter N : ");
        int n = int.Parse(Console.ReadLine());

        a = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter a[{i}] : ");
            a[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"a[{i}] = {a[i]}");
        }
    }

    public static void MultiArray()
    {
        int[,] arr;
        int n;

        Console.Write("Enter N : ");
        n = int.Parse(Console.ReadLine());

        arr = new int[n, n];

        Console.WriteLine("\nPascal Triangle:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (j == 0 || j == i)
                {
                    arr[i, j] = 1;
                    Console.Write(arr[i, j] + " ");
                }
                else
                {
                    arr[i, j] = arr[i - 1, j] + arr[i - 1, j - 1];
                    Console.Write(arr[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(arr[i, j] + " ");
            }
        }
    }

    public static void JaggedArray()
    {
        int[][] jarr;
        int n;

        Console.Write("Enter N : ");
        n = int.Parse(Console.ReadLine());

        jarr = new int[n][];

        Console.WriteLine("\nPascal Triangle:");

        for (int i = 0; i < n; i++)
        {
            jarr[i] = new int[i + 1];

            for (int j = 0; j <= i; j++)
            {
                if (j == 0 || i == j)
                {
                    jarr[i][j] = 1;
                }
                else
                {
                    jarr[i][j] = jarr[i - 1][j] + jarr[i - 1][j - 1];
                }

                Console.Write(jarr[i][j] + " ");
            }

            Console.WriteLine();
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < jarr[i].Length; j++)
            {
                Console.Write(jarr[i][j] + " ");
            }
        }
    }

}
