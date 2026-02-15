using UnityEngine;
using UnityEngine.UI;

public class interactUI : MonoBehaviour
{
    public Image interactKeyUI;
    public Image pastKey;
    public Image presentKey;

    void Start()
    {
        if (interactKeyUI != null) {
            interactKeyUI.enabled = false;
        }
    }

    void Update()
    {
        bool isInPast = SceneTransition.isInPast;
        if (isInPast) {
            pastKey.enabled = true;
            presentKey.enabled = false;
        } else {
            pastKey.enabled = false;
            presentKey.enabled = true;
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
