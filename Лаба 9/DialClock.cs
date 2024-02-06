using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Лаба_9
{
    public class DialClock
    {
        public int hours;
        public int minutes;
        static int count = 0;
        public DialClock() // если конструктор пустой
        {
            Hours = 0;
            Minutes = 0;
            count++;
        }
        public DialClock(int hours, int minutes) // конструктор с параметрами
        {
            Hours = hours;
            Minutes = minutes;
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
                if (value < 0 || value >= 24)
                {
                    throw new Exception("Часы неправильные");
                }
                hours = value;
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
                if (value < 0 || value >= 60)
                {
                    throw new Exception("Минуты неправильные");
                }
                minutes = value;
                
            }
        }
        public static double GetCorner(int hours, int minutes) //статическая функция по вычислению угла
        {
            const double degreesPerHour = 30.0;  // Угол между часовыми метками
            const double degreesPerMinute = 6; // Угол между минутными метками вокруг циферблата

            double hourAngle = (hours % 12 + minutes / 60.0) * degreesPerHour; // Вычисления градусной меры часовой стрелки с учётом смещения из-за минутной стрелки
            double minuteAngle = minutes * degreesPerMinute;

            double angle = Math.Abs(hourAngle - minuteAngle);

            if (angle > 180.0)
            {
                angle = 360.0 - angle;
            }
            return Math.Round(angle, 4);
        }
        public double GetCorner() // нестатическая функция по вычислению угла
        {
            const double degreesPerHour = 30.0;  // Угол между часовыми метками
            const double degreesPerMinute = 6; // Угол между минутными метками вокруг циферблата

            if (Hours < 0 || hours > 23 || minutes < 0 || minutes > 59) // Проверка валидности входных данных
            {
                throw new ArgumentException("Некорректное время");
            }

            double hourAngle = (hours % 12 + minutes / 60.0) * degreesPerHour; // Вычисления градусной меры часовой стрелки с учётом смещения из-за минутной стрелки
            double minuteAngle = minutes * degreesPerMinute;

            double angle = Math.Abs(hourAngle - minuteAngle);

            if (angle > 180.0)
            {
                angle = 360.0 - angle;
            }

            return Math.Round(angle, 4);
        }
        public static DialClock operator ++(DialClock clock)
        {
            if (clock.Minutes == 59)
            {
                clock.Hours += 1;
                clock.Minutes -= 59;
                if (clock.Hours == 23)
                {
                    clock.Hours -= 23;
                }
            }
            else clock.Minutes++;
            return clock;
        }

        public static DialClock operator --(DialClock clock)
        {
            if (clock.Minutes == 0)
            {
                clock.Hours--;
                clock.Minutes += 59;
            }
            else clock.Minutes--;
            return clock;
        }

        public void Show() //вывод на экран
        {
            Console.WriteLine($"Часы: {Hours}, минуты: {minutes}.");
        }

        public static void ShowStatic(DialClock clock) // вывод на экран (статическая функция)
        {
            Console.WriteLine($"Часы: {clock.hours}, минуты: {clock.minutes}.");
        }
        public static int GetCount() { return count; }
    }
}
