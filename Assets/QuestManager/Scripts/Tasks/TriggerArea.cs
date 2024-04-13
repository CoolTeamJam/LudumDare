using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TriggerArea : MonoBehaviour
{
    public bool bIsTriggered { get; protected set; } = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement player))
        {
            bIsTriggered = true;
        }
    }
}
