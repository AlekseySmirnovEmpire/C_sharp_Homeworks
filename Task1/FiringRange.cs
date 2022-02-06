using System.Data.SqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Task1
{
    public class FiringRange
    {
        static private EventWaitHandle mainWait = new AutoResetEvent(false);
        static private int threadsOver = 0;
        List<Trace> traces = new List<Trace>();
        static private People shooters = null;

        public FiringRange(People obj)
        {
            for(int i = 0; i < 6; ++i)
            {
                traces.Add(new Trace(i));
            }

            shooters = obj;

            Thread first = new Thread(new ParameterizedThreadStart(halfRange));
            Tuple<List<Trace>, Instructor> inputFirst = new (traces.Where(el => el.id < 3).ToList(), new Instructor(0));
            first.Start(inputFirst);

            Thread second = new Thread(new ParameterizedThreadStart(halfRange));
            Tuple<List<Trace>, Instructor> inputSecond = new (traces.Where(el => el.id >= 3).ToList(), new Instructor(1));
            second.Start(inputSecond);

            mainWait.WaitOne();
        }

        private void halfRange(object obj)
        {
            Tuple<List<Trace>, Instructor> temp = obj as Tuple<List<Trace>, Instructor>;
            var traceList = temp.Item1;
            var instructor = temp.Item2;
            while(!shooters.isOver())
            {
                for(int i = 0; i < traceList.Count(); ++i)
                {
                    if(traceList[i].isEmpty)
                        traceList[i].initShooter(shooters.GetShooter());
                }
                
                traceList[instructor.numberOfTrace].initInstructor(instructor, shooters);
            }

            ++threadsOver;

            if(threadsOver == 2)
                mainWait.Set();
        }
    }
}