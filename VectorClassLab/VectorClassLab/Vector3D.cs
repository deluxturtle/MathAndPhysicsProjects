﻿using System;

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
        private float w = 1;//Used for later

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
        /// 2D Vector Constructor
        /// </summary>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        public Vector3D(float pX, float pY)
        {
            x = pX;
            y = pY;
            z = 0;
            w = 1;
        }

        /// <summary>
        /// Constructor that will set rect given rect 3D.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public Vector3D(float pX, float pY, float pZ)
        {
            x = pX;
            y = pY;
            z = pZ;
            w = 1;
        }

        /// <summary>
        /// Constructor that will set the new vector with the 4th variable.
        /// </summary>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <param name="pZ"></param>
        /// <param name="pW"></param>
        public Vector3D(float pX, float pY, float pZ, float pW)
        {
            x = pX;
            y = pY;
            z = pZ;
            w = pW;
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
            w = 1;
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
            w = 1;
        }


        /// <summary>
        /// 3D set vector rectangular form by given 4D rectangular input.
        /// </summary>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <param name="pZ"></param>
        /// <param name="pW">w component</param>
        public void SetRectGivenRect(float pX, float pY, float pZ, float pW)
        {
            //Save the rectangular coordinates.
            x = pX;
            y = pY;
            z = pZ;
            w = pW;
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
            Console.WriteLine(string.Format("<{0:N2}, {1:N2}, {2:N2}>",x,y,z));
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

        /// <summary>
        /// Returns the w value.
        /// </summary>
        /// <returns></returns>
        public float getW()
        {
            return w;
        }
        

        /// <summary>
        /// Addition Operator.
        /// Adds the two input vectors.
        /// </summary>
        /// <param name="Vector to be added too."></param>
        /// <param name="Vector that will be added."></param>
        /// <returns></returns>
        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            //Add each axis separately
            float x = v1.getX() + v2.getX();
            float y = v1.getY() + v2.getY();
            float z = v1.getZ() + v2.getZ();

            //Created a new vector that will be returned.
            Vector3D additionVector = new Vector3D();

            //Set the vectors rectangular coordinates.
            additionVector.SetRectGivenRect(x, y, z);

            //Return the addition vector.
            return additionVector;
        }

        /// <summary>
        /// Subtraction Operator.
        /// Subtracts the two input vectors.
        /// </summary>
        /// <param name="Vector that will be subtracted from."></param>
        /// <param name="Vector that will be subtracting."></param>
        /// <returns></returns>
        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            //Subtract each axis seperatly
            float x = v1.getX() - v2.getX();
            float y = v1.getY() - v2.getY();
            float z = v1.getZ() - v2.getZ();

            //Created a new vector that will be returned.
            Vector3D differenceVector = new Vector3D();

            //Set the vector's rectangular coordinates.
            differenceVector.SetRectGivenRect(x, y, z);

            //Return the difference Vector
            return differenceVector;
        }

        public static Vector3D operator -(Vector3D v1)
        {
            return new Vector3D(-v1.x, -v1.y, -v1.z);
        }

        /// <summary>
        /// Scalar Operator.
        /// Scales the vector by a number.
        /// </summary>
        /// <param name="Vector to be scaled."></param>
        /// <param name="The multiplier of the vector."></param>
        /// <returns></returns>
        public static Vector3D operator &(Vector3D vector, float scaler)
        {
            //Multiply each axis by the scaler individualy
            float x = vector.getX() * scaler;
            float y = vector.getY() * scaler;
            float z = vector.getZ() * scaler;

            //Create an empty vector to set it in.
            Vector3D scaledVector = new Vector3D();
            //Now set the new vector by its coordinates.
            scaledVector.SetRectGivenRect(x, y, z);

            //return that scaled vector.
            return scaledVector;
        }

        /// <summary>
        /// Normalize Operator.
        /// Returns a vector with the same direction with magnitude of 1.
        /// </summary>
        /// <param name="vector">Vector to be nomralized.</param>
        /// <returns>Normalized Vector</returns>
        public static Vector3D operator !(Vector3D vector)
        {
            //if magnitude is 0 return an empty vector.
            if (vector.getMagnitude() == 0)
            {
                return new Vector3D();
            }

            //To get the normalized rectangular coordinates we can divide
            //each axis by the magnitude.
            float x = vector.getX() / vector.getMagnitude();
            float y = vector.getY() / vector.getMagnitude();
            float z = vector.getZ() / vector.getMagnitude();

            //Create the new empty vector
            Vector3D normalized = new Vector3D();
            //Set the rect by the axis.
            normalized.SetRectGivenRect(x, y, z);

            //return the normalized vector.
            return normalized;
        }

        /// <summary>
        /// Returns the Dot Product of two vectors.
        /// </summary>
        /// <param name="v1">First Vector</param>
        /// <param name="v2">Second Vector</param>
        /// <returns>Scalar</returns>
        public static float operator *(Vector3D v1, Vector3D v2)
        {
            float x = v1.getX() * v2.getX();
            float y = v1.getY() * v2.getY();
            float z = v1.getZ() * v2.getZ();

            return x + y + z;
        }

        /// <summary>
        /// Returns the dot product for matrix multiplication.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static float Dot4D(Vector3D v1, Vector3D v2)
        {
            float x = v1.getX() * v2.getX();
            float y = v1.getY() * v2.getY();
            float z = v1.getZ() * v2.getZ();
            float w = v1.getW() * v2.getW();

            return x + y + z + w;
        }

        /// <summary>
        /// Returns the Angle between two vectors.
        /// </summary>
        /// <param name="First Vector"></param>
        /// <param name="Second Vector"></param>
        /// <returns></returns>
        public static float operator %(Vector3D v1, Vector3D v2)
        {
            if (v1.getMagnitude() > 0 && v2.getMagnitude() > 0)
            {
                return ((float)Math.Acos((v1 * v2) / v1.getMagnitude() * v2.getMagnitude())) * rad2deg;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Returns the parallel projection of the first vector onto the second
        /// vector
        /// </summary>
        /// <param name="Vector to project."></param>
        /// <param name="Vector to be projected onto."></param>
        /// <returns></returns>
        public static Vector3D operator ^(Vector3D v1, Vector3D v2)
        {
            //Scalar * Vector
            //Create the scalar that we will multiply the vector being projected on by.
            float scalar = v1 * v2 / (v2.getX() * v2.getX() + v2.getY() * v2.getY() + v2.getZ() * v2.getZ());

            //Create the new empty vector.
            Vector3D parallelVector = new Vector3D();
            //Set its coordinates of the projected on vector multiplied by the scalar; 
            parallelVector.SetRectGivenRect(v2.getX() * scalar, v2.getY() * scalar, v2.getZ() * scalar);

            //return the parallel vector.
            return parallelVector;
        }

        /// <summary>
        /// Returns the perpendicular projection of one vector onto another.
        /// </summary>
        /// <param name="Vector to project."></param>
        /// <param name="Vector to be projected onto."></param>
        /// <returns></returns>
        public static Vector3D operator |(Vector3D v1, Vector3D v2)
        {
            //Return the vector subtracted by the parallel projection.
            return v1 - (v1 ^ v2);
        }


        /// <summary>
        /// Calling this function on a vector gives the cross product of the
        /// vector and the parameter vector.
        /// </summary>
        /// <param name="v2"></param>
        /// <returns></returns>
        public Vector3D Cross(Vector3D v2)
        {
            Vector3D u = new Vector3D(getX(), getY(), getZ());
            Vector3D v = new Vector3D(v2.getX(), v2.getY(), v2.getZ());

            //Get the cross product resulting in i j and k
            float i = u.getY() * v.getZ() - v.getY() * u.getZ();
            float j = u.getX() * v.getZ() - v.getX() * u.getZ();
            float k = u.getX() * v.getY() - v.getX() * u.getY();


            Vector3D cross = new Vector3D(i, -j, k);
            return cross;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v2">MovingObject</param>
        /// <param name="v3">Direction</param>
        /// <returns></returns>
        public Vector3D ClosestPointLine(Vector3D v2, Vector3D v3)
        {
            //Get the vector being called on.
            Vector3D ship = new Vector3D(getX(), getY(), getZ());
            //Meteor to Ship
            Vector3D pointOnLineToPoint = ship - v2;

            //add the moving object to the projection of point on line to ship
            //onto the line.
            Vector3D closestPoint = v2 + (pointOnLineToPoint ^ v3);
            return closestPoint;
        }


        /// <summary>
        /// Returns the closest point on a plane to the vector this is
        /// being called on.
        /// </summary>
        /// <param name="v2">normal the plane is facing</param>
        /// <param name="v3">the constant</param>
        /// <returns></returns>
        public Vector3D ClosestPointPlane(Vector3D v2, Vector3D v3)
        {
            //get the vector being called.
            Vector3D ship = new Vector3D(getX(), getY(), getZ());
            //Get the vector pointing from the ship to the point on the plane.
            Vector3D pointOnPlaneToShip = v3 - ship;

            //Get the closest point by projecting onto the normal with the
            //vector pointing from the ship to the plane, and subtracting
            //the ship vector.
            Vector3D closestPoint = ship - (pointOnPlaneToShip ^ v2);


            return closestPoint;
        }


        /// <summary>
        /// Takes in a multi demensional array 4x4 and scales the vertex by 
        /// the matrix.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public Vector3D ScaleByMatrix(float[,] matrix)
        {
            float x, y, z, w;
            //If the matrix doesn't match a scaling matrix demensions return
            //the original vector.
            if (matrix.GetLength(0) != 4 && matrix.GetLength(1) != 4)
            {
                return this;
            }
            else
            {
                x = matrix[0, 0] * this.x + matrix[0, 1] * this.y + matrix[0, 2] * this.z + matrix[0, 3];
                y = matrix[1, 0] * this.x + matrix[1, 1] * this.y + matrix[1, 2] * this.z + matrix[1, 3];
                z = matrix[2, 0] * this.x + matrix[2, 1] * this.y + matrix[2, 2] * this.z + matrix[2, 3];

                return new Vector3D(x, y, z);
            }
        }

        /// <summary>
        /// Scales the vertex by a 4x4 concatenated vector3D array.
        /// </summary>
        /// <param name="matrix">An array of Vector3D objects at length 4</param>
        /// <returns></returns>
        public Vector3D ScaleByMatrix(Vector3D[] matrix)
        {
            float x, y, z, w;

            //If the matrix doesn't match the scaling matrix demensions return
            //the original vector
            if (matrix.Length != 4)
            {
                return this;
            }
            else
            {
                x = matrix[0] * this;
                y = matrix[1] * this;
                z = matrix[2] * this;
                w = matrix[3] * this;
                return new Vector3D(x, y, z, w);
            }
        }

        /// <summary>
        /// Returns the vector given rotated around x by angle.
        /// </summary>
        /// <param name="angle">Angle to rotate</param>
        /// <returns></returns>
        public Vector3D RotateAroundX(float angle)
        {
            float x, y, z, w;

            angle *= deg2rad;

            Vector3D[] rotationMatrix =
            {
                new Vector3D(1, 0, 0, 0),
                new Vector3D(0, (float)Math.Cos(angle), -(float)Math.Sin(angle), 0),
                new Vector3D(0, (float)Math.Sin(angle), (float)Math.Cos(angle), 0),
                new Vector3D(0,0,0,1)
            };

            return ScaleByMatrix(rotationMatrix);
        }

        public Vector3D RotateAroundY(float angle)
        {
            float x, y, z, w;

            angle *= deg2rad;

            Vector3D[] rotationMatrix =
            {
                new Vector3D((float)Math.Cos(angle), 0, (float)Math.Sin(angle), 0),
                new Vector3D(0,1,0,0),
                new Vector3D(-(float)Math.Sin(angle), 0, (float)Math.Cos(angle), 0),
                new Vector3D(0,0,0,1)
            };

            return ScaleByMatrix(rotationMatrix);
        }

        public Vector3D RotateAroundZ(float angle)
        {

            angle *= deg2rad;

            Vector3D[] rotationMatrix =
            {
                new Vector3D((float)Math.Cos(angle), -(float)Math.Sin(angle), 0, 0),
                new Vector3D((float)Math.Sin(angle), (float)Math.Cos(angle), 0,0),
                new Vector3D(0,0,1,0),
                new Vector3D(0,0,0,1)
            };
            
            return ScaleByMatrix(rotationMatrix);
        }
    }
}
