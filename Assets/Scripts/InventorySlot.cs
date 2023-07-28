using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// This class represents an inventory slot that inherits from XRSocketInteractor, allowing for interactions in VR.
/// </summary>
public class InventorySlot : XRSocketInteractor
{
    /// <summary>
    /// The GameObject currently placed in the inventory slot.
    /// </summary>
    private GameObject currentItem = null;

    /// <summary>
    /// This method is called when an interactable object enters the slot.
    /// </summary>
    /// <param name="interactable">The interactable object that entered the slot.</param>
    [System.Obsolete]
    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {
        base.OnSelectEntered(interactable);
        currentItem = interactable.gameObject;
        Debug.Log("OnSelectEntered");
        Debug.Log(currentItem.name);
    }

    /// <summary>
    /// This method is called when an interactable object exits the slot.
    /// </summary>
    /// <param name="interactable">The interactable object that exited the slot.</param>
    [System.Obsolete]
    protected override void OnSelectExited(XRBaseInteractable interactable)
    {
        base.OnSelectExited(interactable);
        currentItem = null;
        Debug.Log("OnSelectExited");

    }

    /// <summary>
    /// Checks whether the slot currently holds an item.
    /// </summary>
    /// <returns>True if the slot has an item, false otherwise.</returns>
    public bool HasItem()
    {
        return currentItem != null;
    }

    /// <summary>
    /// Retrieves the item currently placed in the slot.
    /// </summary>
    /// <returns>The GameObject of the item if present, null otherwise.</returns>
    public GameObject GetItem()
    {
        return currentItem;
    }

    /// <summary>
    /// Sets the current item of the inventory slot.
    /// </summary>
    /// <param name="item">The GameObject representing the item to set.</param>
    public void SetItem(GameObject item)
    {
          currentItem = item;
    }
}
