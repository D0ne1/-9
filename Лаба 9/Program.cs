using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_9
{
    internal class Program
    {
        public static DialClock SetClock1()
        {
            try
            {
                DialClock clock1 = new DialClock(); // конструктор без параметров
                clock1.Hours = 14;
                clock1.Minutes = 59;
                return clock1;
            }
            catch (Exception ex){ Console.WriteLine(ex.Message); return null; }
        } 
        public static DialClock SetClock2()
        {
            try
            {
                DialClock clock2 = new DialClock(12,0); // конструктор с параметрами
                return clock2;
            }
            catch (Exception ex) {  Console.WriteLine(ex.Message); return null; }
        }
        public static DialClock SetClock3()
        {
            try
            {
                DialClock clock3 = new DialClock(SetClock1()); //конструктор копирования
                return clock3;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return null; }
        }
        static void Main(string[] args)
        {
            double angle1;
            double angle2;
            double angle3;

            DialClock clock1 = SetClock1();
            DialClock.ShowStatic(clock1); // вывод на экран (статическая функция)
            
            DialClock clock2 = SetClock2();
            clock2.Show(); //вывод нестатическая функция 

            DialClock clock3 = SetClock3(); // конструктор копирования
            clock3.Show();

            angle1 = clock1.GetCorner();//нестатическая функция вычисления угла между часовой и минутной стрелкой
            Console.WriteLine(angle1);

            angle2 = clock2.GetCorner();//нестатическая функция вычисления угла между часовой и минутной стрелкой
            Console.WriteLine(angle2);

            angle3 = clock3.GetCorner();//нестатическая функция вычисления угла между часовой и минутной стрелкой
            Console.WriteLine(angle3);

            Console.WriteLine(DialClock.GetCorner(clock1.Hours, clock1.Minutes)); //статическая функция вычисления угла между часовой и минутной стрелкой

            Console.WriteLine(DialClock.GetCount()); //статическая функция по подсчёту количества операций

            ++clock1;// прибавление минуты
            clock1.Show();

            --clock2; // вычитание минуты
            clock2.Show();
        }
    }
}
