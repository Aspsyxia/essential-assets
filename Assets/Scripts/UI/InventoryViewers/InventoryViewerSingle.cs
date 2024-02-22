using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using EssentialAssets.InventorySystem;

namespace EssentialAssets.UI
{
    public class InventoryViewerSingle : CanvasOverlay
    {
        [Header("References")] [SerializeField]
        private Image itemPreviewImage;

        [SerializeField] private TMP_Text itemNameText;
        [SerializeField] private TMP_Text descriptionText;

        private List<Item> _items;
        private int _currentItemIndex;

        private void Awake()
        {
            FindObjectOfType<Inventory>().NewItemAdded += ReplaceItem;
            layoutCanvas.enabled = false;
            _items = FindObjectOfType<Inventory>().InventoryItems;
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
            if (_items.Count == 0) return;

            _currentItemIndex = (_currentItemIndex + 1) % _items.Count;

            ReplaceItem();
        }

        public void Left()
        {
            if (_items.Count == 0) return;

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
    }
}