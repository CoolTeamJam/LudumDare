using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[AddComponentMenu("Quest/Event/Activate Interactibles")]
public class Event_ActivateInteractables : QuestEvent
{
    [Serialize]
    public Interactable[] InteractablesToActivate;

    public override void TriggerEvent()
    {
        foreach (Interactable wPickup in InteractablesToActivate)
        {
            wPickup.ActivateInteractable();
        }
    }
}
