using System;
using System.IO;

namespace LinearAccelerationWind
{
    class Program
    {
        static void Main(string[] args)
        {
            float initialHeight = 2.00f;
            float initialVelocity = 49.0f;

            float curVelocity = initialVelocity;
            float curY = initialHeight;

            float acceleration = -9.8f;

            float curTime = 0.0f;
            float endTime = 10.00f;
            float timeStep = 0.1f;

            //
            using (StreamWriter writer = new StreamWriter("ex02_wind.csv"))
            {
                Console.WriteLine("Time(s):\tPosition(m)\tVelocity(m/s)");
                writer.WriteLine("Time(s),Position(m),Velocity(m/s)");
                while (curTime <= endTime)
                {

                    curY += curVelocity * timeStep; //Find the new position.

                    curVelocity += acceleration * timeStep;//Find the new velocity //added wind resistance to the acceleration

                    acceleration = ((-9.8f) - 0.1f * curVelocity);

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
