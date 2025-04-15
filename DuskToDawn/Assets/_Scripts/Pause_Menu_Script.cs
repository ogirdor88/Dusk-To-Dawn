using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu_Script : MonoBehaviour
{
    public GameObject PausePannel;
    public GameObject VolumePannel;

    // Start is called before the first frame update
    void Start()
    {
        PausePannel.SetActive(false);
        VolumePannel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            Pause();
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
        Time.timeScale = 1;
    }

    public void Volume()
    {
        VolumePannel.SetActive(true);
    }

    public void Back()
    {
        VolumePannel.SetActive(false);
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
