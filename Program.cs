using System;
using System.Diagnostics;
using System.Threading;

class Ali
{
    public static void Main()
    {
        Console.WriteLine("This program prints sum of even and odd numbers till the limit specidfied by the user and also prints the amount of time required by compiler to perform it.");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");

        Console.WriteLine("Enter the number till you want to count the sum; ");
        int count = Convert.ToInt32(Console.ReadLine());

        Stopwatch SW1 = Stopwatch.StartNew();

        SEN(count);
        SON(count);

        SW1.Stop();

        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Total time without threading: {0}ms", SW1.ElapsedMilliseconds);
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");

        Thread T1 = new Thread(() => SEN(count));
        Thread T2 = new Thread(() => SON(count));

        Stopwatch SW2 = Stopwatch.StartNew();

        T1.Start();
        T2.Start();

        T1.Join();
        T2.Join();

        SW2.Stop();

        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Total time with threading: {0}ms", SW2.ElapsedMilliseconds);
    }

    public static void SEN(int C)
    {
        double sum = 0;
        for (int i = 0; i <= C; i++)
        {
            if (i % 2 == 0)
            {
                sum = sum + i;
            }
        }
        Console.WriteLine("Sum of Even Numbers is: {0}", sum);
    }

    public static void SON(int C)
    {
        double sum = 0;
        for (int i = 0; i <= C; i++)
        {
            if (i % 2 == 1)
            {
                sum = sum + i;
            }
        }
        Console.WriteLine("Sum of Odd Numbers is: {0}", sum);
    }
}