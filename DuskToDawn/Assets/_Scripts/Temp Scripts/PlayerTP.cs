using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTP : MonoBehaviour
{
    [TextArea]
    public string Notes = "Teleport to right positions";

    public GameObject mainplayer;
    //public GameObject PlayerCanvasThing;

    public Vector3 spawn1 = new Vector3();
    public Vector3 spawn2 = new Vector3();
    public Vector3 spawn3 = new Vector3();
    public Vector3 spawn4 = new Vector3();
    public Vector3 Gardenspawn = new Vector3();

    public static bool level1flag = false;
    public bool flag = true;
    public bool flag2 = true;
    public bool flag3 = true;
    public bool gardenflag = true;
    //public bool saygeronimo;
    private string sceneName;
    public bool randomleveltime;


    private void Awake()
    {
        PlayerPrefs.SetInt("LevelCounter", 2);
    }


    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level One" && level1flag == true)
        {
            Debug.Log("level1testing");
            movePlayerLVL1();
            level1flag = false; gardenflag = true; flag = true; flag2 = true; flag3 = true;
            PlayerPrefs.SetInt("LevelCounter", 2);
        }

        if (SceneManager.GetActiveScene().name == "Garden" && gardenflag == true)
        {
            Debug.Log("level1testing");
            movePlayerGarden();
            gardenflag = false;
            flag = true; flag2 = true; flag3 = true; level1flag = true;
            if (randomleveltime)
            {
                PlayerPrefs.SetInt("LevelCounter", Random.Range(1, 4));
            }
            //int templvlc = PlayerPrefs.GetInt("LevelCounter");
            //templvlc++;
            //PlayerPrefs.SetInt("LevelCounter", 2);
        }

        if (SceneManager.GetActiveScene().name == "Level Two" && flag == true)
        {
            Debug.Log("HUFHUIEFHUIEFUIH");
            movePlayerLVL2();
            flag = false; gardenflag = true; flag2= true; flag3 = true; level1flag = true;
            PlayerPrefs.SetInt("LevelCounter", 3);
        }

        if (SceneManager.GetActiveScene().name == "Level Three" && flag2 == true)
        {
            Debug.Log("HUFHUIEFHUIEFUIH");
            movePlayerLVL3();
            flag2 = false; gardenflag = true; flag = true; flag3 = true; level1flag = true;
            PlayerPrefs.SetInt("LevelCounter", 4);
        }

        if (SceneManager.GetActiveScene().name == "Level Four" && flag3 == true)
        {
            Debug.Log("HUFHUIEFHUIEFUIH");
            movePlayerLVL4();
            flag3 = false; gardenflag = true; flag = true; flag2 = true; level1flag = true;
            randomleveltime = true;
            //PlayerPrefs.SetInt("LevelCounter", Random.Range(1, 4));
        }

        
        if (SceneManager.GetActiveScene().name == "Game_Over_Scene")
        {
            mainplayer.GetComponent<PlayerMovement>().enabled = false;
        }

        if (SceneManager.GetActiveScene().name == "Level One")
        {
            mainplayer.GetComponent<PlayerMovement>().enabled = true;
        }
        
    }

    private void movePlayerLVL1()
    {
        //mainplayer.GetComponent<Transform>().position = spawn2;
        mainplayer.transform.position = spawn1;
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

    private void movePlayerGarden()
    {
        //mainplayer.GetComponent<Transform>().position = spawn2;
        mainplayer.transform.position = Gardenspawn;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("LevelCounter");
    }
}
