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

            Console.WriteLine("How many threads");
            string threadConvert = Console.ReadLine();
            int threadCount = int.Parse(threadConvert);

            for (int i = 0; i < threadCount; i++)
            {
                FindPIThread loop = new FindPIThread(dartCount);
                Thread myThread = new Thread(new ThreadStart(loop.throwDarts));
                myThread.Start();
                Thread.Sleep(16);
                loop.printHits();
            }
        }
    }
}