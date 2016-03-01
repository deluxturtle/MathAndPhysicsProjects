using System;
using VectorClassLab;

namespace ForceAndMotionRocket
{
    class Program
    {
        static void Main(string[] args)
        {
            float mass = 0.0742f; //in kilograms
            float acceleration = 0.0f;

            //Create Vectors
            Vector3D rocket = new Vector3D();
            float windResitance = 0.2f;
            Vector3D thrust = new Vector3D();
            Vector3D fNet = new Vector3D();
            Vector3D velocity = new Vector3D();
            Vector3D weight = new Vector3D();

            //Set initial vector values;
            //Initialize starting point.
            rocket.SetRectGivenRect(0, 0, 0.2f); //in meters.
            thrust.SetRectGivenMagHeadPitch(10, 23, 62);
            //fNet is 0.
            //velocity is 0.
            weight.SetRectGivenMagHeadPitch((mass * 9.8f), 0, -90);


            float curTime = 0.0f;
            float timeStep = 0.1f; //in seconds



            //WhileRocket is Thrusting.
            do
            {
                rocket.PrintRect();

                //update position vector in all axis.
                float tempPosY = rocket.getY() + (velocity.getY() * timeStep);
                float tempPosX = rocket.getX() + (velocity.getX() * timeStep);
                float tempPosZ = rocket.getZ() + (velocity.getZ() * timeStep);
                rocket.SetRectGivenRect(tempPosX, tempPosY, tempPosZ);

                //update velocity vector in all axis.
                float tempVelocityX = velocity.getX() + acceleration * timeStep;
                float tempVelocityY = velocity.getY() + acceleration * timeStep;
                float tempVelocityZ = velocity.getZ() + acceleration * timeStep;

                velocity.SetRectGivenRect(tempVelocityX, tempVelocityY, tempVelocityZ);

                //Calculate netforce with thrust - weight - windResistance * velocity
                //in each axis.
                fNet.SetRectGivenRect(
                    thrust.getX() - weight.getX() - windResitance * velocity.getX(),
                    thrust.getY() - weight.getY() - windResitance * velocity.getY(),
                    thrust.getZ() - weight.getZ() - windResitance * velocity.getZ());

                acceleration = fNet.getMagnitude() / mass;

                curTime += timeStep;
            } while (curTime <= 1f);



            Console.ReadKey();
        }
    }
}
