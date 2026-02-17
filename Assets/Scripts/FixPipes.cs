using NUnit.Framework;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class FixPipes : MonoBehaviour
{
    public TilemapRenderer fixedTilemap;
    public GameObject oilDrop;
    private bool playerInRange = false;
    public static bool coralFixed = false;

    private Inventory playerInventory;
    public BoxCollider2D box;

    void Start()
    {
        //box = GameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (playerInventory != null && playerInventory.HasItem("spanner")) {
                if (fixedTilemap != null) {
                    Debug.Log("Fixed the pipes!");
                    fixedTilemap.enabled = true;
                    coralFixed = true;
                    oilDrop.SetActive(false);
                    playerInventory.RemoveItem("spanner");
                }
            }
        }

        if (coralFixed)
        {
            fixedTilemap.enabled = true;
            coralFixed = true;
            oilDrop.SetActive(false);
            box.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Inventory inventory = other.GetComponent<Inventory>();

        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerInventory = inventory;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            playerInRange = false;
        }
    }
}
