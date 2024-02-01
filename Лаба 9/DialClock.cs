using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Лаба_9
{
    internal class DialClock
    {
        private int hours;
        private int minutes;
        static int count = 0;
        public DialClock() // если конструктор пустой
        {
            this.Hours = 0;
            this.Minutes = 0;
            count++;
        }
        public DialClock(int hours, int minutes) // конструктор с параметрами
        {
            this.Hours = hours;
            this.Minutes = minutes;
            count++;
        }
        public DialClock(DialClock clock) // конструктор копирования
        {
            Hours = clock.Hours;
            Minutes = clock.Minutes;
            count++;
        }

        public int Hours
        {
            get
            {

                return hours;
            }
            set
            {
                if (value < 0) value = 0;
                if (value - 12 >= 0) value = value - 12;
                else hours = value;
            }
        }
        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                if (value < 0 || value == 60) { value = 0; }
                //if (value > 60) { Console.WriteLine("еррор"); }
                minutes = value;
            }
        }
        public double GetCorner() //вычисление угла между часовой и минутной стрелкой
        {
            double hr = hours; //вспомогательная переменная типа double
            double bias; //смещение по часовой стрелке
            double persentage; //процент смещения 
            double angle; //конечный угол
            int totalcountminutes = 60; //количество  минут на механических часах
            int totalcountminutesinhour = 5; //количество рисок в часе на механических часах
            int degreeminuts = 6; //количество градусов за 1 минуту 
                

            persentage = totalcountminutes * 100 / minutes;
            bias = totalcountminutesinhour * degreeminuts * persentage / 100;

            hr += bias;

            hr *= degreeminuts;
            minutes *= degreeminuts;
            angle = Math.Abs(hr - minutes);
            return angle;
            
        }

        public void Show() //вывод на экран
        {
            Console.WriteLine($"Часы: {hours}, минуты: {minutes}.");
        }

        public static void ShowStatic(DialClock clock) // вывод на экран (статическая функция)
        {
            Console.WriteLine($"Часы: {clock.hours}, минуты: {clock.minutes}.");
        }
        public static int GetCount() { return count; }
    }
}
