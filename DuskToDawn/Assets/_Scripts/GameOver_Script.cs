using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Script : MonoBehaviour
{
    public GameObject GameOverPannel;
    // Start is called before the first frame update
    void Start()
    {
        GameOverPannel.SetActive(true);
    }

    public void Restart()
    {
        PlayerTP.level1flag = true;
        Time.timeScale = 1;
        PlayerPrefs.DeleteAll();
        PlayerMovement.health = 100;
        SceneManager.LoadScene("TEMPStartingScreen");
        //GameObject.FindWithTag("Player").SetActive(true);
    }

    public void Exit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
