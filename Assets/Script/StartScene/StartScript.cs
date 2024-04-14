using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartManager : MonoBehaviour
{

    //Start button
    public Button startButton;
    public Button settingsButton;
    public Button rulesButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(OnStartGame);
        settingsButton.onClick.AddListener(OnSettings);
        rulesButton.onClick.AddListener(OnRules);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    // This method is called when the start button is clicked
    private void OnStartGame()
    {
        SceneManager.LoadScene("PlayerControlTest");
    }
    private void OnSettings()
    {
        SceneManager.LoadScene("Settings");
    }
    private void OnRules()
    {
        SceneManager.LoadScene("Rules");
    }
}