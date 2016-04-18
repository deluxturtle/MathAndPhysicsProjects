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

        /// <summary>
        /// Entry point for the lab (Starts the menu)
        /// </summary>
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
                        RawScale(obj);
                        break;
                    case 3:
                        CenterScale(obj);
                        break;


                }

                Console.WriteLine("Enter to transform the original object again.");
                Console.ReadKey();
                Console.Clear();
            } while (true);


        }

        /// <summary>
        /// Takes input from  user about how much to scale in each direction and
        /// then calculates the center then uses the concatenated matrix to
        /// manipulate transform the objects vertices.
        /// </summary>
        /// <param name="pObj"></param>
        void CenterScale(Vector3D[] pObj)
        {

            float centerX, centerY, centerZ;
            centerZ = centerY = centerX = 0;

            Console.WriteLine("Center Scaling: ");
            Console.Write("How much in the x direction? ");
            float xScale = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("How much in the y direction? ");
            float yScale = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("How much in the z direction? ");
            float zScale = (float)Convert.ToDouble(Console.ReadLine());


            //Get the sum of all the vertices
            for (int i = 0; i < pObj.Length; i++)
            {
                centerX += pObj[i].getX();
                centerY += pObj[i].getY();
                centerZ += pObj[i].getZ();
            }

            //Get the center
            centerX /= pObj.Length;
            centerY /= pObj.Length;
            centerZ /= pObj.Length;
            

            Vector3D[] matrix =
            {
                new Vector3D(xScale, 0, 0, centerX * (1 - xScale)),
                new Vector3D(0, yScale, 0, centerY * (1 - yScale)),
                new Vector3D(0, 0, zScale, centerZ * (1 - zScale)),
                new Vector3D(0, 0, 0, 1 )

            };

            for (int i = 0; i < pObj.Length; i++)
            {
                pObj[i] = pObj[i].ScaleByMatrix(matrix);
                pObj[i].PrintRect();
            }

        }

        /// <summary>
        /// Gets input from the user about how much to scale the object and uses
        /// a 4x4 matrix to scale the objects vertices.
        /// </summary>
        /// <param name="pObj"></param>
        void RawScale(Vector3D[] pObj)
        {
            Console.WriteLine("RawScale:");
            Console.Write("How much in the x direction? ");
            float xScale = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("How much in the y direction? ");
            float yScale = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("How much in the z direction? ");
            float zScale = (float)Convert.ToDouble(Console.ReadLine());

            //float[,] rawScaleMatrix =
            //{
            //    {xScale, 0, 0, 0 },
            //    {0, yScale, 0, 0 },
            //    {0, 0, zScale, 0 },
            //    {0, 0, 0, 1 }
            //};

            Vector3D[] rawScaleMatrix =
            {
                new Vector3D(xScale, 0, 0, 0),
                new Vector3D(0, yScale, 0, 0),
                new Vector3D(0, 0, zScale, 0),
                new Vector3D(0, 0, 0, 1)

            };

            //Create a new object for printing so we don't modify the original
            Vector3D[] newObj = pObj;

            for (int i = 0; i < pObj.Length; i++)
            {
                newObj[i] = pObj[i].ScaleByMatrix(rawScaleMatrix);
                newObj[i].PrintRect();
            }


        }

        /// <summary>
        /// Translates the object's vertices by adding the user given changes
        /// in axis.
        /// </summary>
        /// <param name="pObj"></param>
        void Translate(Vector3D[] pObj)
        {
            Console.WriteLine("Translate:");
            Console.Write("How much in the x direction? ");
            float xTranslate = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("How much in the y direction? ");
            float yTranslate = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("How much in the z direction? ");
            float zTranslate = (float)Convert.ToDouble(Console.ReadLine());
            

            Vector3D[] translateMatrix =
            {
                new Vector3D(1,0,0,xTranslate),
                new Vector3D(0,1,0,yTranslate),
                new Vector3D(0,0,1,zTranslate),
                new Vector3D(0,0,0,1)
            };

            //Create a new object for printing so we don't modify the original
            Vector3D[] newObj = pObj;

            for (int i = 0; i < pObj.Length; i++)
            {
                newObj[i] = pObj[i].ScaleByMatrix(translateMatrix);
                newObj[i].PrintRect();
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
