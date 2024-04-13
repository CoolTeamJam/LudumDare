using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class itemSlot : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;

    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;
    
    public GameObject selectedShader;
    public bool itemSelected;

    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;

    private InventoryManager inventoryManager;

    public void Start()
    {
        inventoryManager = GameObject.Find("Canvas").GetComponent<InventoryManager>();
    }
    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;
        isFull = true;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        inventoryManager.DeSelectAllItems();
        selectedShader.SetActive(true);
        itemSelected = true;
        itemDescriptionNameText.text = itemName;
        itemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;
    }

    public void OnRightClick()
    {

    }
}
