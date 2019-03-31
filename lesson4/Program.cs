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
                    s += a[i, j] + " ";
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
            int[,] len = new int[m + 1,n + 1];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (x[i] == y[j])
                    {
                        len[i + 1,j + 1] = len[i,j] + 1;
                    }
                    else
                    {
                        len[i + 1,j + 1] = Math.Max(len[i + 1,j], len[i,j + 1]);
                    }
                }
            }
            int cnt = len[m,n];
            int[] res = new int[cnt];
            for (int i = m - 1, j = n - 1; i >= 0 && j >= 0;)
            {
                if (x[i] == y[j])
                {
                    res[--cnt] = x[i];
                    --i;
                    --j;
                }
                else if (len[i + 1,j] > len[i,j + 1])
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

            //1. * Количество маршрутов с препятствиями.Реализовать чтение массива с препятствием и нахождение количество маршрутов.
            //Карта для примера:
            //3 3
            //1 1 1
            //0 1 0
            //0 1 0

            int N = 3;
            int M = 3;
            int[,] A = new int[N, M];
            int[,] B = new int[3, 3]
            {
                {1, 1, 1},
                {0, 1, 0},
                {0, 1, 0}
            };
            for (int j = 0; j < M; j++)
            {
                if (B[0, j] == 0)
                    A[0, j] = 0;
                else
                    A[0, j] = 1; // Первая строка заполнена единицами
            }
            for (int i = 1; i < N; i++)
            {
                if (B[i, 0] == 0)
                    A[i, 0] = 0;
                else
                    A[i, 0] = 1;
                for (int j = 1; j < M; j++)
                {
                    if (B[i, j] == 0)
                        A[i, j] = 0;
                    else
                        A[i, j] = A[i, j - 1] + A[i - 1, j];
                }
            }

            Console.WriteLine(Print2(A));
            Console.WriteLine("\n");

            //2.Решить задачу о нахождении длины максимальной подпоследовательности с помощью матрицы.

//            Будем решать эту задачу методом динамического программирования.Для этого опишем подзадачи, на которые мы будем разбивать нашу задачу. Мы напишем функцию LCS(p, q), которая находит длину НОП для двух начальных участков a1, …, ap и b1, …, bq наших последовательностей.Пусть для всех пар q и p(p < n, q < m), мы задачу решать уже научились.Попробуем вычислить LCS(n, m).Рассмотрим два случая:

//1)           an = bm.Тогда LCS(n, m) = LCS(n - 1, m - 1) + 1.

//2)           an≠ bm.Тогда LCS(n, m)= max(LCS(n, m - 1), LCS(n - 1, m)).

//Пользуясь этими формулами, мы можем заполнить таблицу значений LCS(p, q) для всех p и q последовательно: сначала заполняем первую строчку слева направо, затем вторую и т.д.Последнее число в последней строке и будет ответом на поставленную задачу.

//Данный алгоритм требует порядка O(nm) операций.

            int[] x = { 1, 5, 4, 2, 3, 7, 6 };
            int[] y = { 2, 7, 1, 3, 5, 4, 6 };
            int[] lсs = getLCS(x, y);
            Print(lсs);
            Console.ReadKey();

        }
    }
}
