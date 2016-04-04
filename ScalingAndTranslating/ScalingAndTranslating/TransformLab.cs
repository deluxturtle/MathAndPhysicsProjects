using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorClassLab;

namespace ScalingAndTranslating
{
    /// <summary>
    /// @Author: Andrew Seba
    /// @Description: Translates an object by user defined properties.
    /// </summary>
    class TransformLab
    {


        public void Start()
        {
            Console.Write("How many vertices is your object? ");
            int numVerts = Convert.ToInt32(Console.ReadLine());
            Vector3D[] obj = new Vector3D[numVerts];

            //Get all the verticess
            for(int i = 0; i < numVerts; i++)
            {
                Console.WriteLine("Vertex " + (i + 1));
                obj[i] = GetVertex();
            }

            do
            {
                Console.WriteLine("How would you like to transform?");
                Console.Write(
                    "1.Translate\n" +
                    "2.Raw Scale\n" +
                    "3.Center Scale\n");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Translate(obj);
                        break;
                    case 2:
                        RawScale();
                        break;
                    case 3:
                        CenterScale();
                        break;


                }

                Console.WriteLine("Enter to transform the original object again.");
                Console.ReadKey();
                Console.Clear();
            } while (true);


        }

        void CenterScale()
        {

        }

        void RawScale()
        {

        }

        void Translate(Vector3D[] pObj)
        {
            Console.Write("How much in the x direction? ");
            float xTranslate = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("How much in the y direction? ");
            float yTranslate = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("How much in the z direction? ");
            float zTranslate = (float)Convert.ToDouble(Console.ReadLine());

            for(int i = 0; i < pObj.Length; i++)
            {
                pObj[i].SetRectGivenRect(
                    pObj[i].getX() + xTranslate,
                    pObj[i].getY() + yTranslate,
                    pObj[i].getZ() + zTranslate);
            }



        }


        /// <summary>
        /// Gets a vertex from the user and returns a vector object.
        /// </summary>
        Vector3D GetVertex()
        {
            Console.Write("x: ");
            float x = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("y: ");
            float y = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("z: ");
            float z = (float)Convert.ToDouble(Console.ReadLine());

            Vector3D vertex = new Vector3D(x, y, z);
            return vertex;
        }
    }
}
