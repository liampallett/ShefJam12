using UnityEngine;

/// <summary>
/// ScriptableObject that defines an item type
/// </summary>
[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/New Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    [TextArea] public string description;
}