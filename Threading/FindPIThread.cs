/*
* Author: Lucky Jaxxon Woods
* Date: 3/09/22
* File: FindPIThread.cs
* Description: A C# file containing the implementation of the FindPIThread file.
*
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threading
{
    class FindPIThread
    {

        public int dartNum;
        public int dartHit;
        public Random numb;

        public FindPIThread(int dart)
        {
            numb = new Random();
            dartNum = dart;
            dartHit = 0;
        }

        public void throwDarts()
        {
            //FindPIThread findPIThread(1);

            for (int i = 0; i < dartNum; i++)
            {
                numb = new Random();
                double x = numb.NextDouble();
                numb = new Random();
                double y = numb.NextDouble();

                double z = Math.Sqrt((y*y) + (x*x));

                if (1.0 > z)
                {
                    dartHit++;
                }
            }
        }

        public int printHits()
        {
            return dartHit;

        }

    }
}
