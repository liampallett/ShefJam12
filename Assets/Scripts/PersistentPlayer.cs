using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Keeps the Player (and all its components/children) alive across scene loads
/// </summary>
public class PersistentPlayer : MonoBehaviour
{
    private static PersistentPlayer instance;

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