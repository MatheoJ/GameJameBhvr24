using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum WazoType
{
    Bacon, Jam, Fromage
}

public enum WazoRace
{
    Poulet, Pigeon, Seagle
}

public class WAZO : MonoBehaviour
{
    public float alertDuration = 10f;
    private float alertTimer=0;
    public int alertSpeedMultiplicator = 2;
    public WazoType wazoType= WazoType.Bacon;
    public WazoRace wazoRace = WazoRace.Poulet;

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

    public GameObject PouletBackon;
    public GameObject PouletJam;
    public GameObject PouletFromage;

    public GameObject PigeonBackon;
    public GameObject PigeonJam;
    public GameObject PigeonFromage;

    public GameObject SeagleBackon;
    public GameObject SeagleJam;
    public GameObject SeagleFromage;

    //VFX
    public GameObject DeathBirdVfx;

    public Animator animator;



    // Start is called before the first frame update
    void Start()
    {
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

            if (animator != null)
            {
                animator.speed = 4;
            }
        }
        else
        {
            if (animator != null)
            {
                animator.speed = 1;
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
        GameObject vfxInstance = Instantiate(DeathBirdVfx, transform.position, Quaternion.identity);
        // Destroy the VFX after 2 seconds
        Destroy(vfxInstance, 2.0f);

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
            GameManager.score += 1;
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

    public void SetColor()
    {
        Debug.Log("Setting color");
        Debug.Log(wazoType);
        Debug.Log(Bacon);
        switch (wazoType)
        {            
            case WazoType.Bacon:
                //rendererWazo.material = Bacon;
                // instantiate the prefab pouletBacon as a child of the current object
                if (wazoRace == WazoRace.Poulet)
                {
                    Instantiate(PouletBackon, transform);
                }
                else if (wazoRace == WazoRace.Pigeon)
                {
                    Instantiate(PigeonBackon, transform);
                }
                else if (wazoRace == WazoRace.Seagle)
                {
                    Instantiate(SeagleBackon, transform);
                }              
                break;
            case WazoType.Jam:
                //rendererWazo.material = Jam;
                if (wazoRace == WazoRace.Poulet)
                {
                    Instantiate(PouletJam, transform);
                }
                else if (wazoRace == WazoRace.Pigeon)
                {
                    Instantiate(PigeonJam, transform);
                }
                else if (wazoRace == WazoRace.Seagle)
                {
                    Instantiate(SeagleJam, transform);
                }
                break;
            case WazoType.Fromage:
                //rendererWazo.material = Fromage;
                if (wazoRace == WazoRace.Poulet)
                {
                    Instantiate(PouletFromage, transform);
                }
                else if (wazoRace == WazoRace.Pigeon)
                {
                    Instantiate(PigeonFromage, transform);
                }
                else if (wazoRace == WazoRace.Seagle)
                {
                    Instantiate(SeagleFromage, transform);
                }
                break;
            
            // Get animator in children
            
        }
        animator = GetComponentInChildren<Animator>();
    }
}
