using System;
using System.Collections.Generic;
using System.Linq;
using VectorClassLab;

namespace QuaternionLab
{
    /// <summary>
    /// Author: Andrew Seba
    /// Description: 4D rotational helper to rotate 3D objects.
    /// </summary>
    public class Quaternion
    {
        float scaler;
        Vector3D vector;

        /// <summary>
        /// Creates a new Quaternion.
        /// </summary>
        /// <param name="pScaler">Scaler</param>
        /// <param name="pVector">Vector3D</param>
        public Quaternion(float pScaler, Vector3D pVector)
        {
            scaler = pScaler;
            vector = pVector;
        }

        /// <summary>
        /// Adds two quaternions together.
        /// </summary>
        /// <param name="q1">First Quaternion</param>
        /// <param name="q2">Second Quaternion</param>
        /// <returns>New Quaternion</returns>
        public static Quaternion operator +(Quaternion q1, Quaternion q2)
        {
            return new Quaternion(q1.scaler + q2.scaler, q1.vector + q2.vector);
        }

        /// <summary>
        /// Subtract two quaternions.
        /// </summary>
        /// <param name="q1"></param>
        /// <param name="q2"></param>
        /// <returns>New Difference Quaternion.</returns>
        public static Quaternion operator -(Quaternion q1, Quaternion q2)
        {
            return new Quaternion(q1.scaler - q2.scaler, q1.vector - q2.vector);
        }

        /// <summary>
        /// Multiplies a Quaternion by a Scalar
        /// </summary>
        /// <param name="scaler">Scalar first</param>
        /// <param name="q1">Then The Quaternion you want to scale</param>
        /// <returns>New Quaternion</returns>
        public static Quaternion operator &(float scaler, Quaternion q1)
        {
            return new Quaternion(scaler * q1.scaler, q1.vector & scaler);
        }

        /// <summary>
        /// Multiplication of Quaternions
        /// </summary>
        /// <param name="q1">First Quaternion</param>
        /// <param name="q2">then the quaternion we are multiplying by.</param>
        /// <returns>New Quaternion</returns>
        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            return new Quaternion((q1.scaler * q1.scaler) - (q1.vector * q2.vector), (q2.vector & q1.scaler) + (q1.vector & q2.scaler) + q1.vector.Cross(q2.vector));
        }

        /// <summary>
        /// Returns the magnitude of the quaternion
        /// </summary>
        /// <returns>Magnitude Of Quaternion</returns>
        public float getMagnitude()
        {
            
            return (float)Math.Sqrt((scaler * scaler) + (vector.getMagnitude() * vector.getMagnitude()));
        }

        /// <summary>
        /// Returns the Conjugate of the quaternion.
        /// </summary>
        /// <returns>Reverse Vector</returns>
        public Quaternion getConjugate()
        {
            return new Quaternion(scaler, -vector);
        }

        public Quaternion getInverse()
        {
            float magnitude = getMagnitude();
            Quaternion conjugate = getConjugate();
            return (1 / (magnitude * magnitude)) & conjugate;
        }

        public override string ToString()
        {
            return string.Format("[{0:N}, <{1:N}, {2:N}, {3:N}>]",scaler, vector.getX(), vector.getY(), vector.getZ());
        }

    }
}
