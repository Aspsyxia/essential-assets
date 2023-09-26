using UnityEngine;
using InventorySystem;

namespace Items
{
    public class InventoryPickable: Pickable
    {
        [SerializeField] private Item item;
        protected override void PickingBehaviour()
        {
            base.PickingBehaviour();
            FindObjectOfType<Inventory>().AddNewItem(item);
        }
    }
}