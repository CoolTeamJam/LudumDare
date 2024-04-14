using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Interactable/Pickup")]
public class Intractable_Pickup : Interactable
{ 
    public bool bCanInteract { get; protected set; }
    [SerializeField] bool bStartActive = false;

    private void Start()
    {
        bCanInteract = bStartActive;
    }

    public override string GetInteractMessage()
    {
        return "pick up Item";
    }

    public override void Interact(GameObject iInstigator)
    {
        if (iInstigator == null)
        {
            return;
        }
        else
        {
            if(AddInventoryItem(iInstigator))
            {
                   this.gameObject.SetActive(false);
            }
        }
    }

    public virtual bool AddInventoryItem(GameObject iInstigator)
    {
        return true;
    }

    public override bool CanInteract()
    {
        return bCanInteract;
    }

    public override void ActivateInteractable()
    {
        bCanInteract = true;
    }
}
