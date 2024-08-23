using UnityEngine;
using System.Collections.Generic;
using EssentialAssets.InventorySystem;
using TMPro;

namespace EssentialAssets.UI
{
    public class InventoryViewerSlots : CanvasOverlay
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
            var inventory = FindObjectOfType<Inventory>();
            
            inventory.NewItemAdded += UpdateNewSlot;
            inventorySlots = new List<InventorySlot>(GetComponentsInChildren<InventorySlot>());
            layoutCanvas.enabled = false;
            
            _items = inventory.InventoryItems;
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