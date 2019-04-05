using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Богатов Максим

namespace lesson4
{
    class Program
    {
        static string Print2(int[,] a)
        {
            string s = "";
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    s += a[i, j] + "   ";
                s += "\n";

            }
            return s;
        }

        static void Print(int[] myarray)
        {
            foreach (int el in myarray)
                Console.Write("{0,4}", el);
        }

        public static int[] getLCS(int[] x, int[] y)
        {
            int m = x.GetLength(0);
            int n = y.GetLength(0);
            int[,] len = new int[m + 1, n + 1];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (x[i] == y[j])
                    {
                        len[i + 1, j + 1] = len[i, j] + 1;
                    }
                    else
                    {
                        len[i + 1, j + 1] = Math.Max(len[i + 1, j], len[i, j + 1]);
                    }
                }
            }
            int cnt = len[m, n];
            int[] res = new int[cnt];
            for (int i = m - 1, j = n - 1; i >= 0 && j >= 0;)
            {
                if (x[i] == y[j])
                {
                    res[--cnt] = x[i];
                    --i;
                    --j;
                }
                else if (len[i + 1, j] > len[i, j + 1])
                {
                    --j;
                }
                else
                {
                    --i;
                }
            }
            return res;
        }

        static void Main(string[] args)
        {

            //1. * Количество маршрутов с препятствиями.
            //Карта для примера:
            //3 3
            //1 1 1
            //0 1 0
            //0 1 0

            int N = 8;
            int M = 8;
            int[,] W = new int[N, M];
            int[,] Map = new int[N, M];
            int[,] B =
            {
             {1,1,1},
             {0,1,0},
             {0,1,0}
            };

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Map[i, j] = 1;
                }
            }

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Map[i, j] = B[i, j];
                }
            }

            for (int i = B.GetLength(0); i < N; i++)
            {
                Map[i, 0] = Map[i-1, 0];
                for (int j = B.GetLength(1); j < M; j++)
                {
                    Map[0, j] = Map[0, j-1];
                }
            }

            for (int j = 0; j < M; j++)
            {
                if (Map[0, j] == 0)
                    W[0, j] = 0;
                else
                    W[0, j] = 1; 
            }
            for (int i = 1; i < N; i++)
            {
                if (Map[i, 0] == 0)
                    W[i, 0] = 0;
                else
                    W[i, 0] = 1;
                for (int j = 1; j < M; j++)
                {

                    if (Map[i, j] == 0)
                        W[i, j] = 0;
                    else
                        W[i, j] = W[i, j - 1] + W[i - 1, j];
                }
            }

            Console.WriteLine("Количество маршрутов с препятствиями.Реализовать чтение массива с препятствием и нахождение количество маршрутов.");
            Console.WriteLine("Массив с  препятствиями.");
            Console.WriteLine(Print2(Map));
            Console.WriteLine("Количество маршрутов");
            Console.WriteLine(Print2(W));
            Console.WriteLine("\n");

            //2.Решить задачу о нахождении длины максимальной подпоследовательности с помощью матрицы.

            Console.WriteLine("Максимальная подпоследовательности с помощью матрицы.");

            int[] x = { 1, 3, 8, 11, 17, 121, 45 };
            int[] y = { 3, 21, 8, 75, 121, 4, 67, 45, 79 };
            int[] lсs = getLCS(x, y);
            Print(lсs);
            Console.ReadKey();

        }
    }
}
