using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingScreenUI : MonoBehaviour
{
    public GameObject infoPanel;
    //public List<GameObject> InfoPanels = new List<GameObject>();

    public void Playgame()
    {
        PlayerMovement.health = 100;
        //PlayerMovement. = 100;
        Experience.currentEXP = 0;
        Experience.currentLVL = 0;
        Experience.maxEXP = 5;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BringUpInfo()
    {
        infoPanel.SetActive(true);
    }

    public void CloseInfo()
    {
        infoPanel.SetActive(false);
    }

    public void thequitbutton()
    {
        Application.Quit();
        PlayerPrefs.DeleteAll();
    }

}
