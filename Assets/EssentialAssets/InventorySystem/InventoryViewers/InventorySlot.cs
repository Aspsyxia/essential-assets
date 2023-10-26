using UnityEngine;
using UnityEngine.UI;

namespace EssentialAssets.InventorySystem
{
    public class InventorySlot: MonoBehaviour
    {
        public Image itemImage;
        public Item item;

        private void Start()
        {
            itemImage = GetComponent<Image>();
        }

        public void DisplayInfo()
        {
            if (item == null) return;
            GetComponentInParent<InventoryViewerSlots>().itemNameText.text = item.itemName;
            GetComponentInParent<InventoryViewerSlots>().descriptionText.text = item.itemDescription;
        }
    }
}