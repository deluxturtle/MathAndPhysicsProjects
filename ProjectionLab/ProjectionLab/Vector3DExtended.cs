using VectorClassLab;
namespace ProjectionLab
{
    /// <summary>
    /// @Author: Andrew Seba
    /// @Description: Extended Vector3D class to include vector operations.
    /// </summary>
    class Vector3D : VectorClassLab.Vector3D
    {
        /// <summary>
        /// Adds the two input vectors.
        /// </summary>
        /// <param name="Vector to be added too."></param>
        /// <param name="Vector that will be added."></param>
        /// <returns></returns>
        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            //Created a new vector that will be returned.
            Vector3D additionVector = new Vector3D();

            //Add each axis seperatly
            float x = v1.getX() + v2.getX();
            float y = v1.getY() + v2.getY();
            float z = v1.getZ() + v2.getZ();

            //Set the vectors rectangular coordinates.
            additionVector.SetRectGivenRect(x, y, z);
            
            //Return the addition vector.
            return additionVector;
        }

        /// <summary>
        /// Subtracts the two input vectors.
        /// </summary>
        /// <param name="Vector that will be subtracted from."></param>
        /// <param name="Vector that will be subtracting."></param>
        /// <returns></returns>
        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            //Created a new vector that will be returned.
            Vector3D differenceVector = new Vector3D();

            //Subtract each axis seperatly
            float x = v1.getX() - v2.getX();
            float y = v1.getY() - v2.getY();
            float z = v1.getZ() - v2.getZ();

            //Set the vector's rectangular coordinates.
            differenceVector.SetRectGivenRect(x, y, z);

            //Return the difference Vector
            return differenceVector;
        }
    }
}
