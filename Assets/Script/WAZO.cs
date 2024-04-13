using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum WazoType
{
    Bacon,Fromage,Jam
}

public class WAZO : MonoBehaviour
{
    public float alertDuration = 10f;
    private float alertTimer=0;
    public int alertSpeedMultiplicator = 2;
    public WazoType wazoType= WazoType.Bacon;

    private NavMeshAgent agent;
    public float maxTime=30.0f;
    public float minDistance = 1.0f;
    float timer = 0;
    public float range = 10f;

    public bool isAlerted=false;

    private WAZOManager manager;

    public float startingSpeed=7;

    public Material Bacon;
    public Material Jam;
    public Material Fromage;
    private MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer= GetComponent<MeshRenderer>();
        SetColor();
        agent = GetComponent<NavMeshAgent>();
        manager = FindAnyObjectByType<WAZOManager>();
        manager.Enregistrement(this);
        agent.speed = startingSpeed;
        agent.acceleration = startingSpeed*startingSpeed;
        agent.angularSpeed = startingSpeed*100;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (isAlerted)
        {
            alertTimer -= Time.deltaTime;
            if(alertTimer <= 0 )
            {
                isAlerted = false;
                agent.speed /= alertSpeedMultiplicator;
                alertTimer = alertDuration;
            }
        }

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
        if (!other.gameObject.CompareTag(ConvertEnum(wazoType)))
        {
            SetNewDestination();
            Alert();
            manager.Hit(this);
        }
        else
        {
            manager.Hit(this);
            Destroy(this.gameObject);
            
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

    public void Alert()
    {
        if(!isAlerted)
        {
            agent.speed *= alertSpeedMultiplicator;
            agent.acceleration *= alertSpeedMultiplicator * alertSpeedMultiplicator;
            agent.angularSpeed *= alertSpeedMultiplicator * alertSpeedMultiplicator;
            isAlerted = true;
        }
        alertTimer = alertDuration;

    }

    private void OnDestroy()
    {
        manager.Desinscirption(this);
    }

    private string ConvertEnum(WazoType type)
    {
        switch(type)
        {
            case WazoType.Bacon:
                return "Bacon";
            case WazoType.Jam:
                return "Jam";
            case WazoType.Fromage:
                return "Fromage";
            default:
                return "";
        }
    }

    private void SetColor()
    {
        switch (wazoType)
        {
            case WazoType.Bacon:
                renderer.material = Bacon;
                break;
            case WazoType.Jam:
                renderer.material = Jam;
                break;
            case WazoType.Fromage:
                renderer.material = Fromage;
                break;

        }
    }
}
