using UnityEngine;
using Inventory;

namespace Pickable
{
    public class InventoryPickable: Pickable
    {
        [SerializeField] private EquippableItem item;
        protected override void PickingBehaviour()
        {
            base.PickingBehaviour();
            //add to eq
        }
    }
}