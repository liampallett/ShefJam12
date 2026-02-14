using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tracks which objects have been changed by item usage.
/// Persists across scenes. Attach to the Player object.
/// </summary>
public class WorldState : MonoBehaviour
{
    private static WorldState instance;

    // Stores which objects have been changed, keyed by a unique ID
    private Dictionary<string, bool> changedObjects = new Dictionary<string, bool>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    /// <summary>
    /// Mark an object as changed.
    /// </summary>
    public static void SetChanged(string objectId)
    {
        instance.changedObjects[objectId] = true;
    }

    /// <summary>
    /// Check if an object has been changed.
    /// </summary>
    public static bool IsChanged(string objectId)
    {
        return instance.changedObjects.ContainsKey(objectId) && instance.changedObjects[objectId];
    }
}