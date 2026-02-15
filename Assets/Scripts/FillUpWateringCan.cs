using UnityEngine;
using UnityEngine.InputSystem;

public class FillUpWateringCan : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string requiredItemName;
    [SerializeField] private string receivedItemName;
    [SerializeField] private Key useKey = Key.E;

    private bool playerInRange = false;
    private Inventory playerInventory;
    private Keyboard keyboard;

    private void Awake()
    {
        keyboard = Keyboard.current;
    }

    private void Update() {

        if (FixPipes.coralFixed)
        {
            if (playerInRange && keyboard != null && keyboard[useKey].wasPressedThisFrame)
            {
                if (playerInventory != null && playerInventory.HasItem(requiredItemName))
                {
                    // Remove the item from inventory
                    playerInventory.RemoveItem(requiredItemName);

                    // Give new item
                    playerInventory.AddItem(receivedItemName);

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