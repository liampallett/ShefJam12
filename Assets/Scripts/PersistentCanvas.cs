using UnityEngine;

/// <summary>
/// Attach this to the Canvas object.
/// Keeps the Canvas (and all its UI children) alive across scene loads.
/// Ensures only one Canvas ever exists.
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
}