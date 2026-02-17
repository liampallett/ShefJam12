using UnityEngine;
using UnityEngine.InputSystem;

public class FeedChicken : MonoBehaviour
{
    private bool playerInRange = false;
    public static bool chickensFed = false;
    private Inventory playerInventory;

    void Update()
    {
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (playerInventory != null && playerInventory.HasItem("Corn"))
            {
                Debug.Log("Fed the chickens!");
                chickensFed = true;
                playerInventory.RemoveItem("Corn");
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