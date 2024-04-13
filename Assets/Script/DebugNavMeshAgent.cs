using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DebugNavMeshAgent : MonoBehaviour
{
    public bool velocity;
    public bool desiredVelocity;
    public bool path;
    public bool alertRange;

    NavMeshAgent agent;
    WAZO wazo;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wazo= GetComponent<WAZO>();
    }

    // Update is called once per frame
    void OnDrawGizmos()
    {
        if (velocity)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position+agent.velocity);
        }
        if (velocity)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + agent.desiredVelocity);
        }
        if (path)
        {
            Gizmos.color = Color.black;
            var agentpath = agent.path;
            Vector3 prevCorner = transform.position;
            foreach(var corner in agentpath.corners)
            {
                Gizmos.DrawLine(prevCorner, corner);
                Gizmos.DrawSphere(corner, 0.1f);
                prevCorner= corner;
            }
            
        }
        if (alertRange)
        {
            if (wazo.isAlerted)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(transform.position, 5);
            }

            else
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawSphere(transform.position, 5);
            }
            
        }





    }
}
