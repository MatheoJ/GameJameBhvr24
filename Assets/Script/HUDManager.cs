using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{

    public TMPro.TextMeshProUGUI score;
    public TMPro.TextMeshProUGUI wave;
    public TMPro.TextMeshProUGUI birdLeft;
    public TMPro.TextMeshProUGUI timeLeft;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + GameManager.score;
        wave.text = "Wave: " + GameManager.waveNumber;
        birdLeft.text = "Left: " + gameManager.remainingBirdNumberInCurrentWave+"/"+gameManager.birdNumberInCurrentWave;
        timeLeft.text = ConvertTime(gameManager.timeLeftForGame);
    }

    string ConvertTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
