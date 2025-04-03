using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTrigger : MonoBehaviour
{
    public event System.Action<Collider> EnteredTrigger;
    public event System.Action<Collider> ExitedTrigger;
    public event System.Action<Collider> StayTrigger;
    void OnTriggerEnter(Collider other)
    {
        EnteredTrigger?.Invoke(other);
    }

    void OnTriggerExit(Collider other)
    {
        ExitedTrigger?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        StayTrigger?.Invoke(other);
    }
}
