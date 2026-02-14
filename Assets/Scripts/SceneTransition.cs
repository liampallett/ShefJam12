using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/// <summary>
/// Attach this to the Player object.
/// Press a key to transition to another scene, preserving position.
/// </summary>
public class SceneTransition : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] private string targetSceneName;
    [SerializeField] private Key transitionKey = Key.Q;

    private Keyboard keyboard;

    // Static so it persists between scene loads
    private static Vector3 savedPosition;
    private static bool hasSavedPosition = false;

    private void Awake()
    {
        keyboard = Keyboard.current;
    }

    private void Update()
    {
        if (keyboard != null && keyboard[transitionKey].wasPressedThisFrame)
        {
            // Save the player's current position
            savedPosition = transform.position;
            hasSavedPosition = true;

            // Load the target scene
            SceneManager.LoadScene(targetSceneName);
        }
    }

    /// <summary>
    /// Call this from PlayerSpawn to get the saved position.
    /// </summary>
    public static bool TryGetSavedPosition(out Vector3 position)
    {
        position = savedPosition;
        if (hasSavedPosition)
        {
            hasSavedPosition = false;
            return true;
        }
        return false;
    }
}