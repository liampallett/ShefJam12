using UnityEngine;
using UnityEngine.UI;

public class interactUI : MonoBehaviour
{
    public Image interactKeyUI;

    void Start()
    {
        if (interactKeyUI != null) {
            interactKeyUI.enabled = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (interactKeyUI != null) {
            interactKeyUI.enabled = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (interactKeyUI != null) {
            interactKeyUI.enabled = false;
        }
    }
}
