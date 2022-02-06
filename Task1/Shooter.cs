using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Task1
{
    public class Shooter
    {
        public int id { get; private set; }
        public bool onTrace { get; private set; }
        public int shootTimeCount {get; private set;}

        public Shooter(int id)
        {
            this.id = id;
            onTrace = false;
            shootTimeCount = 0;
        }

        public void readyVoice(object obj)
        {
            onTrace = true;
            var rnd = new Random();
            Tuple<string, EventWaitHandle> temp = obj as Tuple<string, EventWaitHandle>;

            Thread.Sleep(1000 * rnd.Next(3, 10));

            Console.WriteLine(temp.Item1 + " Занял направление!");

            temp.Item2.Set();
        }

        public void steadyVoice(ref string text)
        {
            var rnd = new Random();

            Thread.Sleep(1000 * rnd.Next(1, 4));

            Console.WriteLine(text + " К стрельбе готов!");
        }

        public void shootVoice(ref string text)
        {
            var rnd = new Random();

            Thread.Sleep(1000 * rnd.Next(5, 15));

            Console.WriteLine(text + " Стрельбу окончил!");
            onTrace = false;
            ++shootTimeCount;
        }
    }
}