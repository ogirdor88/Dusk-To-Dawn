using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTrigger : MonoBehaviour
{
    public event System.Action<Collider> EnteredTrigger;
    public event System.Action<Collider> ExitedTrigger;
    void OnTriggerEnter(Collider other)
    {
        EnteredTrigger?.Invoke(other);
    }

    void OnTriggerExit(Collider other)
    {
        ExitedTrigger?.Invoke(other);
    }
}
