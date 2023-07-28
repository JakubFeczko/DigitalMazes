using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the inventory system in the game, including item placement, activation and deactivation.
/// </summary>
public class InventoryManager : MonoBehaviour
{
    /// <summary>
    /// Array of InventorySlot, representing the slots in the inventory.
    /// </summary>
    public InventorySlot[] inventorySlots;

    /// <summary>
    /// List of InventoryItem, storing the items when the inventory is inactive.
    /// </summary>
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();

    [Header("Inventory")]
    /// <summary>
    /// The GameObject representing the inventory UI.
    /// </summary>
    public GameObject inventoryUI;

    /// <summary>
    /// Activates the inventory, repositioning items back to their slots.
    /// </summary>
    public void ActivateInventory()
    {
        // Iterate over all the items in the inventory
        foreach (InventoryItem item in inventoryItems)
        {
            item.itemObject.transform.position = inventorySlots[item.slotIndex].transform.position;
            // Reactivate the item object
            item.itemObject.SetActive(true);
            // Place it back in its corresponding slot
            inventorySlots[item.slotIndex].SetItem(item.itemObject);
        }

        // Clear the list of items
        inventoryItems.Clear();
    }

    /// <summary>
    /// Deactivates the inventory, storing the items in a list and deactivating their GameObjects.
    /// </summary>
    public void DeactivateInventory()
    {
        // Iterate over all the slots in the inventory
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].HasItem())
            {
                // If the slot has an item, add it to the list
                InventoryItem newItem = new InventoryItem();
                newItem.itemObject = inventorySlots[i].GetItem();
                newItem.slotIndex = i;
                inventoryItems.Add(newItem);

                // Deactivate the item object
                newItem.itemObject.SetActive(false);
            }
        }
    }

}
