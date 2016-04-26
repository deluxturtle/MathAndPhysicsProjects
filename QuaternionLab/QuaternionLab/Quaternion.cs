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
    class Quaternion
    {
        float scaler;
        Vector3D vector;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pScaler">Scaler</param>
        /// <param name="pVector">Vector3D</param>
        public Quaternion(float pScaler, Vector3D pVector)
        {
            scaler = pScaler;
            vector = pVector;
        }

        public static Quaternion operator +(Quaternion q1, Quaternion q2)
        {
            return new Quaternion(q1.scaler + q2.scaler, q1.vector + q2.vector);
        }

        public static Quaternion operator &(float scaler, Quaternion q1)
        {
            return new Quaternion(scaler * q1.scaler, q1.vector & scaler);
        }

        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            return new Quaternion((q1.scaler * q1.scaler) - (q1.vector * q2.vector), (q2.vector & q1.scaler) + (q1.vector & q2.scaler) + q1.vector.Cross(q2.vector));
        }

        public float getMagnitude()
        {
            return (float)Math.Sqrt((scaler * scaler) + (vector.getMagnitude() * vector.getMagnitude()));
        }

        public Quaternion getConjugate()
        {
            return new Quaternion(scaler, -vector);
        }

        public Quaternion getInverse()
        {
            return (1 / (getMagnitude() * getMagnitude())) & getInverse();
        }

    }
}
