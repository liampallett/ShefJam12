using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/// <summary>
/// Press a key to toggle between past and present versions of the current room.
/// </summary>
public class SceneTransition : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] private Key transitionKey = Key.Q;

    private Keyboard keyboard;
    public static bool isInPast;

    AudioSource pastOST;
    AudioSource presentOST;

    private void Awake()
    {
        keyboard = Keyboard.current;
        AudioSource[] osts = this.GetComponents<AudioSource>();
        pastOST = osts[0];
        presentOST = osts[1];
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
                isInPast = true;
                pastOST.mute = false;
                presentOST.mute = true;
            }
            else if (currentScene.EndsWith("Past"))
            {
                targetScene = currentScene.Substring(0, currentScene.Length - "Past".Length) + "Present";
                isInPast = false;
                pastOST.mute = true;
                presentOST.mute = false;
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