using UnityEngine;

/// <summary>
/// Attach this to any pickupable object in the scene
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class Item : MonoBehaviour
{
    [SerializeField] private InventoryItem itemData;

    public InventoryItem ItemData => itemData;
}