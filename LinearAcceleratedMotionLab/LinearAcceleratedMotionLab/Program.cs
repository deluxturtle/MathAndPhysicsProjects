using System;
using System.IO;

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
            //Where the ball will begin its journey.
            float initialHeight = 2.00f;
            //Starting velocity.
            float initialVelocity = 49.0f;

            float curVelocity = initialVelocity;
            float curY = initialHeight;

            //Gravity Acceleration.
            const float gravity = -9.8f;

            //Current time indicator.
            float curTime = 0.0f;
            //End the simulation will end.
            float endTime = 10.00f;
            //The incremints of time for the simulation.
            float timeStep = 0.01f;

            //
            using(StreamWriter writer = new StreamWriter("ex02_eular_0-01.csv"))
            {
                Console.WriteLine("Time(s):\tPosition(m)\tVelocity(m/s)");
                writer.WriteLine("Time(s),Position(m),Velocity(m/s)");
                while (curTime <= endTime)
                {
                    //Output Time, Position, Velocity data for the ball.
                    Console.WriteLine(string.Format("{0:N}\t{1:N}\t{2:N}", curTime, curY, curVelocity));
                    writer.WriteLine(string.Format("{0:N},{1:N},{2:N}", curTime, curY, curVelocity));

                    curY += curVelocity * timeStep; //Find the new position.
                    curVelocity += gravity * timeStep;//Find the new velocity

                    //Increment Time.
                    curTime += timeStep;
                }
            }

            Console.ReadKey();
        }
    }
}
