using UnityEngine;
using UnityEngine.InputSystem;  
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneToLoad;
    private bool playerInRange = false;

    void Update()
    {
        ///Debug.Log("update");
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("load scene");
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        Debug.Log("Triggered by: " + other.name + ", tag: " + other.tag);
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
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
