using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Attach this to an object in the PAST scene that the player can use an item on.
/// When the player is nearby and presses the use key, it consumes the required item
/// and marks the object as changed in WorldState.
/// </summary>
public class ItemReceiver : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string objectId;
    [SerializeField] private string requiredItemName;
    [SerializeField] private bool removeItem;
    [SerializeField] private Key useKey = Key.E;

    [Header("Optional: Change sprite in this scene too")]
    [SerializeField] private Sprite changedSprite;

    private bool playerInRange = false;
    private Inventory playerInventory;
    private Keyboard keyboard;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        keyboard = Keyboard.current;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (playerInRange && keyboard != null && keyboard[useKey].wasPressedThisFrame)
        {
            if (playerInventory != null && playerInventory.HasItem(requiredItemName))
            {
                if (removeItem)
                {
                    // Remove the item from inventory
                    playerInventory.RemoveItem(requiredItemName);
                }

                // Mark this object as changed globally
                WorldState.SetChanged(objectId);

                Debug.Log("Used " + requiredItemName + " on " + objectId);

                // Optionally change sprite in the current scene too
                if (changedSprite != null && spriteRenderer != null)
                {
                    spriteRenderer.sprite = changedSprite;
                }
            }
            else
            {
                Debug.Log("You don't have the required item: " + requiredItemName);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Inventory inventory = other.GetComponent<Inventory>();
        if (inventory != null)
        {
            playerInRange = true;
            playerInventory = inventory;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Inventory>() != null)
        {
            playerInRange = false;
            playerInventory = null;
        }
    }
}