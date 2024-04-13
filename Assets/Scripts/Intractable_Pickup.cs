using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intractable_Pickup : MonoBehaviour, Interactable
{
    public void Interact(GameObject iInstigator)
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

    bool AddInventoryItem(GameObject iInstigator)
    {
        return true;
    }
}
