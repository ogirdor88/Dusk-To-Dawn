using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
           Instance = this;

        } else
        {
            Destroy(gameObject);
        }
    }

    public GameObject pauseMenu;

    public void AddScore()
    {
        Debug.Log("Test");
    }

    public void turnPauseMenuON(GameObject UI_pc)
    {
        UI_pc.SetActive(true);
    }

    public void turnPauseMenuOFF(GameObject UI_pc)
    {
        UI_pc.SetActive(false);
    }

    public void restartLevelButton()
    {
        SceneManager.LoadScene(1);
    }


    public void optionsLevelButton(GameObject UI_op)
    {
        UI_op.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void optionBack(GameObject UI_op)
    {
        pauseMenu.SetActive(true);
        UI_op.SetActive(false);
    }


}
