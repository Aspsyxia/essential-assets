using EssentialAssets.InventorySystem;
using EssentialAssets.Items;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items", order = 1)]
public class Item : ScriptableObject
{
    public string itemName = "item name";
    public string itemDescription = "optional description";
    public Sprite itemImage;
    public ItemType itemType = ItemType.Other;
    public bool canBeEquipped = true;
    public EquippableItem itemPrefab;
}
