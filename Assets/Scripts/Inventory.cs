using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Attach this to the Player
/// </summary>
public class Inventory : MonoBehaviour
{
    [SerializeField] private int maxSlots = 8;
    [SerializeField] private InventoryUI inventoryUI;

    private List<InventoryItem> items = new List<InventoryItem>();

    private InventoryUI GetInventoryUI()
    {
        if (inventoryUI == null)
        {
            inventoryUI = FindAnyObjectByType<InventoryUI>();
        }
        return inventoryUI;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();

        if (item != null && items.Count < maxSlots)
        {
            items.Add(item.ItemData);
            Debug.Log("Picked up: " + item.ItemData.itemName);

            // Update the on-screen inventory display
            var ui = GetInventoryUI();
            if (ui != null)
            {
                ui.UpdateUI(items);
            }

            // Remove the item from the scene
            Destroy(other.gameObject);
        }
    }

    public List<InventoryItem> GetItems() => items;

    public bool HasItem(string itemName) => items.Exists(i => i.itemName == itemName);

    public void RemoveItem(string itemName)
    {
        InventoryItem found = items.Find(i => i.itemName == itemName);
        if (found != null)
        {
            items.Remove(found);
            GetInventoryUI()?.UpdateUI(items);
        }
    }
}