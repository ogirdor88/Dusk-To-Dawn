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
        PlayerPrefs.DeleteKey("FasterDash");
        PlayerPrefs.DeleteKey("FasterKey");
        PlayerPrefs.DeleteKey("GlassTrap");
        PlayerPrefs.DeleteKey("MoreStamina");
        PlayerPrefs.DeleteKey("MoreAmmo");
        PlayerPrefs.DeleteKey("ZombieAmmo");
        PlayerPrefs.DeleteKey("Bullet");
        PlayerPrefs.DeleteKey("Instakill");
        PlayerMovement.health = 100;
        SceneManager.LoadScene("TEMPStartingScreen");
        //GameObject.FindWithTag("Player").SetActive(true);
    }

    public void Exit()
    {
        PlayerPrefs.DeleteKey("FasterDash");
        PlayerPrefs.DeleteKey("FasterKey");
        PlayerPrefs.DeleteKey("GlassTrap");
        PlayerPrefs.DeleteKey("MoreStamina");
        PlayerPrefs.DeleteKey("MoreAmmo");
        PlayerPrefs.DeleteKey("ZombieAmmo");
        PlayerPrefs.DeleteKey("Bullet");
        PlayerPrefs.DeleteKey("Instakill");
        Application.Quit();
    }
}
