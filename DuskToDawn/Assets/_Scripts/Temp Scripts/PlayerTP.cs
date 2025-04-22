using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTP : MonoBehaviour
{
    public GameObject mainplayer;

    public Vector3 spawn2 = new Vector3();
    public Vector3 spawn3 = new Vector3();
    public Vector3 spawn4 = new Vector3();


    public static bool flag = true;
    public static bool flag2 = true;
    public static bool flag3 = true;
    public bool saygeronimo;
    private string sceneName;


    private void Awake()
    {
        
    }


    private void Update()
    { 
        if (SceneManager.GetActiveScene().name == "Level Two" && flag == true)
        {
            Debug.Log("HUFHUIEFHUIEFUIH");
            movePlayerLVL2();
            flag = false;
        }

        if (SceneManager.GetActiveScene().name == "Level Three" && flag2 == true)
        {
            Debug.Log("HUFHUIEFHUIEFUIH");
            movePlayerLVL3();
            flag2 = false;
        }

        if (SceneManager.GetActiveScene().name == "Level Four" && flag3 == true)
        {
            Debug.Log("HUFHUIEFHUIEFUIH");
            movePlayerLVL4();
            flag3 = false;
        }


    }

    private void movePlayerLVL2()
    {
        //mainplayer.GetComponent<Transform>().position = spawn2;
        mainplayer.transform.position = spawn2;
    }

    private void movePlayerLVL3()
    {
        //mainplayer.GetComponent<Transform>().position = spawn2;
        mainplayer.transform.position = spawn3;
    }

    private void movePlayerLVL4()
    {
        //mainplayer.GetComponent<Transform>().position = spawn2;
        mainplayer.transform.position = spawn4;
    }


}
