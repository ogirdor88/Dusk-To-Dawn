using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField]
    private float swingSpeed;
    private bool canSwing,resetMelee;

    #region Old
    /*private Vector3 startAngle;
    private Vector3 currentAngle;
    private Vector3 targetAngle = new Vector3(0f, -75f, 0f);
    private bool    canSwing;
*/

    /*private void Awake()
    {
        startAngle = transform.eulerAngles;
        currentAngle = transform.eulerAngles;
        canSwing = true;
    }

    private void Swing()
    {
        if (canSwing)
        {
            Debug.Log("Swinging");
            currentAngle = new Vector3(0, Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime * SwingSpeed), 0);
            
            if(currentAngle.y == targetAngle.y)
            {
                Debug.Log("reset");
                canSwing = false;
                currentAngle.y = startAngle.y;
            }
        }
        
    }

    private void Update()
    {
        transform.position = GameObject.Find("(Temp)Player").transform.position;
        if (Input.GetKeyDown(KeyCode.P))
        {
            canSwing = true;
            Debug.Log("Button");
        }

        Swing();
    }*/
    #endregion

    Transform from;
    public Transform to;
    float timeCount = 0.0f;

    private void Awake()
    {
        from = this.transform;
        canSwing = false;
        resetMelee = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            canSwing = true;
            Debug.Log("Button");
        }
        if(canSwing)
        {
            transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, timeCount * swingSpeed);
            timeCount = timeCount + Time.deltaTime;
            if(from.rotation == to.rotation)
            {
                resetMelee = true;
                if(resetMelee)
                    StartCoroutine(ResetSwing());
            }
        }
    }

    private void BatBack()
    {
        transform.rotation = Quaternion.Lerp(to.rotation, from.rotation, timeCount * swingSpeed);
        timeCount = timeCount + Time.deltaTime;
        canSwing = false;
    }

    private IEnumerator ResetSwing()
    {
        Debug.Log("RESET");
        yield return new WaitForSeconds(.1f);
    }
}
