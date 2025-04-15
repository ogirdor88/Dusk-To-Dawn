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
        Time.timeScale = 1;
        SceneManager.LoadScene("Level One");
    }

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TEMPStartingScreen");
    }
}
