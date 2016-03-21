using System;
using System.IO;
using VectorClassLab;

namespace ForceAndMotionRocket
{
    /// <summary>
    /// @Author: Andrew Seba
    /// @Description: Simulates a rocket path with thrust for the first second
    /// of flight. Outputs a csv file to the output directory.
    /// </summary>
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

            using(StreamWriter writer = new StreamWriter("exRocket_02_wind.csv"))
            {
                writer.WriteLine("Time(s),X(m),Y(m),Z(m)");
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
                    fNet = thrust + weight - windVector;

                    acceleration = fNet & (1 / mass);

                    Console.Write(string.Format("Time: {0:N2}, Pos: ", curTime));
                    rocket.PrintRect();
                    //Write to csv
                    writer.WriteLine(string.Format("{0:N},{1:N},{2:N},{3:N}",
                        curTime, rocket.getX(), rocket.getY(), rocket.getZ()));
                    curTime += timeStep;

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
                    Console.Write(string.Format("Time: {0:N2}, Pos: ", curTime));
                    writer.WriteLine(string.Format("{0:N},{1:N},{2:N},{3:N}",
                        curTime, rocket.getX(), rocket.getY(), rocket.getZ()));
                    rocket.PrintRect();


                    curTime += timeStep;
                } while (rocket.getZ() >= 0);
            }


            Console.ReadKey();
        }
    }
}
