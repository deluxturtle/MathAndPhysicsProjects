using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorClassLab;

namespace MatrixRotations
{
    class Lab
    {
        // 3D object created in prelab.
        Vector3D[] myObj =
        {
            new Vector3D(3,4,5,1),
            new Vector3D(3,4,8,1),
            new Vector3D(0,6,5,1),
            new Vector3D(0,6,8,1)
        };

        /// <summary>
        /// Starts the laboratory procedures
        /// </summary>
        public void DoLab()
        {

            do
            {
                PrintObj();
                Console.WriteLine("How would you like to transform this object?");
                Console.Write(
                    "1.Translate\n" +
                    "2.Center Scale\n" +
                    "3.Rotate\n");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Translate(myObj);
                        break;
                    case 2:
                        CenterScale(myObj);
                        break;
                    case 3:
                        Rotate(myObj);
                        break;
                }

                Console.Clear();
            } while (true);


        }

        void PrintObj()
        {
            for(int i = 0; i < myObj.Length; i++)
            {
                myObj[i].PrintRect();
            }
        }

        void Rotate(Vector3D[] pObj)
        {
            Console.WriteLine("Rotation: ");
            Console.Write("How much in the x direction? ");
            float xRotation = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("How much in the y direction? ");
            float yRotation = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("How much in the z direction? ");
            float zRotation = (float)Convert.ToDouble(Console.ReadLine());

            for (int i = 0; i < myObj.Length; i++)
            {
                myObj[i] = myObj[i].RotateAroundX(xRotation);
                myObj[i].RotateAroundY(yRotation);
                myObj[i].RotateAroundZ(zRotation);
            }

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
                pObj[i] = pObj[i].ScaleByMatrix(translateMatrix);
            }
        }

    }
}
