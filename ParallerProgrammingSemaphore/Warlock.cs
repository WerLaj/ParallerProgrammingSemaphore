﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallerProgrammingSemaphore
{
    public class Warlock
    {
        string threadName;
        FactoryLead lfac;
        FactoryMercury mfac;
        FactorySulfur sfac;

        public Warlock()
        {
            threadName = Thread.CurrentThread.Name;
            lfac = Program.leadFactory;
            mfac = Program.mercuryFactory;
            sfac = Program.sulfurFactory;
        }

        public void curse()
        {
            int i = 0;
            do
            {
                Factory fac;
                fac = getRandomFactory();

                int time = getRandomTimeInterval();
                Console.WriteLine("Warlock " + Program.getWarlockThreadName(Thread.CurrentThread) + " sleeps for " + time + " sec");
                Thread.Sleep(time);

                fac.curseBinarySemaphore.WaitOne();

                Console.WriteLine("----" + fac.factoryName + " cursed by Warlock" + Program.getWarlockThreadName(Thread.CurrentThread));
                fac.curses++;

                fac.curseBinarySemaphore.Release();

                i++;
            } while (i < 5);
        }

        public Factory getRandomFactory()
        {
            Factory fac = new Factory();

            Random rnd = new Random();
            int factoryType = rnd.Next(1, 4);

            if (factoryType == 1)
            {
                fac = lfac;
            }
            else if (factoryType == 2)
            {
                fac = mfac;
            }
            else
            {
                fac = sfac;
            }

            return fac;
        }

        public int getRandomTimeInterval()
        {
            int time = 0;
            Random rnd = new Random();
            time = rnd.Next(1000, 5000);

            return time;
        }
    }
}