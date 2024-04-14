using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    Canvas canvas;
    public Button resume;
    public Button mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        resume.onClick.AddListener(Resume);
        mainMenu.onClick.AddListener(Menu);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.enabled = !canvas.enabled;
            
        }
        if(canvas.enabled)
        {
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }

    void Resume()
    {
        canvas.enabled = !canvas.enabled;
    }

    private void Menu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
