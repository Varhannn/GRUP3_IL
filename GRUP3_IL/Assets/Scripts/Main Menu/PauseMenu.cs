using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public Button closeButton1;
    public Button closeButton2;

    private bool isPaused = false;

    void Start()
    {
        if (closeButton1 != null)
        {
            closeButton1.onClick.AddListener(ResumeGame);
        }
        if (closeButton2 != null)
        {
            closeButton2.onClick.AddListener(ResumeGame);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        settingsMenu.SetActive(true); 
        Time.timeScale = 0f; 
        isPaused = true;
    }

    public void ResumeGame()
    {
        settingsMenu.SetActive(false); 
        Time.timeScale = 1f; 
        isPaused = false;
    }
}
