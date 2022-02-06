using System;
using System.Collections.Generic;
using System.Threading;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            People shooters = new People();

            DateTime start = DateTime.Now;

            FiringRange range = new FiringRange(shooters);

            var timeFind = () => {
                DateTime end = DateTime.Now;
                int min = end.Minute - start.Minute;
                
                int sec = (end.Second - start.Second < 0) ? 60 + (end.Second - start.Second) : end.Second - start.Second;

                return (min, sec);
            };

            var timeSpent = timeFind();

            Console.Clear();

            Console.WriteLine($"Сумма затраченного времени: {timeSpent.Item1} минут, {timeSpent.Item2} секунд.");
            Console.WriteLine($"Длительность стрельб: {shooters.shootingTime / 60} минут, {shooters.shootingTime % 60} секунд.");
        }
    }
}