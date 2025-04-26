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
        PlayerMovement.health = 100;
        SceneManager.LoadScene("Level One");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
