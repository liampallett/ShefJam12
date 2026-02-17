using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Harvests corn using sickle
/// </summary>
public class HarvestCorn : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string requiredItemName;
    [SerializeField] private string receivedItemName;
    [SerializeField] private Key useKey = Key.E;

    private bool playerInRange = false;
    public static bool hasBeenUsed = false;
    private Inventory playerInventory;
    private Keyboard keyboard;

    private void Awake()
    {
        keyboard = Keyboard.current;
    }

    private void Update()
    {

        if (ItemReceiver.cornWatered)
        {
            if (playerInRange && keyboard != null && keyboard[useKey].wasPressedThisFrame)
            {
                if (playerInventory != null && playerInventory.HasItem(requiredItemName))
                {
                    if (hasBeenUsed)
                    {
                        Debug.Log("You have already done that!");
                        return;
                    }

                    // Remove the item from inventory
                    playerInventory.RemoveItem(requiredItemName, false);

                    // Give new item
                    playerInventory.AddItem(receivedItemName);

                    Debug.Log("Harvested the corn!");

                    hasBeenUsed = true;

                }
                else
                {
                    Debug.Log("You don't have the required item: " + requiredItemName);
                }
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