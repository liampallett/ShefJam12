using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// When a scene loads, removes any items that were already picked up
/// </summary>
public class PickedUpItemCleaner : MonoBehaviour
{
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
        Item[] items = FindObjectsByType<Item>(FindObjectsSortMode.None);

        foreach (var item in items)
        {
            string itemId = scene.name + "_" + item.gameObject.name;
            if (WorldState.IsChanged(itemId))
            {
                Destroy(item.gameObject);
            }
        }
    }
}