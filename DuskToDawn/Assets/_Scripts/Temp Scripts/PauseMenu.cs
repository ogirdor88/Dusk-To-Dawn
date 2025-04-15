using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool pauseFlag;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (pauseFlag)
            {
                ResumeTheGame();
            } else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseFlag = true;
    }

    public void ResumeTheGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseFlag = false;
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
