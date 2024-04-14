using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Interactable/Item")]
public class Item : Intractable_Pickup
{
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite snapShot;
    [SerializeField] private Sprite background;

    [SerializeField] private string itemDescription;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        inventoryManager.AddItem(itemName, quantity, snapShot);
    //        //Destroy(gameObject);
    //    }
    //}

    public override bool AddInventoryItem(GameObject iInstigator)
    {
        InventoryManager Inventory = iInstigator.GetComponent<InventoryReference>().Inventory;

        if (Inventory == null) return false;

        Inventory.AddItem(itemName, quantity, snapShot, itemDescription);
        Debug.Log("Picked up item");
        return true;
    }
}
