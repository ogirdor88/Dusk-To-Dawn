using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField]
    private bool low, mid, high;

    public float healing;

    private void Update()
    {
        if (low)
        {
            mid =false;
            high = false;
            healing = 10;
        }
        if (mid) 
        {
            low = false;
            high = false;
            healing = 20;
        }
        if (high)
        {
            low = false;
            mid = false;
            healing = 30;
        }
    }
}
