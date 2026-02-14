using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/// <summary>
/// Attach this to the Player object.
/// Press a key to toggle between the current scene and its alternate state.
/// If the scene ends with "Present", it loads the version without it, and vice versa.
/// </summary>
public class SceneTransition : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] private Key transitionKey = Key.Q;

    private Keyboard keyboard;

    private void Awake()
    {
        keyboard = Keyboard.current;
    }

    private void Update()
    {
        if (keyboard != null && keyboard[transitionKey].wasPressedThisFrame)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            string targetScene;

            if (currentScene.EndsWith("Present"))
            {
                // Remove "Present" from the end
                targetScene = currentScene.Substring(0, currentScene.Length - "Present".Length);
            }
            else
            {
                // Add "Present" to the end
                targetScene = currentScene + "Present";
            }

            SceneManager.LoadScene(targetScene);
        }
    }
}