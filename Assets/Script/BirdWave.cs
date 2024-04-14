using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class BirdWave : MonoBehaviour
{
    public int BirdNumber = 1;
    public int FoodNumber = 1;

    public int BirdLeft = 0;

    public List<GameObject> BirdPrefabList;
    public List<GameObject> BirdList = new List<GameObject>();

    public bool waveEnded = false;
    public bool waveRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waveRunning)
        {
            //Count the number of birds left
            BirdLeft = 0;
            foreach (var bird in BirdList)
            {
                if (bird != null)
                {
                    BirdLeft++;
                }
            }
            if (BirdLeft == 0)
            {
                EndWave();
            }
        }
    }

    public void StartWave()
    {
        Debug.Log("StartWave : " + FoodNumber);
        for (int i = 0; i < BirdNumber; i++)
        {
            //Instantiate a bird and add it to the list
            float range = 10f;
            RandomPoint(new Vector3(Random.Range(-24, 24), 0, Random.Range(-24, 24)), range, out Vector3 result);
            GameObject bird = Instantiate(BirdPrefabList[Random.Range(0, BirdPrefabList.Count)], result, Quaternion.identity);
            //Chose randomly the type of the bird
            int rangeType = Mathf.Min(FoodNumber, 3);
            bird.GetComponent<WAZO>().wazoType = (WazoType)Random.Range(0, rangeType);
            bird.GetComponent<WAZO>().wazoRace = (WazoRace)Random.Range(0, 3);
            bird.GetComponent<WAZO>().SetColor();

            BirdList.Add(bird);
        }
        BirdLeft = BirdNumber;
        waveRunning = true;
    }
    public void EndWave()
    {
        foreach (var bird in BirdList)
        {
            Destroy(bird);
        }
        BirdList.Clear();
        waveRunning = false;
        waveEnded = true;
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
