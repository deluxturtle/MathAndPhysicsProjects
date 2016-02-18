using VectorClassLab;
using System;
namespace ProjectionLab
{
    /// <summary>
    /// @Author: Andrew Seba
    /// @Description: Extended Vector3D class to include vector operations.
    /// </summary>
    class Vector3D : VectorClassLab.Vector3D
    {
        const float rad2deg = 57.2957795131f;

        /// <summary>
        /// Addition Operator.
        /// Adds the two input vectors.
        /// </summary>
        /// <param name="Vector to be added too."></param>
        /// <param name="Vector that will be added."></param>
        /// <returns></returns>
        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            //Add each axis seperatly
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
        /// <param name="Vector to be nomralized."></param>
        /// <returns></returns>
        public static Vector3D operator !(Vector3D vector)
        {
            //if magnitude is 0 return an empty vector.
            if(vector.getMagnitude() == 0)
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
        /// <param name="First Vector"></param>
        /// <param name="Second Vector"></param>
        /// <returns></returns>
        public static float operator *(Vector3D v1, Vector3D v2)
        {
            float x = v1.getX() * v2.getX();
            float y = v1.getY() * v2.getY();
            float z = v1.getZ() * v2.getZ();

            return x + y + z;
        }

        /// <summary>
        /// Returns the Angle between two vectors.
        /// </summary>
        /// <param name="First Vector"></param>
        /// <param name="Second Vector"></param>
        /// <returns></returns>
        public static float operator %(Vector3D v1, Vector3D v2)
        {
            if(v1.getMagnitude() > 0 && v2.getMagnitude() > 0)
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
    }
}
