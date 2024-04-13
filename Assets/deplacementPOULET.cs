using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class deplacementPOULET : MonoBehaviour
{
    private NavMeshAgent agent;
    public float maxTime=30.0f;
    public float minDistance = 1.0f;
    float timer = 0;

    public float range=10f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<0 || (transform.position - agent.destination).sqrMagnitude < minDistance * minDistance)
        {
            SetNewDestination();
        }
    }

    public void SetNewDestination()
    {
        if(RandomPoint(new Vector3(Random.Range(-24, 24), 0, Random.Range(-24, 24)), range, out Vector3 result))
        {
            agent.destination = result;
        }
        else
        {
            agent.destination = Vector3.zero;
        }
        
        timer = maxTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Food")
        {
            SetNewDestination();
            agent.speed += 5;
            agent.acceleration += 25;
            agent.angularSpeed += 25;
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
