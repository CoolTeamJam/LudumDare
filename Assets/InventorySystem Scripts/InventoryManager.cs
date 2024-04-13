using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public itemSlot[] itemSlots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory") && menuActivated)
        {
            Time.timeScale = 1; //resume the game
            Cursor.visible = false;
            InventoryMenu.SetActive(false);
            menuActivated = false;

        }
        else if(Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0; //stop the game (physics)
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        Debug.Log("Added Item: " + itemName);

        for(int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].isFull == false)
            {
                itemSlots[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                return;
            }
        }
    }

    public void DeSelectAllItems()
    {
        for(int i = 0;i < itemSlots.Length;i++)
        {
            itemSlots[i].selectedShader.SetActive(false);
            itemSlots[i].itemSelected = false;
        }
    }
}
