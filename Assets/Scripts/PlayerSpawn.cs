using UnityEngine;

/// <summary>
/// Attach this to the Player object in every scene.
/// Places the player at their saved position when the scene loads.
/// </summary>
public class PlayerSpawn : MonoBehaviour
{
    private void Start()
    {
        if (SceneTransition.TryGetSavedPosition(out Vector3 position))
        {
            transform.position = position;
        }
    }
}