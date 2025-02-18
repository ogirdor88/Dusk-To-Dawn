using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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





}
