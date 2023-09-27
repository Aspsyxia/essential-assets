using System;
using UnityEngine;
using System.Collections.Generic;
using Items;
using Core;

namespace InventorySystem
{
    public class Inventory: InputAction
    {
        public List<Item> initialItems = new();
        public List<Item> InventoryItems => _inventoryItems;
        public static event Action NewItemAdded;
        
        private EquippableItem _currentlyEquipped;
        private readonly List<Item> _inventoryItems = new();
        private readonly List<EquippableItem> _equippableItems = new();
        
        private readonly KeyCode[] _keyCodes = {
            KeyCode.Alpha0,
            KeyCode.Alpha1,
            KeyCode.Alpha2,
            KeyCode.Alpha3,
            KeyCode.Alpha4,
            KeyCode.Alpha5,
            KeyCode.Alpha6,
            KeyCode.Alpha7,
            KeyCode.Alpha8,
            KeyCode.Alpha9,
        };

        private void Start()
        {
            FetchInitialItems();
        }

        private void Update()
        {
            if (!IsActive) return;
            CheckForInput();
        }

        private void CheckForInput()
        {
            for (int i = 0; i < _keyCodes.Length; i++)
            {
                if (Input.GetKeyDown(_keyCodes[i]))
                {
                    var indexToCheck = i - 1;
                    if (i <= _equippableItems.Count && _equippableItems[indexToCheck] != null) SwitchItems(indexToCheck);
                }
            }
        }

        private void SwitchItems(int itemIndex)
        {
            if (_currentlyEquipped != null) _currentlyEquipped.UnEquip();

            if (_currentlyEquipped == _equippableItems[itemIndex])
            {
                _currentlyEquipped = null;
            }
            else
            {
                _currentlyEquipped = _equippableItems[itemIndex];
                _equippableItems[itemIndex].Equip();
            }
        }

        public void AddNewItem(Item newItem)
        {
            if (newItem.canBeEquipped)
            { 
                var newItemInstance = Instantiate(newItem.itemPrefab, transform, false);
                _equippableItems.Add(newItemInstance);
            }
            _inventoryItems.Add(newItem);
            NewItemAdded?.Invoke();
        }
        
        private void FetchInitialItems()
        {
            foreach (var item in initialItems)
            {
                AddNewItem(item);
            }
            
            initialItems.Clear();
        }
    }
}