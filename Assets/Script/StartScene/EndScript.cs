using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndScript : MonoBehaviour
{

    //Start button
    public Button restartButton;
    public Button menuButton;
    public TextMeshProUGUI score;
    public TextMeshProUGUI wave;  


    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(OnStartGame);
        menuButton.onClick.AddListener(OnMenu);
        score.text = GameManager.score.ToString();
        wave.text = GameManager.waveNumber.ToString();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    // This method is called when the start button is clicked
    private void OnStartGame()
    {
        SceneManager.LoadScene("FinalMainScene");
    }
    private void OnMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}