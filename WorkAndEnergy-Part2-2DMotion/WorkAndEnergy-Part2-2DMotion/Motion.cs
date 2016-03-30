using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorClassLab;

namespace WorkAndEnergy_Part2_2DMotion
{
    /// <summary>
    /// @Author: Andrew Seba
    /// @Description: Simulates the motion of a spacecraft orbiting.
    /// </summary>
    class Motion
    {
        //Earth is centered at 0,0
        Vector3D earthPos = new Vector3D();
        const float negBigG = -6.67E-11f;
        const float earthMass = 5.98E24f;//kg

        public void Start()
        {
            //Mass of the spacecraft.
            float massSpacecraft = 225; //kg
            float altitude;

            //spacecraft initial position.
            Vector3D spacecraft = new Vector3D(0, 6778000); //m
            //Acceleration Vector
            Vector3D acceleration = new Vector3D();
            //Net Force
            Vector3D netForce = new Vector3D();
            //Initial velocity 
            Vector3D velocity = new Vector3D();//km/s
            //Weight Vector
            Vector3D weight = new Vector3D();


            //TimeStep
            float timeStep = 10f; //seconds
            //Start time at 0.
            float curTime = 0;

            //Epsilon amount for gradient calculations.
            float epsilon = 1f;
            Vector3D epsilonX = new Vector3D(epsilon, 0.0f);
            Vector3D epsilonY = new Vector3D(0.0f, epsilon);

            Console.WriteLine("What is the initial velocity? km/s");
            float input = (float)Convert.ToDouble(Console.ReadLine());
            //Set the velocity and convert to meters for calculations.
            velocity.SetRectGivenRect(input * 1000, 0);

            int steps = 5;
            int curStep = 0;
            do
            {
                curStep++;
                spacecraft += velocity & timeStep;
                velocity += acceleration & timeStep;

                //Determine the force components using the gradient of the potential energy
                float forceX = -(PotentialEnergy(spacecraft + epsilonX, massSpacecraft) - PotentialEnergy(spacecraft - epsilonX, massSpacecraft)) / (2.0f * epsilon);
                float forceY = -(PotentialEnergy(spacecraft + epsilonY, massSpacecraft) - PotentialEnergy(spacecraft - epsilonY, massSpacecraft)) / (2.0f * epsilon);

                netForce.SetRectGivenRect(forceX, forceY);
                acceleration = netForce & (1.0f / massSpacecraft);

                altitude = (spacecraft - earthPos).getMagnitude() - 6378000f;

                float potentialEnergy = PotentialEnergy(spacecraft, massSpacecraft);
                float kineticEnergy = (0.5f) * (massSpacecraft * (velocity * velocity));
                float totalEnergy = potentialEnergy + kineticEnergy;
                //float totalPEForce = -(forceX/spacecraft.getX() + forceY/spacecraft.getY());

                Console.WriteLine(string.Format("Vel: {0:N2}km/s, Alt: {1:N2}km, TotalEnergy: {2:N2}J",
                    velocity.getMagnitude() /1000, altitude /1000, totalEnergy));


                curTime += timeStep;
                //if(curStep >= steps)
                //{
                //    curStep = 0;
                //    Console.ReadKey();
                //}
            } while (curTime <= 36000 && (altitude /1000f) > 100);

            Console.ReadKey();
        }

        float PotentialEnergy(Vector3D objPos, float objMass)
        {

            Vector3D distanceFromCenterOfEarth = objPos - earthPos;

            //calculate the gravitation potential energy between the player object and the gravitational Object.
            float PE = negBigG * ((objMass * earthMass) / (distanceFromCenterOfEarth.getMagnitude()));
            return PE;
        }

        //Vector3D CalcWeight(Vector3D objPos, float objMass)
        //{
        //    Vector3D distanceFromEarth = objPos - earthPos;

        //    return negBigG * objMass * earthMass
        //}
    }
}
