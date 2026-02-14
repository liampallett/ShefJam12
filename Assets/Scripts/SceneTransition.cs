using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/// <summary>
/// Attach this to the Player object.
/// Press a key to toggle between the current scene and the target scene.
/// Automatically remembers the previous scene so you can go back.
/// </summary>
public class SceneTransition : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] private string targetSceneName;
    [SerializeField] private Key transitionKey = Key.Q;

    private Keyboard keyboard;
    private string previousSceneName;

    private void Awake()
    {
        keyboard = Keyboard.current;
    }

    private void Update()
    {
        if (keyboard != null && keyboard[transitionKey].wasPressedThisFrame)
        {
            // Save the current scene name before transitioning
            previousSceneName = SceneManager.GetActiveScene().name;

            // Load the target scene
            SceneManager.LoadScene(targetSceneName);

            // Swap so pressing the key again brings you back
            targetSceneName = previousSceneName;
        }
    }
}