using UnityEngine;
using System.Collections.Generic;
using EssentialAssets.Core;
using TMPro;

namespace EssentialAssets.InventorySystem
{
    public class InventoryViewerSlots : CanvasBasedLayout
    {
        [Header("UI references")]
        public TMP_Text itemNameText;
        public TMP_Text descriptionText;

        [Header("Slots")] 
        [SerializeField] private List<InventorySlot> inventorySlots;

        private List<Item> _items;
        private int _freeSlotIndex;

        private void Awake()
        {
            FindObjectOfType<Inventory>().NewItemAdded += UpdateNewSlot;
            inventorySlots = new List<InventorySlot>(GetComponentsInChildren<InventorySlot>());
            layoutCanvas.enabled = false;
            _items = FindObjectOfType<Inventory>().InventoryItems;
            InventoryCheck();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Toggle();
            }
        }

        private void UpdateNewSlot()
        {
            var slotToUpdate = inventorySlots[_freeSlotIndex];
            
            slotToUpdate.itemImage.sprite = _items[_freeSlotIndex].itemImage;
            slotToUpdate.item = _items[_freeSlotIndex];
            itemNameText.text = slotToUpdate.item.itemName;
            descriptionText.text = slotToUpdate.item.itemDescription;
            
            _freeSlotIndex++;
        }
        
        private void InventoryCheck()
        {
            if (_items.Count == 0)
            {
                itemNameText.text = "None";
                descriptionText.text = "Your inventory is empty";
            }
            else
            {
                itemNameText.text = "None";
                descriptionText.text = "";
            }
        }
    }
}