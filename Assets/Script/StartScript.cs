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

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(OnStartGame);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    // This method is called when the start button is clicked
    private void OnStartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}