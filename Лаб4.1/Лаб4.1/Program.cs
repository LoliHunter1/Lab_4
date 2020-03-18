using System;

namespace Лаб4._1
{
    class Program
    {
        class Student
        {
            private string name;
            private int sumb;
            private static Random rnd = new Random();
            public static Student[] InitAr(Student[] a)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = new Student();
                }
                return a;
            }
            public void SetValue(string a)
            {
                this.name = a;
                this.sumb = rnd.Next(1,10);
            }
            public void VivodInf()
            {
                Console.WriteLine("Имя = {0}, Средний балл = {1}", this.name, this.sumb);
            }
        }
        static void Main()
        {
            //Zad 4
            Student[] mas = new Student[3];
            for (int i = 0; i < 3; i++)
                Student.InitAr(mas);
            mas[0].SetValue("Арарат");
            mas[1].SetValue("Вячеслав");
            mas[2].SetValue("Евгений");
            for (int i = 0; i < 3; i++)
                mas[i].VivodInf();
        }
    }
}
