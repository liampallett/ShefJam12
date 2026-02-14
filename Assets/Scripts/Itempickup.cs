using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach this to the Player object.
/// Picks up items with the "Item" tag when the player walks into them.
/// </summary>
public class ItemPickup : MonoBehaviour
{
    // A simple inventory list to track what's been picked up
    private List<string> inventory = new List<string>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            // Add the item's name to the inventory
            inventory.Add(other.gameObject.name);
            Debug.Log("Picked up: " + other.gameObject.name);

            // Remove the item from the scene
            Destroy(other.gameObject);
        }
    }

    // Optional: check inventory contents
    public List<string> GetInventory() => inventory;

    public bool HasItem(string itemName) => inventory.Contains(itemName);
}