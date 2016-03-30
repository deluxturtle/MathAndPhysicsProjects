using System;

namespace WorkAndEnergyLabPart1
{

    /// <summary>
    /// @Author: Andrew Seba
    /// @Description:First part of the lab 
    /// </summary>
    class MarbleLab
    {
        float mass = 0.050f;
        float velocity = 0.0f;
        float acceleration;
        float position;
        float timeStep = 0.01f;

        float fNet;

        float potentialEnergy = 0;
        float kineticEnergy;
        float totalEnergy;

        float epsilon = 0.0001f;

        /// <summary>
        /// Entry point for the lab (starts the simulation)
        /// </summary>
        public void Start()
        {
            Console.Write("Starting Position: ");
            position = (float)Convert.ToDouble(Console.ReadLine());

            float curTime = 0.0f;
            acceleration = -9.8f;

            do
            {
                //Update Position
                position += velocity * timeStep;

                //Update velocity
                velocity += acceleration * timeStep;

                //Calculate a base potential energy value for printing.
                potentialEnergy = 0.175f * position * position;
                //Get a kinetic energy value for printing
                kineticEnergy = (0.5f) * (mass * (velocity * velocity));
                //Calculate a total energy 
                totalEnergy = potentialEnergy + kineticEnergy;

                //Net Force calculation using epsilon for a gradient we can get the direction of the force.
                fNet = -((PotentialEnergy(position + epsilon) - PotentialEnergy(position - epsilon)) / (2.0f * epsilon));
                //Acceleration is based of the net force and mass
                acceleration = fNet * (1.0f / mass);

                Console.WriteLine(string.Format("Pos:{0:N2}, PE:{1:N2}, KE:{2:N2}, Total:{3:N2}", position, potentialEnergy, kineticEnergy, totalEnergy));

                curTime += timeStep;
            } while (curTime <= 3f);

            Console.ReadKey();
        }

        /// <summary>
        /// Calculates the potential energy based on the position.
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        float PotentialEnergy(float pos)
        {
            //Potential energy function of the parabola
            float PE = 0.175f * (pos * pos);
            //Console.WriteLine(string.Format(" pe: {0}J", PE));

            return PE;

        }
    }
}
