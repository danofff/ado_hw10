using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ado_hw10.Model;

namespace ado_hw10
{
    class Program
    {
        public static DataBase db;
        static void Main(string[] args)
        {
            db = new DataBase();
            task1();
            task2();
            task3();
            task4();
            Console.ReadKey();
        }

        public static void task1()
        {
            var query = db.Timer.Where(w => w.DateFinish != null).Select(s => s);
            foreach (var item in query)
            {
                Console.WriteLine($"{item.TimerId} - {item.DateStart} - {item.DateFinish}");
            }
        }

        public static void task2()
        {
            var query = db.Timer.GroupBy(g => g.UserId).
                Select(s => new { UserId = s.Key, Time = s.Sum(x => (double)x.DurationInSeconds / 360/24)});

            foreach (var item in query)
            {
                Console.WriteLine($"{item.UserId,4} - {item.Time,9:F1}");
            }
        }

        public static void task3()
        {
            ConsoleColor color = Console.ForegroundColor;         
            foreach (var item in db.Timer)
            {
                Console.ForegroundColor = color;
                Console.Write($"{item.AreaId,4}-");
                if (item.DateFinish != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{ item.DurationInSeconds,6}\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{ item.DurationInSeconds,6}\n");
                }
            }
        }

        public static void task4()
        {
            ConsoleColor color = Console.ForegroundColor;
            foreach (var item in db.Timer)
            {
                Console.ForegroundColor = color;
                Console.Write($"{item.AreaId,4}-");
                if (item.DateFinish != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{ item.DurationInSeconds/360/8,6}\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{ item.DurationInSeconds/360/8,6}\n");
                }
            }
        }


    }
}
