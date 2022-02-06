using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Task1
{
    public class Trace
    {
        private EventWaitHandle waitHandle = new AutoResetEvent(false);
        private EventWaitHandle endWaitHandle = new AutoResetEvent(false);
        private (People, Shooter) emp = (null, null);
        public int id { get; private set; }        
        static private object mtx = new object();
        public bool isEmpty {get; private set;}
        public Trace(int id)
        {
            this.id = id;
            isEmpty = true;
        }

        public void initShooter(Shooter shooter)
        {
            if(shooter.shootTimeCount < 5)
            {
                isEmpty = false;
                emp.Item2 = shooter;
                var myThr = new Thread(new ParameterizedThreadStart(shooter.readyVoice));
            
                string text = $"Направление {this.id + 1}, стрелок {emp.Item2.id + 1}:";

                Tuple<string, EventWaitHandle> input = new Tuple<string, EventWaitHandle>(text, waitHandle);
                myThr.Start(input);
            }            
        }

        public void initInstructor(Instructor instructor, People people)
        {
            if(emp.Item2 != null)
            {
                waitHandle.WaitOne();

                emp.Item1 = people;

                var myThr = new Thread(new ParameterizedThreadStart(startShooting));

                myThr.Start(instructor);

                endWaitHandle.WaitOne();
            }            
        }

        private void startShooting(object instructor)
        {
            var inst = instructor as Instructor;
            string text = $"Направление {this.id + 1}, инструктор {inst.id + 1}, стрелок {emp.Item2.id + 1}:";

            inst.prepShootVoice(ref text);
            emp.Item2.steadyVoice(ref text);
            inst.goShootVoice(ref text);

            DateTime start = DateTime.Now;
            emp.Item2.shootVoice(ref text);
            DateTime end = DateTime.Now;

            emp.Item1.SetShooter(emp.Item2, start, end);
            emp = (null, null);
            this.isEmpty = true;

            endWaitHandle.Set();
        }
    }
}