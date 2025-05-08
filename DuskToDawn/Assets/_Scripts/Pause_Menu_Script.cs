using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu_Script : MonoBehaviour
{
    public GameObject PausePannel;

    // Start is called before the first frame update
    void Start()
    {
        PausePannel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.paused) 
        {
            Pause();
        }
        else
        {
            PausePannel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    // Pauses Game
    public void Pause()
    {
        PausePannel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        PausePannel.SetActive(false);
        PlayerMovement.paused = false;
        Time.timeScale = 1;
        Debug.Log("Click");
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level One");
    }

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TEMPStartingScreen");
    }
}
