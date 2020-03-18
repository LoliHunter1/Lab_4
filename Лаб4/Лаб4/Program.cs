using System;

namespace Лаб4
{
    class Program
    {   
        class arra
        {
            private static Random rnd = new Random();
            public static void CreateOneDimAr(int[,] a)
            {
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        a[i,j] = rnd.Next(1, 10);
            }
            public static void PrintArObj(string b, object[] a)
            {
                Console.WriteLine("Массив {0} = ", b);
                foreach (object a1 in a)
                    Console.Write(" {0} ",a);
                Console.WriteLine();
            }
        }
        static void PrintAnyArr(string b, Array a)//чтобы не делать две функции для foreach и цикла for я реализовал оба этих метода в одной функции
        {
            Console.WriteLine("Массив {0} = ", b);
            if (a.Rank == 1)
                if (a.GetValue(0) is Array)
                {
                    int k = 0;
                    foreach (Array a1 in a)
                    {
                        PrintAnyArr(b+k.ToString(),a1);
                        k++;
                    }
                    Console.WriteLine();
                }
                else
                {
                    foreach (Object a1 in a)
                        Console.Write(a1.ToString().PadLeft(4));
                    Console.WriteLine();
                }
            if (a.Rank == 2) 
            {
                for (int i = 0; i < a.GetLength(0); i++, Console.WriteLine())
                    for (int j = 0; j < a.GetLength(1); j++)
                        Console.Write(a.GetValue(i, j).ToString().PadLeft(4));
                Console.WriteLine();
            }
            //Console.WriteLine();
        }

        static void PrintArr(string b ,Object a)
        {
            Array a1 = a as Array;
            if (a == null)
            {
                Console.WriteLine("Ваш массив пуст");
            }
            PrintAnyArr(b,a1);
        }
        static int[,] sum(int[,] a, int[,] b)
        {
            int c1 = mini(a.GetLength(0), b.GetLength(0));
            int c2 = mini(a.GetLength(1), b.GetLength(1));
            int[,] c = new int[c1, c2];
            for (int i = 0; i < c1; i++)
                for (int j = 0; j < c2; j++)
                    c[i, j] = a[i, j] + b[i, j];
            return c;
        }
        static int mini(int a, int b)
        {
            if (a > b) return b;
            else return a;
        }
        static int[,] raz(int[,] a, int[,] b)
        {
            int c1 = mini(a.GetLength(0),b.GetLength(0));
            int c2 = mini(a.GetLength(1), b.GetLength(1));
            int[,] c = new int[c1,c2];
            for (int i = 0; i < c1; i++)
                for(int j = 0; j < c2; j++)
                    c[i,j] = a[i,j] - b[i,j];
            return c;
        }
        static int[,] MultMatr(int[,] a, int[,] b)
        {
            int[,] c = new int[a.GetLength(0), b.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    for (int k = 0; k < b.GetLength(0); k++)
                        c[i, j] += a[i, k] * b[k, j];
            return c;
        }
        static double[,] DelMatr(int[,] a, int[,] b)
        {
            double[,] c = new double[a.GetLength(0), b.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    for (int k = 0; k < b.GetLength(0); k++)
                        c[i, j] += a[i, k] / b[k, j];
            return c;
        }
        static void Main()
        {
            /*Zad1
             int[][] a = {
                  new int[] {1,2,3,4,5},
                  new int[] {6,7,8,9,10},
                  new int[] {11,12,13,14,15}
              };
            double[] b = { 1.2, 2, 3, 4 };
            int[,] c = { { 1, 2, 3 }, { 4, 5, 6 } };
            PrintAnyArr("a",a);
            PrintAnyArr("b",b);
            PrintAnyArr("c",c);*/
            /*Zad 2
            string[] d = { "A", "B", "C", "D","B", "A" }, d1 = new string[6];
            Array.Copy(d,d1,6);
            foreach (object a1 in d1)
                Console.Write(" {0} ", a1);
            Console.WriteLine();
            Console.WriteLine(Array.IndexOf(d1, "B"));
            Console.WriteLine(Array.LastIndexOf(d1, "A"));
            Array.Reverse(d1);
            foreach (object a1 in d1)
                Console.Write(" {0} ", a1);
            Console.WriteLine();
            Array.Sort(d1);
            foreach (object a1 in d1)
                Console.Write(" {0} ", a1);
            Console.WriteLine();
            Console.WriteLine(Array.BinarySearch(d1, "C"));*/

            /*Zad 3
            int[] A = { 1,2,3 };
            int[,] mas = { { 1,2,3 }, { 1,2,3 } };
            Console.WriteLine(mas.Length);
            Console.WriteLine(mas.GetLength(0));
            Console.WriteLine(mas.GetLength(1));
            PrintArr("A",A);*/

            /*Zad 5
            object[] A = { 1, 2, 3 };
            object[] B = { 1.2, 1.4, 1.6 };
            arra.PrintArObj("A", A);
            arra.PrintArObj("B", B);*/

            /*Zad 6*/
            Console.WriteLine("Введите длину размера");//Для умножения и деления матриц нужно сделать длину или ширину массива равной 4
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int[,] mas1 = new int[b, c];
            int[,] mas2 = new int[4,4];
            arra.CreateOneDimAr(mas2);
            arra.CreateOneDimAr(mas1);
            Console.WriteLine("Введите индексы элементов");
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
            if (b >= mas1.GetLength(0) || c >= mas1.GetLength(1)) Console.WriteLine("Вы вышли за пределы массива");
            else Console.WriteLine("Значение массива в точках ({0}, {1}) = {2}", b, c, mas1[b, c]);
            PrintAnyArr("mas1", mas1);
            PrintAnyArr("mas2", mas2);
            PrintAnyArr("sum",sum(mas1, mas2));
            PrintAnyArr("raz", raz(mas1, mas2));
            PrintAnyArr("MultiMatr", MultMatr(mas1, mas2));
            PrintAnyArr("DelMatr", DelMatr(mas1, mas2));
        }
    }
}