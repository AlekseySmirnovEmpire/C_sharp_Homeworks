using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1
{
    public class People
    {
        private Queue<Shooter> shooters = new Queue<Shooter>();
        public int shootingTime { get; private set; }

        public People()
        {
            for(int i = 0; i < 13; ++i)
            {
                shooters.Enqueue(new Shooter(i));
            }

            shootingTime = 0;
        }

        public Shooter GetShooter()
        {
            return shooters.Dequeue();           
        }

        public void SetShooter(Shooter emp, DateTime begin, DateTime end)
        {
            if(emp != null)
                {
                    shooters.Enqueue(emp);
                }

            shootingTime += calcTime(begin, end);        
        }

        static public int calcTime(DateTime begin, DateTime end)
        {
            int sec;
            if(end.Second - begin.Second < 0)
            {      
                sec = 60 + (end.Second - begin.Second);
            }
            else
            {
                sec = end.Second - begin.Second;
            }

            return sec;
        }

        public bool isOver()
        {
            foreach(var el in shooters)
            {
                if(el.shootTimeCount != 5)
                    return false;
            }

            return true;
        }
    }
}