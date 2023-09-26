using System;
using UnityEngine;
using System.Collections.Generic;
using Items;

namespace InventorySystem
{
    public class Inventory: MonoBehaviour
    {
        public List<Item> inventoryItems = new();
        public List<EquippableItem> equippableItems = new();
        public static event Action<Item> NewItemAdded;
        private EquippableItem _currentlyEquipped;
        
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
            CheckForInput();
        }

        private void CheckForInput()
        {
            for (int i = 0; i < _keyCodes.Length; i++)
            {
                if (Input.GetKeyDown(_keyCodes[i]))
                {
                    var indexToCheck = i - 1;
                    if (i <= equippableItems.Count && equippableItems[indexToCheck] != null) SwitchItems(indexToCheck);
                }
            }
        }

        private void SwitchItems(int itemIndex)
        {
            print("passes");
            
            if (_currentlyEquipped != null) _currentlyEquipped.UnEquip();

            if (_currentlyEquipped == equippableItems[itemIndex])
            {
                _currentlyEquipped = null;
            }
            else
            {
                _currentlyEquipped = equippableItems[itemIndex];
                equippableItems[itemIndex].Equip();
            }
        }

        public void AddNewItem(Item newItem)
        {
            if (newItem.canBeEquipped)
            {
                var newItemInstance = Instantiate(newItem.itemPrefab, transform, false);
                equippableItems.Add(newItemInstance);
            }
            inventoryItems.Add(newItem);
            NewItemAdded?.Invoke(newItem);
        }

        private void FetchInitialItems()
        {
            foreach (var item in inventoryItems)
            {
                AddNewItem(item);
            }
        }
    }
}