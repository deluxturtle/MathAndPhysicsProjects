using System;
using VectorClassLab;
namespace Force_and_Motion
{
    /// <summary>
    /// @Author: Andrew Seba
    /// @Description: box sliding across a floor.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            float timeStep = 0.10f;
            float friction;
            float x = 0;
            float velocity;
            float acceleration;

            float curTime = 0;

            Console.Write("Speed: ");
            velocity = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("Friction: ");
            friction = (float)Convert.ToDouble(Console.ReadLine());

            acceleration = -friction * (9.8f);

            do
            {
                //update position
                x += velocity * timeStep;
                //update velocity
                velocity += acceleration * timeStep;
                //update acceleration.
                Console.WriteLine(string.Format("{0:N2},\t{1:N2}", x ,velocity));
                curTime += timeStep;
            } while (velocity >= 0);

            Console.ReadKey();
        }
    }
}
