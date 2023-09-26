using UnityEngine;
using System.Collections.Generic;
using InventorySystem;
using TMPro;

public class InventoryViewerSlots : MonoBehaviour
{
    [Header("UI references")]
    [SerializeField] private Canvas inventoryCanvas;
    [SerializeField] private Sprite itemPreviewImage;
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text descriptionText;

    private List<InventorySlot> _inventorySlots = new();

    private int _freeSlotIndex = 0;

    private void Start()
    {
        Inventory.NewItemAdded += UpdateDisplay;
        FetchItems();
    }
    
    // public void Right()
    // {
    //     characterPreviews[_currentCharacter].SetActive(false);
    //     _currentCharacter = (_currentCharacter + 1) % characterPreviews.Count;
    //         
    //     ReplaceCharacter();
    // }
    //
    // public void Left()
    // {
    //     characterPreviews[_currentCharacter].SetActive(false);
    //     _currentCharacter -= 1;
    //     
    //     if (_currentCharacter < 0)
    //     {
    //         _currentCharacter = characterPreviews.Count - 1;
    //     }
    //         
    //     ReplaceCharacter();
    // }
    //
    // private void ReplaceCharacter()
    // {
    //     characterNameText.text = characters[_currentCharacter].CharacterName;
    //     description.text = characters[_currentCharacter].Description;
    //     characterPreviews[_currentCharacter].SetActive(true);   
    // }

    private void FetchItems()
    {
        foreach (var item in FindObjectOfType<Inventory>().inventoryItems)
        {
            UpdateDisplay(item);
        }
    }

    private void UpdateDisplay(Item newItem)
    {
        
    }
}
