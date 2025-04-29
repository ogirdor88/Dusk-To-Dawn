using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGardenLevel : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            SceneManager.LoadScene(PlayerPrefs.GetInt("LevelCounter"));
        }
    }



}
