using UnityEngine;
using System.Collections.Generic;

public class ScriptSpaceCraft : MonoBehaviour {


    float negBigG = -6.67E-11f;
    float earthMass = 5.98E24f;

    float mass = 255000;
    Vector3 acceleration;
    public Vector3 velocity;
    public Vector3 netForce;

    float epsilon = 1f;
    Vector3 epsilonX;
    Vector3 epsilonZ;

    float curTime = 0;
    
    public float timeStep = 10;

    float altitude;

    GameObject earth;
    

    List<Vector3> positions = new List<Vector3>();

    void Awake()
    {
        positions.Add(transform.position);
    }

	// Use this for initialization
	void Start ()
    {
        epsilonX = new Vector3(epsilon, 0.0f, 0.0f);
        epsilonZ = new Vector3(0.0f, 0.0f, epsilon);
        positions.Add(transform.position);
        velocity *= 1000f;

        earth = GameObject.Find("Earth");
        
	}
	

    void Update()
    {
        
        Vector3 posMeter = transform.position * 1000f;
        if (Vector3.Distance(Vector3.zero, transform.position) > 6378)
        {
            posMeter += velocity * timeStep;
            velocity += acceleration * timeStep;

            float forceX = -(PotentialEnergy(posMeter + epsilonX, mass) - PotentialEnergy(posMeter - epsilonX, mass)) / (2.0f * epsilon);
            float forceZ = -(PotentialEnergy(posMeter + epsilonZ, mass) - PotentialEnergy(posMeter - epsilonZ, mass)) / (2.0f * epsilon);

            netForce = new Vector3(forceX, 0, forceZ);

            acceleration = netForce * (1.0f / mass);

            altitude = (posMeter - earth.transform.position).magnitude - 6378000f;
            
            if (Vector3.Distance(positions[positions.Count - 1], transform.position) > 100)
            {
                positions.Add(transform.position);
            }
        }

        transform.position = posMeter / 1000;
    }

    float PotentialEnergy(Vector3 objPos, float objMass)
    {
        Vector3 distanceFromEarth = objPos - earth.transform.position;

        double PE = negBigG * ((objMass * earthMass) / (distanceFromEarth.magnitude));
        return (float)PE;
    }

    void OnDrawGizmos()
    {
        if(positions.Count > 1)
        {
            Vector3 start = positions[0];
            Gizmos.color = Color.yellow;
            foreach (Vector3 pos in positions)
            {
                if(pos.magnitude - 6378 <= 100)
                {
                    Gizmos.color = Color.red;
                }
                else
                {
                    Gizmos.color = Color.yellow;
                }
                Gizmos.DrawLine(start, pos);
                start = pos;
            }
        }
    }
}
