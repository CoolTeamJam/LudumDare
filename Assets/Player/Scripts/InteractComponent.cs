using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractComponent : MonoBehaviour
{
    Interactable currentInteractable = null;
    public Transform Viewpoint;
    public float MaxInteractDistance = 0.5f;

    bool interact_pressed = false;


    // Update is called once per frame
    void Update()
    {
        if (Viewpoint == null) return;

        RaycastHit hit;

        bool bFoundInteractable = false;

        if (Physics.Raycast(Viewpoint.position, Viewpoint.forward, out hit, MaxInteractDistance))
        {
            if(hit.collider.gameObject.TryGetComponent(out Interactable oInteractable))
            {
                currentInteractable = oInteractable;
                bFoundInteractable = true;
            }
        }

        if(!bFoundInteractable)
        {
            currentInteractable = null;
        }

        if (Input.GetAxis("Interact") > 0 && !interact_pressed)
        {
            interact_pressed = true;

            if (currentInteractable != null && currentInteractable.CanInteract())
            {
                currentInteractable.Interact(gameObject);
            }
        }
        else if(Input.GetAxis("Interact") <= 0f && interact_pressed)
        {
            interact_pressed = false;
        }
    }

    public bool GetInteractMessage(out string oInteractMessage)
    {
        if(currentInteractable == null || !currentInteractable.CanInteract())
        {
            oInteractMessage = string.Empty;
            return false;
        }
        else
        {
            oInteractMessage = currentInteractable.GetInteractMessage();
            return true;
        }
    }
}
