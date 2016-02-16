﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorClassLab
{
    /// <summary>
    /// @Author: Andrew Seba
    /// @Description: Base Vector3D class
    /// </summary>
    public class Vector3D
    {
        //Rectangular vector coordinates
        private float x = 0;
        private float y = 0;
        private float z = 0;
        private float w = 0;//Used for later

        //Conversion values to convert from radians to degrees, and vice versa.
        const float rad2deg = 57.2957795131f;
        const float deg2rad = 0.01745329251f;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Vector3D()
        {
            x = 0;
            y = 0;
            z = 0;
            w = 1;
        }

        /// <summary>
        /// 2D set vector rect by given rect. With 2D rectangular cooridnates.
        /// Ex. < 1, 2 > == where x = 1, and y = 2.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetRectGivenRect(float pX, float pY)
        {
            //Set the rectangular values of the vector to input.
            x = pX;
            y = pY;
            //Set z to 0 because its just a 2D
            z = 0;
        }

        /// <summary>
        /// 3D set vector rectangular form by given 3D rectangular input.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetRectGivenRect(float pX, float pY, float pZ)
        {
            //Save the rectangular coordinates.
            x = pX;
            y = pY;
            z = pZ;
        }

        /// <summary>
        /// 2D from polar to rectangular form.
        /// </summary>
        /// <param name="Magnitude"></param>
        /// <param name="Angle in degrees"></param>
        public void SetRectGivenPolar(float pMagnitude, float pHeading)
        {
            /*If the magnitude is 0 then we can't define x,y,z values from the
            heading.*/
            if (pMagnitude == 0)
            {
                return;
            }

            /*If the heading is 90 degrees or 270 x will be 0.*/
            if (pHeading == 90 || pHeading == 270)
                x = 0;
            /*If not either one of those angles we can get x from the cos of
            the heading input. Also we needed to convert the degrees to radians
            for cosine to work.*/
            else
            {
                x = pMagnitude * (float)Math.Cos(pHeading * deg2rad);
            }

            /*If the heading angle is 180 or 0 then y will be 0.*/
            if (pHeading == 180 || pHeading == 0)
            {
                y = 0;
            }
            /*Else we can get the y value from the sin of the heading angle
            converted to radians.*/
            else
            {
                y = pMagnitude * (float)Math.Sin(pHeading * deg2rad);
            }

            /*z will be zero in this 2D case*/
            z = 0;
        }

        /// <summary>
        /// 3D setting the rectangular form by given Magnitude, Heading, and Pitch.
        /// </summary>
        /// <param name="Magnitude"></param>
        /// <param name="Heading in Degrees"></param>
        /// <param name="Pitch in Degrees"></param>
        public void SetRectGivenMagHeadPitch(float pMagnitude, float pHeading,
            float pPitch)
        {
            if (pMagnitude == 0)
            {
                x = 0;
                y = 0;
                z = 0;
                return;
            }
            /*If the angle is 90 or 270 the x value will be 0.*/
            if (pHeading == 90 || pHeading == 270 || pPitch == 90 || pPitch == -90)
                x = 0;
            /*Else we can calculate the x position by using
            Magnitude * cos(pitch) * cos(heading) */
            else
            {
                x = pMagnitude * (float)Math.Cos(pPitch * deg2rad) * (float)Math.Cos(pHeading * deg2rad);
            }


            if (pHeading == 180 || pHeading == 0 || pPitch == 90 || pPitch == -90)
            {
                y = 0;
            }
            else
            {
                if(x == 0)
                {
                    y = pMagnitude * (float)Math.Cos(pPitch * deg2rad);
                }
                else
                {
                    y = pMagnitude * (float)Math.Cos(pPitch * deg2rad) * (float)Math.Sin(pHeading * deg2rad);
                }
            }
            z = pMagnitude * (float)Math.Sin(pPitch * deg2rad);
        }

        public void PrintRect()
        {
            Console.WriteLine("Rectangular Form: <" + x + ", " + y + ", " + z + ">");
        }

        /// <summary>
        /// Prints the magnitude, heading, and pitch.
        /// </summary>
        public void PrintMagHeadPitch()
        {
            Console.WriteLine("Magnitude: " + getMagnitude() + ", Heading: " + getHeading() + ", Pitch: " + getPitch());
        }

        /// <summary>
        /// Prints alpha, beta, gamma, that the vector makes with the axes.
        /// </summary>
        public void PrintAngles()
        {
            Console.WriteLine("alpha:" + getAlpha() + ", beta:" + getBeta() + ", gamma:" + getGamma());
        }

        /// <summary>
        /// Returns the magnitude of the vector.
        /// </summary>
        /// <returns></returns>
        public float getMagnitude()
        {
            /*Assign the magnitude using the square root of the some of the 
            squared rectangular values.*/
            float magnitude = (float)Math.Sqrt(x * x + y * y + z * z);
            return magnitude;
        }

        /// <summary>
        /// Returns the pitch angle of the vector.
        /// </summary>
        /// <returns></returns>
        public float getPitch()
        {
            /*If the magnitude is greater than 0 and z doesn't equal zero then
             * we can calculate the pitch value.*/
            if(getMagnitude() > 0)
            {
                return ((float)Math.Asin(z / getMagnitude())) * rad2deg;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Returns the heading of the vector.
        /// </summary>
        public float getHeading()
        {
            //if x is 0 the heading degrees will be 0
            if (x == 0)
            {
                return 0f;
            }

            /*
            if x is positive get the heading using arctangent and convert that
            to degrees for the output.*/
            if (x > 0)
            {
                return ((float)Math.Atan(y / x)) * rad2deg;
            }
            /*
            If x is negative add 180 degrees to the output of arctangent then 
            convert the output to degrees.*/
            else if (x < 0)
            {
                return (float)(180 + (Math.Atan(y / x) * rad2deg));
            }
            return 0;
        }
        /// <summary>
        /// Returns the alpha angle.
        /// </summary>
        public float getAlpha()
        {
            if (getMagnitude() > 0)
            {
                return (float)Math.Acos(x / getMagnitude()) * rad2deg;
            }
            return 0;
        }

        /// <summary>
        /// Returns the beta angle.
        /// </summary>
        public float getBeta()
        {
            if (getMagnitude() > 0)
            {
                return (float)Math.Acos(y / getMagnitude()) * rad2deg;
            }
            return 0;
        }

        /// <summary>
        /// Returns the gamma angle.
        /// </summary>
        public float getGamma()
        {
            if (getMagnitude() > 0)
            {
                return (float)Math.Acos(z / getMagnitude()) * rad2deg;
            }
            return 0;
        }

        /// <summary>
        /// Returns the x value.
        /// </summary>
        public float getX()
        {
            return x;
        }

        /// <summary>
        /// Returns the y value.
        /// </summary>
        public float getY()
        {
            return y;
        }

        /// <summary>
        /// Returns the z value.
        /// </summary>
        public float getZ()
        {
            return z;
        }
    }
}
