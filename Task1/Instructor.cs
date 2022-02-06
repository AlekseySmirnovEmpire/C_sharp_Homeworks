using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1
{
    public class Instructor
    {
        public int id { get; private set; }
        public int numberOfTrace;

        public Instructor(int id)
        {
            this.id = id;
            numberOfTrace = 0;
        }

        public void prepShootVoice(ref string text)
        {
            var rnd = new Random();

            Thread.Sleep(1000 * rnd.Next(2, 6));

            Console.WriteLine(text + " Подготовиться к стрельбе!");
        }

        public void goShootVoice(ref string text)
        {
            var rnd = new Random();

            Thread.Sleep(1000 * rnd.Next(1, 2));

            Console.WriteLine(text + " Произвести стрельбу!");

            ++numberOfTrace;
            if(numberOfTrace > 2)
                numberOfTrace = 0;
        }
    }
}