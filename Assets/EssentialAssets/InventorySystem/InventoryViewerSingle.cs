using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using Core;
using InventorySystem;

public class InventoryViewerSingle : CanvasBasedLayout
{
    [Header("References")]
    [SerializeField] private Image itemPreviewImage;
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text descriptionText;

    private List<Item> _items;
    private int _currentItemIndex;

    private void Start()
    {
        Inventory.NewItemAdded += UpdateDisplay;
        layoutCanvas.enabled = false;
        _items = FindObjectOfType<Inventory>().inventoryItems;
        FetchItems();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Toggle();
        }
    }

    public void Right()
    {
        if(_items.Count == 0) return;
        
        _currentItemIndex = (_currentItemIndex + 1) % _items.Count;
        
        ReplaceItem();
    }
    
    public void Left()
    {
        if(_items.Count == 0) return;
        
        _currentItemIndex -= 1;
        if (_currentItemIndex < 0)
        {
            _currentItemIndex = _items.Count - 1;
        }
        
        ReplaceItem();
    }

    private void ReplaceItem()
    {
        itemNameText.text = _items[_currentItemIndex].itemName;
        descriptionText.text = _items[_currentItemIndex].itemDescription;
        itemPreviewImage.sprite = _items[_currentItemIndex].itemImage;
    }

    private void FetchItems()
    {
        if (_items.Count != 0) ReplaceItem();
    }

    private void UpdateDisplay(Item newItem)
    {
        ReplaceItem();
    }


}