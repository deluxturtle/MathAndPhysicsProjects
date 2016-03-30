using UnityEngine;
using System.Collections.Generic;

public class ScriptRocket : MonoBehaviour {

    float mass = 1f;
    float windCoefficient = 0.02f;

    //Create Vectors
    Vector3 rocket = new Vector3(0, 0.02f, 0);
    Vector3 acceleration = new Vector3();
    Vector3 windVector = new Vector3();
    Vector3 thrust = new Vector3(4.321509f, 8.8294f, 1.8343f);
    Vector3 fNet = new Vector3();
    Vector3 velocity = new Vector3();
    Vector3 weight = new Vector3(0, -0.72716f, 0);
    Vector3 emptyVector = new Vector3();

    float curTime = 0.0f;
    float timeStep = 0.1f; //in seconds

    List<Vector3> positions = new List<Vector3>();

    // Use this for initialization
    void Start ()
    {
        positions.Add(rocket);
        ////WhileRocket is Thrusting.
        //do
        //{
        //    //update position vector in all axis.
        //    rocket += velocity * timeStep;

        //    //update velocity vector in all axis.
        //    velocity += acceleration * timeStep;


        //    //Get the wind resistance vector
        //    windVector = velocity * windCoefficient;

        //    //Calculate netforce with thrust - weight - windResistance * velocity
        //    //in each axis.
        //    fNet = thrust + weight - windVector;

        //    acceleration = fNet * (1 / mass);

        //    positions.Add(rocket);
        //    curTime += timeStep;

        //} while (curTime <= 1f);

        ////WhileRocket is Thrusting.
        //do
        //{
        //    //update position vector in all axis.
        //    rocket += velocity * timeStep;

        //    //update velocity vector in all axis.
        //    velocity += acceleration * timeStep;


        //    //Get the wind resistance vector
        //    windVector = velocity * windCoefficient;

        //    //Calculate netforce with thrust - weight - windResistance * velocity
        //    //in each axis.
        //    fNet = weight - windVector;

        //    acceleration = fNet * (1 / mass);

        //    positions.Add(rocket);
        //    curTime += timeStep;
        //} while (rocket.y >= 0);
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        
        if(rocket.y > 0)
        {
            //update position vector in all axis.
            rocket += velocity * Time.deltaTime;

            //update velocity vector in all axis.
            velocity += acceleration * Time.deltaTime;


            //Get the wind resistance vector
            windVector = velocity * windCoefficient;

            if (curTime < 1f)
            {
                //Calculate netforce with thrust - weight - windResistance * velocity
                //in each axis.
                fNet = thrust + weight - windVector;
            }
            else
            {
                //Calculate netforce with thrust - weight - windResistance * velocity
                //in each axis.
                fNet = weight - windVector;
            }

            acceleration = fNet * (1 / mass);
            
            positions.Add(rocket);

            transform.position = rocket;
            curTime += Time.deltaTime;
        }
    }

    void OnDrawGizmos()
    {
        Vector3 start = new Vector3(0, 0.02f, 0);
        Gizmos.color = Color.yellow;
        foreach (Vector3 pos in positions)
        {
            if (curTime >= 1f)
            {
                Gizmos.color = Color.green;
            }
            Gizmos.DrawLine(start, pos);
            start = pos;
        }
    }
}
