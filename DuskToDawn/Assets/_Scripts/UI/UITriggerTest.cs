using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UITriggerTest : MonoBehaviour
{
    [SerializeField]
    private bool testb, testpause, testpauseoff;

    [SerializeField]
    private GameObject pausecanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)){
            UIManager.Instance.turnPauseMenuON(pausecanvas);
        }
    }

}