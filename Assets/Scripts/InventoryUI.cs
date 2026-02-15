using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the on-screen inventory display.
/// Attach this to the InventoryPanel GameObject in your Canvas.
/// </summary>
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;

    private List<GameObject> slotInstances = new List<GameObject>();

    /// <summary>
    /// Call this whenever the inventory changes to refresh the display.
    /// </summary>
    public void UpdateUI(List<InventoryItem> items)
    {
        // Clear existing slots
        foreach (var slot in slotInstances)
        {
            Destroy(slot);
        }
        slotInstances.Clear();

        // Create a slot for each item
        foreach (var item in items)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);
            slot.SetActive(true);
            slotInstances.Add(slot);

            // Get the SlotUI component and set the icon
            SlotUI slotUI = slot.GetComponent<SlotUI>();
            if (slotUI != null && slotUI.iconImage != null && item.icon != null)
            {
                slotUI.iconImage.sprite = item.icon;
                slotUI.iconImage.color = Color.white;
                slotUI.iconImage.enabled = true;
            }
        }
    }
}