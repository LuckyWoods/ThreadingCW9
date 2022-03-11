/*
* Author: Lucky Jaxxon Woods
* Date: 3/09/22
* File: program.cs
* Description: A C# file containing the implementation of the main program.
*
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threading
{
    class Program
    {
      
        static void Main(string[] args)
        {
            Console.WriteLine("How many darts?");
            string intConvert = Console.ReadLine();
            int dartCount = int.Parse(intConvert);
            //Asks for dart amount.

            Console.WriteLine("How many threads");
            string threadConvert = Console.ReadLine();
            int threadCount = int.Parse(threadConvert);
            //Asks for thread count.

            List<Thread> listThread = new List<Thread>();
            List<FindPIThread> listPIThread = new List<FindPIThread>();

            for (int i = 0; i < threadCount; i++)
            {
                FindPIThread loop = new FindPIThread(dartCount);
                listPIThread.Add(loop);
                Thread myThread = new Thread(new ThreadStart(loop.throwDarts));
                listThread.Add(myThread);
                myThread.Start();
                Thread.Sleep(16);
                //Does a loop to set up each threads lists to get the amount of hits done.
            }


            for (int i = 0; i < threadCount; i++)
            {
                listThread[i].Join(); //Joins the lists together
            }

            double totalDartHit = 0;

            for (int i = 0; i < threadCount; i++)
            {
                double x = listPIThread[i].printHits();
                totalDartHit = x + totalDartHit;
            }

            double totalCount = (dartCount * threadCount); //Used to get the total number for division.
            double totalEva = (4 * ((totalDartHit)/ totalCount)); //Does PI evaluation.

            Console.WriteLine("PI Evaluation of all Threads: " + totalEva);
        }
    }
}
