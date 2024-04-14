using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SettingsScript : MonoBehaviour
{

    //Start button
    public Button startButton;
    public Button creditsButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(OnStartGame);
        creditsButton.onClick.AddListener(OnCredits);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    // This method is called when the start button is clicked
    private void OnStartGame()
    {
        Application.Quit();
        //SceneManager.LoadScene("StartScene");
    }
    private void OnCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }
    private void OnRules()
    {
        SceneManager.LoadScene("Rules");
    }
}