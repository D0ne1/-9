using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double angle1;
            double angle2;
            double angle3;

            DialClock clock1 = new DialClock(); // конструктор без параметров
            clock1.Hours = 12;
            clock1.Minutes = 20;
            clock1.Show();

            DialClock clock2 = new DialClock(12,20); // конструктор с параметрами
            clock2.Show();

            DialClock clock3 = new DialClock(clock2); // конструктор копирования
            clock2.Show();

            DialClock.ShowStatic(clock1);

            angle1 = clock1.GetCorner();
            Console.WriteLine(angle1);

            angle2 = clock2.GetCorner();
            Console.WriteLine(angle2);

            angle3 = clock3.GetCorner();
            Console.WriteLine(angle3);

            Console.WriteLine(DialClock.GetCount());
        }
    }
}
