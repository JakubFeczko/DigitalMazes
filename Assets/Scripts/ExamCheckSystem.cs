using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Checks if all inventory slots are filled.
/// </summary>
public class ExamCheckSystem : MonoBehaviour
{
    /// <summary>
    /// Array of InventorySlot objects representing the slots in the inventory.
    /// </summary>
    public InventorySlot[] inventorySlots;

    [Header("Ghost")]
    public GameObject ghost;
    
    [Header("Inventory")]
    /// <summary>
    /// The GameObject representing the inventory.
    /// </summary>
    public GameObject inventory;

    /// <summary>
    /// The canvas that will be activated when all slots are filled.
    /// </summary>
    public GameObject canvas;

    /// <summary>
    /// Updates each frame and checks if all slots are filled.
    /// If all slots are filled, the canvas is activated.
    /// </summary>
    private void Update()
    {
        if (AreAllSlotsFilled())
        {

            canvas.SetActive(true);
            ghost.SetActive(false);
        }
    }

    /// <summary>
    /// Checks if all the slots in the inventory are filled with items.
    /// </summary>
    /// <returns>
    /// True if all slots are filled, false otherwise.
    /// </returns>
    public bool AreAllSlotsFilled()
    {
        foreach(InventorySlot slot in inventorySlots)
        {
            if (!slot.HasItem())
            {
                //Debug.Log("Nie wszystkie sloty s¹ zajête");
                return false;
            }
        }
        //Debug.Log("Wszystkie sloty s¹ zajête");
        return true;
    }
}
