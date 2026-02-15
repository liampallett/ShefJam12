using UnityEngine;

/// <summary>
/// Keeps the Player (and all its components/children) alive across scene loads
/// </summary>
public class PersistentPlayer : MonoBehaviour
{
    private static PersistentPlayer instance;

    private void Awake()
    {
        // If a Player already exists from a previous scene, destroy it
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}