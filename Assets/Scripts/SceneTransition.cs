using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/// <summary>
/// Attach this to the Player object.
/// Press a key to toggle between past and present versions of the current room.
/// Player position is preserved when switching between states.
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
                targetScene = currentScene.Substring(0, currentScene.Length - "Present".Length) + "Past";
            }
            else if (currentScene.EndsWith("Past"))
            {
                targetScene = currentScene.Substring(0, currentScene.Length - "Past".Length) + "Present";
            }
            else
            {
                Debug.LogWarning("Scene name '" + currentScene + "' does not end with 'Present' or 'Past'");
                return;
            }

            // Save position before transitioning
            Vector3 savedPosition = transform.position;

            SceneManager.LoadScene(targetScene);

            SceneManager.sceneLoaded += OnSceneLoaded;

            void OnSceneLoaded(Scene scene, LoadSceneMode mode)
            {
                transform.position = savedPosition;
                SceneManager.sceneLoaded -= OnSceneLoaded;
            }
        }
    }
}