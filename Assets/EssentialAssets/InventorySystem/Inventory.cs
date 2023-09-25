using UnityEngine;
using System.Collections.Generic;

namespace Inventory
{
    public class Inventory: MonoBehaviour
    {
        [SerializeField] private List<EquippableItem> inventoryItems = new();

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
                    if (i <= inventoryItems.Capacity && inventoryItems[indexToCheck] != null) SwitchItems(indexToCheck);
                }
            }
        }

        private void SwitchItems(int itemIndex)
        {
            if (_currentlyEquipped != null) _currentlyEquipped.UnEquip();

            if (_currentlyEquipped == inventoryItems[itemIndex])
            {
                _currentlyEquipped = null;
            }
            else
            {
                _currentlyEquipped = inventoryItems[itemIndex];
                inventoryItems[itemIndex].Equip();
            }
        }
        
        
    }
}