using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class Experience : MonoBehaviour
{

    public static float currentEXP;
    public static float currentLVL;
    [SerializeField]
    private float maxEXP;
    private float prevLVL;

    [SerializeField]
    private TMP_Text lvlText, expText;


    // Start is called before the first frame update
    void Start()
    {
        prevLVL = currentLVL;
    }

    // Update is called once per frame
    void Update()
    {
        TextUpdate();
        LevelUp();
    }

   private void LevelUp()
    {
        //if the player reaches the level up threshhold or goes over
        //take the exp away from current exp
        //increase the leve
        if(currentEXP >= maxEXP) 
        {
            currentEXP -= maxEXP;
            currentLVL++;
        }

        //if the level has changed
        //increase the amount of exp needed for the next level up
        //set the previous leve to match current level
        if(prevLVL < currentLVL) 
        {
            maxEXP *= 1.1f;
            prevLVL = currentLVL;
        }
 
    }

    private void TextUpdate()
    {
        lvlText.SetText("Level:" + Convert.ToInt32(currentLVL));
        expText.SetText("EXP:" +Convert.ToInt32(currentEXP) + "/" + Convert.ToInt32(maxEXP));
    }
}
