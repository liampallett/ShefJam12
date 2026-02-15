using UnityEngine;

/// <summary>
/// Keeps the Canvas (and all its UI children) alive across scene loads
/// </summary>
public class PersistentCanvas : MonoBehaviour
{
    private static PersistentCanvas instance;

    private void Awake()
    {
        // If a Canvas already exists from a previous scene, destroy it
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}