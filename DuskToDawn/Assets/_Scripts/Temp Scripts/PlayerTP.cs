using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTP : MonoBehaviour
{
    public GameObject mainplayer;

    public Vector3 spawn2 = new Vector3( -0.121737f, 0.0551838f, 1.068948f);

    public bool flag = true;
    private string sceneName;
    //public int buildInd;

    
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Debug.Log(sceneName);
        //int buildInd = currentScene.buildIndex;
    }
    

    private void Update()
    { 
        if (SceneManager.GetActiveScene().name == "Level Two" && flag == true)
        {
            Debug.Log("HUFHUIEFHUIEFUIH");
            moveThePlayer();
            flag = false;
        }
        /*
        switch (buildInd)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                moveThePlayer();
                break;
            default:
                break;
        }
        */

        /*
        switch (sceneName)
        {
            case "Level Two":
                moveThePlayer();
                break;
            default:
                break;
        }
        */

        /*
        if (flag)
        {
            moveThePlayer();
            flag = false;
            
        }
        */
    }

    private void moveThePlayer()
    {
        mainplayer.GetComponent<Transform>().position = spawn2;
    }

    /*
    IEnumerator checktheScene()
    {
        if (SceneManager.GetActiveScene().name == "Level Two")
        {
           Debug.Log("HUFHUIEFHUIEFUIH");
           flag = true;
        }
    }
    */
}
