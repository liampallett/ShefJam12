using UnityEngine;
using UnityEngine.InputSystem;  
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneToLoad;
    private bool playerInRange = false;
    public Vector2 targetSpawnPosition;

    void Update()
    {
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            SpawnManager.spawnPosition = targetSpawnPosition;
            SceneManager.LoadScene(sceneToLoad);
            SpawnManager.hasSpawnPosition = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
