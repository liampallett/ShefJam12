using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Keeps the Canvas (and all its UI children) alive across scene loads
/// </summary>
public class PersistentCanvas : MonoBehaviour
{
    private static PersistentCanvas instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "WinScreen")
        {
            instance = null;
            Destroy(gameObject);
        }
    }
}