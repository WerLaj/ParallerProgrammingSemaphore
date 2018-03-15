﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ParallerProgrammingSemaphore
{
    

public class Program
    {
        public static Thread[] warlocks;
        public static Thread[] sorcerers;
        public static FactoryLead leadFactory = new FactoryLead();
        public static FactoryMercury mercuryFactory = new FactoryMercury();
        public static FactorySulfur sulfurFactory = new FactorySulfur();
        public static Thread[] alchemistsA;
        public static Thread[] alchemistsB;
        public static Thread[] alchemistsC;
        public static Thread[] alchemistsD;
        public static Thread lfacThread;
        public static Thread mfacThread;
        public static Thread sfacThread;
        public static GuildA guildA;
        public static GuildB guildB;
        public static GuildC guildC;
        public static GuildD guildD;
        public static Semaphore alchemistChoice = new Semaphore(1, 1);
        //public static int lead = 0;
        //public static int mercury = 0;
        //public static int sulfur = 0;

        static void Main(string[] args)
        {
            
            alchemistsA = new Thread[3];
            alchemistsB = new Thread[2];
            alchemistsC = new Thread[4];
            alchemistsD = new Thread[4];
           
            guildA = new GuildA(3, alchemistsA);
            guildB = new GuildB(2, alchemistsB);
            guildC = new GuildC(4, alchemistsC);
            guildD = new GuildD(4, alchemistsD);

            guildA.startAlchemists(3, alchemistsA);
            guildB.startAlchemists(2, alchemistsB);
            guildC.startAlchemists(4, alchemistsC);
            guildD.startAlchemists(4, alchemistsD);

            //for (int i = 0; i < 2; i++)
            //{
            //    AlchemistA a = new AlchemistA();
            //    guildA.guild[i] = a;
            //    guildA.numberOfAlchemistsInGuild++;
            //    alchemistsA[i] = new Thread(a.collectIngredients);
            //    alchemistsA[i].Start();

            //    AlchemistB b = new AlchemistB();
            //    guildB.guild[i] = b;
            //    guildB.numberOfAlchemistsInGuild++;
            //    alchemistsB[i] = new Thread(b.collectIngredients);
            //    alchemistsB[i].Start();

            //    AlchemistC c = new AlchemistC();
            //    guildC.guild[i] = c;
            //    guildC.numberOfAlchemistsInGuild++;
            //    alchemistsC[i] = new Thread(c.collectIngredients);
            //    alchemistsC[i].Start();

            //    AlchemistD d = new AlchemistD();
            //    guildD.guild[i] = d;
            //    guildD.numberOfAlchemistsInGuild++;
            //    alchemistsD[i] = new Thread(d.collectIngredients);
            //    alchemistsD[i].Start();
            //}

            lfacThread = new Thread(leadFactory.produce);
            lfacThread.Start();
            mfacThread = new Thread(mercuryFactory.produce);
            mfacThread.Start();
            sfacThread = new Thread(sulfurFactory.produce);
            sfacThread.Start();

            warlocks = new Thread[3];
            sorcerers = new Thread[3];


            for (int i = 0; i < 3; i++)
            {
                Warlock w = new Warlock();
                warlocks[i] = new Thread(w.curse);
                warlocks[i].Name = "warlock_" + i;
                warlocks[i].Start();
            }

            for (int i = 0; i < 3; i++)
            {
                Sorcerer s = new Sorcerer();
                sorcerers[i] = new Thread(s.removeCurses);
                sorcerers[i].Name = "sorcerer_" + i;
                sorcerers[i].Start();
            }


            Console.ReadKey();
        }

        public static int getWarlockThreadName(Thread t)
        {
            int n = 0;

            n = Array.IndexOf(warlocks, t); 

            return n;
        }

        public static int getSorcererThreadName(Thread t)
        {
            int n = 0;

            n = Array.IndexOf(sorcerers, t);

            return n;
        }

    }
}
