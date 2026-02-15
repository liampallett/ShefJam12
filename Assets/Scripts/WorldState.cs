using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tracks which objects have been changed by item usage
/// </summary>
public class WorldState : MonoBehaviour
{
    private static WorldState instance;

    // Stores which objects have been changed
    private static Dictionary<string, bool> changedObjects = new Dictionary<string, bool>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    /// Mark an object as changed.
    public static void SetChanged(string objectId)
    {
        changedObjects[objectId] = true;
    }

    /// Check if an object has been changed.
    public static bool IsChanged(string objectId)
    {
        return changedObjects.ContainsKey(objectId) && changedObjects[objectId];
    }
}