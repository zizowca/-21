using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Задание_21
{
    class Program
    {
        const int n = 4;
        const int t = 6;
        static int[,] garden = new int[n, t] { {1,4,7,3,9,5 },{ 2, 6, 7, 4, 10, 8 },{ 11, 15, 13, 13, 10, 18 },{ 14, 2, 8, 10, 3, 1 } };
        static void Main(string[] args)
        {
            ThreadStart ready = new ThreadStart(Gardner1);
            Thread steady = new Thread(ready);
            steady.Start();
            Gardner2();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < t; j++)
                {
                    Console.Write($"{garden[i,j]}");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void Gardner1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < t; j++)
                {
                    if (garden[i, j] >= 0)
                    {
                        int stop = garden[i, j];
                        garden[i, j] = -1;
                        Thread.Sleep(stop);
                    }
                }
            }
        }
        static void Gardner2()
        {
            for (int i = n-1; i >=0; i--)
            {
                for (int j = t-1; j >= 0; j--)
                {
                    if (garden[i, j] >= 0)
                    {
                        int stop = garden[i, j];
                        garden[i, j] = -2;
                        Thread.Sleep(stop);
                    }
                }
            }
        }
    }
}
