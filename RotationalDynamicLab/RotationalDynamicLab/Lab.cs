using System;
using System.IO;
using VectorClassLab;

namespace RotationalDynamicLab
{
    /// <summary>
    /// Author: Andrew Seba
    /// Description: Rotational Dynamics Lab
    /// </summary>
    class Lab
    {
        public void Start()
        {
            const float rad2deg = 57.2957795131f;//Conversion from radians to degrees.

            float mass1;//kg
            float mass2;//kg
            float totalMass;//kg
            float radius;//m
            float radius1;//m
            float radius2;//m
            float force;//N
            float momentOfInertia;//kg m^2
            float angPosition = 0;//rad
            float angVelocity = 0;// rad/s
            float angAcceleration = 0;// rad/s^2
            float torque;//N m

            float curTime = 0.0f; //Time counter in seconds.
            float timeStep = 0.01f; // (1/10)th of a second increments.
            float endTime;


            //Center of mass position.
            Vector3D pos = new Vector3D();
            //Small mass position
            Vector3D r1 = new Vector3D();
            Vector3D velocity = new Vector3D();// m/s
            Vector3D acceleration = new Vector3D();// m/s^2
            Vector3D forceVector = new Vector3D();// N
            Vector3D fNet = new Vector3D();// Sum of N



            radius = 0.35f;//m
            mass1 = 1.20f;//kg
            mass2 = 4.90f;//kg
            totalMass = mass1 + mass2; //kg

            //position is the center of mass calculated by
            //  (m1)(x1) + (m2)(x2) + etc...
            //         divided by
            //       m1 + m2 + etc...
            pos = new Vector3D(((mass2 * radius) / totalMass), 0);

            //radius1 is the first half so just the distance from 0
            radius1 = pos.getX();
            //radius2 is the second half of the radius so just minus the radius 1 from the total radius.
            radius2 = radius - radius1;

            //Get force from the user in Newtons.
            Console.WriteLine("How much force is going to be applied in Newtons?");
            force = (float)Convert.ToDouble(Console.ReadLine()); //N

            //Calculate our force vector from our input.
            forceVector.SetRectGivenPolar(force, 30);

            //Get how much time to simulate in seconds.
            Console.WriteLine("How much time to simulate in seconds?");
            endTime = (float)Convert.ToDouble(Console.ReadLine());
            
            //Sum of the mass * distance ^2 is the moment of inertia.
            momentOfInertia = (mass1 * (radius1 * radius1)) + (mass2 * (radius2 * radius2));

            //Display our Objects Info
            Console.WriteLine("I: " + momentOfInertia + " kg m^2");
            Console.WriteLine(string.Format("F = <{0},{1}>N", forceVector.getX(), forceVector.getY()));
            Console.WriteLine("Xcm = " + pos.getX());

            //Wait for input
            Console.ReadLine();

            //set the position of the object to the origin of the world.
            pos -= new Vector3D(radius1, 0);
            r1 = new Vector3D(-radius1, 0);

            //This is constant so calculate it outside of the loop.
            acceleration = forceVector & (1 / totalMass);

            using (StreamWriter writer = new StreamWriter("rotationalDyn_2N_2S_0-01TS.csv"))
            {
                writer.WriteLine("Time(s),r1 x(m),r1 y(m),cm x(m),cm y(m),Angle(Degrees)");


                do
                {
                    //LINEAR MOTION
                    //update position vector
                    pos += velocity & timeStep;
                    //update velocity
                    velocity += acceleration & timeStep;

                    //ANGULAR MOTION
                    //Update torque.
                    torque = r1.Cross(forceVector).getZ();
                    //Update angular position.
                    angPosition += angVelocity * timeStep;
                    //Update velocity.
                    angVelocity += angAcceleration * timeStep;
                    //Update acceleration. //Just used the torque as a scalar instead of the .z component of the vector.
                    angAcceleration = torque / momentOfInertia;

                    //Update small mass position.
                    r1.SetRectGivenPolar(-radius1, angPosition * rad2deg);

                    //Increment time step.
                    curTime += timeStep;
                    Console.WriteLine(string.Format("r1 <{0:N},{1:N}>\tpos <{2:N},{3:N}>\tAngle {4:N}", r1.getX(), r1.getY(), pos.getX(), pos.getY(), angPosition * rad2deg));
                    writer.WriteLine(string.Format("{0},{1:N},{2:N},{3:N},{4:N},{5:N}",
                        curTime, r1.getX(), r1.getY(), pos.getX(), pos.getY(), angPosition * rad2deg));
                } while (curTime <= endTime);
            }
            Console.ReadLine();
        }
    }
}

//velocity changes
//r1 direction changes
//torque changes r1 cross f
//angle is changing
//angular velocity will
//angular acceleration will change.
//angular acceleration = torque.z/moment of inertia