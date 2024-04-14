using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public struct KeyObjectPair
{
    public string Key;
    public GameObject Value;
}

[AddComponentMenu("Interactable/Buildable")]
public class Interactable_Buildable : Interactable
{
    public string Verb = "Construct";
    public string ConstructName;

    bool bCanInteract = false;

    [SerializeField]
    public KeyObjectPair[] Components;

    public bool bIsBuilt { get; protected set; } = false;

    public override bool CanInteract()
    {
        return !bIsBuilt;
    }

    public override string GetInteractMessage()
    {
        return Verb + " " + ConstructName;
    }

    public override void Interact(GameObject iInstigator)
    {
        InventoryManager wInventory = iInstigator.GetComponent<InventoryReference>().Inventory;

        if (wInventory != null)
        {
            foreach(KeyObjectPair wKO in Components)
            {
                if(!wKO.Value.activeInHierarchy && wInventory.HasItem(wKO.Key, out int oItemIndex))
                {
                    wKO.Value.SetActive(true);
                    wInventory.RemoveItem(wKO.Key);
                    break;
                }
            }
        }

        bIsBuilt = CheckIsBuilt();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(KeyObjectPair wKO in Components)
        {
            wKO.Value.SetActive(false);
        }

        //gameObject.SetActive(false);
    }

    public bool CheckIsBuilt()
    {
        foreach (KeyObjectPair wKO in Components)
        {
            if (!wKO.Value.activeInHierarchy)
                return false;
        }

        return true;
    }

    public override void ActivateInteractable()
    {
        bCanInteract = true;
    }
}
