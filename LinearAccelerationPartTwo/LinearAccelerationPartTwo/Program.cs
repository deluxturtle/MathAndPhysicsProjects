using System;
using System.IO;

namespace LinearAccelerationPartTwo
{
    /// <summary>
    /// @Author:Andrew Seba
    /// @Description: Using Equation 5 and 7 output the data of the motion.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            float initialHeight = 2.00f;
            float initialVelocity = 49.0f;

            float curVelocity = initialVelocity;
            float curY = initialHeight;

            const float acceleration = -9.8f;

            float curTime = 0.0f;
            float endTime = 10.00f;
            float timeStep = 0.10f;


            using (StreamWriter writer = new StreamWriter("ex02_analytic.csv"))
            {
                Console.WriteLine("Time(s):\tPosition(m)\tVelocity(m/s)");
                writer.WriteLine("Time(s),Position(m),Velocity(m/s)");
                while (curTime <= endTime)
                {
                    //Output Time, Position, Velocity data for the ball.
                    Console.WriteLine(string.Format("{0:N}\t{1:N}\t{2:N}", curTime, curY, curVelocity));
                    writer.WriteLine(string.Format("{0:N},{1:N},{2:N}", curTime, curY, curVelocity));

                    //Find the new position.
                    curY += curVelocity * timeStep + ((acceleration * (timeStep * timeStep)) / 2.0f);
                    //Find the new velocity
                    curVelocity += acceleration * timeStep;
                    
                    //Increment Time.
                    curTime += timeStep;
                }
            }

            Console.ReadKey();
        }
    }
}
