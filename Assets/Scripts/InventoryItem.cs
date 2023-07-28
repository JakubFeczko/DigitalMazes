using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class represents an item in an inventory.
/// </summary>
public class InventoryItem 
{
    /// <summary>
    /// The GameObject representing the item.
    /// </summary>
    public GameObject itemObject;

    /// <summary>
    /// The index of the slot in which the item is placed in the inventory.
    /// </summary>
    public int slotIndex;
}
