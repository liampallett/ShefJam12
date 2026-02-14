using UnityEngine;

/// <summary>
/// Attach this to the Player object.
/// Keeps the Player (and all its components/children) alive across scene loads.
/// Ensures only one Player ever exists.
/// </summary>
public class PersistentPlayer : MonoBehaviour
{
    private static PersistentPlayer instance;

    private void Awake()
    {
        // If a Player already exists from a previous scene, destroy this duSplicate
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}