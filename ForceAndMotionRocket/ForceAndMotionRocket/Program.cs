using System;
using VectorClassLab;

namespace ForceAndMotionRocket
{
    class Program
    {
        static void Main(string[] args)
        {
            float mass = 0.0742f; //in kilograms
            float windCoefficient = 0.02f;

            //Create Vectors
            Vector3D rocket = new Vector3D();
            Vector3D acceleration = new Vector3D();
            Vector3D windVector = new Vector3D();
            Vector3D thrust = new Vector3D();
            Vector3D fNet = new Vector3D();
            Vector3D velocity = new Vector3D();
            Vector3D weight = new Vector3D();
            Vector3D emptyVector = new Vector3D();

            //Set initial vector values;
            //Initialize starting point.
            rocket.SetRectGivenRect(0, 0, 0.2f); //in meters.
            //Thrust is 10 Newtons at 23 heading and 62 pitch.
            thrust.SetRectGivenMagHeadPitch(10, 23, 62);
            //fNet is 0.
            //velocity is 0.
            //Weight is straight down and mass * gravity
            weight.SetRectGivenMagHeadPitch((mass * 9.8f), 0, -90);
            //Acceleration is 0.

            float curTime = 0.0f;
            float timeStep = 0.1f; //in seconds


            //WhileRocket is Thrusting.
            do
            {
                //update position vector in all axis.
                rocket += rocket + velocity & timeStep;

                //update velocity vector in all axis.
                velocity += velocity + acceleration & timeStep;


                //Get the wind resistance vector
                windVector = velocity & windCoefficient;

                //Calculate netforce with thrust - weight - windResistance * velocity
                //in each axis.
                fNet = thrust + weight - windVector;

                acceleration = fNet & (1 / mass);

                curTime += timeStep;

                rocket.PrintRect();
            } while (curTime <= 1f);



            //WhileRocket is Thrusting.
            do
            {
                //update position vector in all axis.
                rocket += velocity & timeStep;

                //update velocity vector in all axis.
                velocity += acceleration & timeStep;


                //Get the wind resistance vector
                windVector = velocity & windCoefficient;

                //Calculate netforce with thrust - weight - windResistance * velocity
                //in each axis.
                fNet = weight - windVector;

                acceleration = fNet & (1 / mass);

                curTime += timeStep;
                rocket.PrintRect();
            } while (rocket.getZ() >= 0);

            Console.ReadKey();
        }
    }
}
