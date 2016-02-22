﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ProjectionLab;
using VectorClassLab;

namespace LinearAcceleratedMotionLab
{
    /// <summary>
    /// @Author: Andrew Seba
    /// @Description: Outputs a csv file of physics data of a ball being thrown
    /// upwards.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            float initialHeight = 2.00f;
            float initialVelocity = 49.0f;

            float curVelocity = initialVelocity;
            float curY = initialHeight;

            const float gravity = -9.8f;

            float curTime = 0.0f;
            float endTime = 10.00f;
            float timeStep = 0.01f;

            //
            using(StreamWriter writer = new StreamWriter("ex02_eular_0-01.csv"))
            {
                Console.WriteLine("Time(s):\tPosition(m)\tVelocity(m/s)");
                writer.WriteLine("Time(s),Position(m),Velocity(m/s)");
                while (curTime <= endTime)
                {

                    curY += curVelocity * timeStep; //Find the new position.
                    curVelocity += gravity * timeStep;//Find the new velocity
                    //Output Time, Position, Velocity data for the ball.
                    Console.WriteLine(string.Format("{0:N}\t{1:N}\t{2:N}", curTime, curY, curVelocity));
                    writer.WriteLine(string.Format("{0:N},{1:N},{2:N}", curTime, curY, curVelocity));

                    //Increment Time.
                    curTime += timeStep;
                }
            }

            Console.ReadKey();
        }
    }
}