using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    public static int waveNumber = 0;
    public FoodLauncher foodLauncher;
    public float timeLeftForGame = 180;

    private BirdWave currentBirdWave;
    public int birdNumberInCurrentWave;
    public int remainingBirdNumberInCurrentWave;


    public List<GameObject> BirdPrefabList;    

    private struct WaveInfo
    {
        public int BirdNumber;
        public int FoodNumber;
    }

    private List<WaveInfo> waveInfoList = new List<WaveInfo>(new WaveInfo[]
    {
        new WaveInfo { BirdNumber = 6, FoodNumber = 1 },
        new WaveInfo { BirdNumber = 6, FoodNumber = 2 },
        new WaveInfo { BirdNumber = 6, FoodNumber = 3 },
        new WaveInfo { BirdNumber = 9, FoodNumber = 3 },
        new WaveInfo { BirdNumber = 12, FoodNumber = 3 },
        new WaveInfo { BirdNumber = 15, FoodNumber = 3 },
        new WaveInfo { BirdNumber = 18, FoodNumber = 3 },
        new WaveInfo { BirdNumber = 21, FoodNumber = 3 },
        new WaveInfo { BirdNumber = 24, FoodNumber = 3 }
    });


    // Start is called before the first frame update
    void Start()
    {
        foodLauncher.foodNumberUnlocked = 0;
        score = 0;
        waveNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeftForGame <= 0)
        {
            EndGame();
        }
        else{
            if(currentBirdWave == null || currentBirdWave.waveEnded)
            {
                if (currentBirdWave == null)
                {
                    Debug.Log("currentBirdWave is null");
                }

                if (waveNumber < waveInfoList.Count)
                {
                    ChangeWave();
                }
                else
                {
                    EndGame();
                }
            }
            remainingBirdNumberInCurrentWave = currentBirdWave.BirdLeft;
            timeLeftForGame -= Time.deltaTime;
        }
    }

    public void ChangeWave()
    {
        currentBirdWave = gameObject.AddComponent<BirdWave>();
        currentBirdWave.BirdPrefabList = BirdPrefabList;
        Debug.Log("currentBirdWave.BirdPrefabList: "+currentBirdWave.BirdPrefabList.Count);
        currentBirdWave.BirdNumber = waveInfoList[waveNumber].BirdNumber;
        currentBirdWave.FoodNumber = waveInfoList[waveNumber].FoodNumber;
        currentBirdWave.StartWave();
        birdNumberInCurrentWave = waveInfoList[waveNumber].BirdNumber;
        waveNumber++;
        foodLauncher.foodNumberUnlocked++;
    }

    private void EndGame()
    {
        // Debug.Log("Game Over");
        SceneManager.LoadScene("EndScene");
    }
}
