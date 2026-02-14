using UnityEngine;

/// <summary>
/// Attach this to an object in the PRESENT scene.
/// On scene load, checks WorldState and swaps the sprite if the
/// matching object was changed in the past.
/// </summary>
public class PresentObject : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string objectId;
    [SerializeField] private Sprite changedSprite;

    private void Start()
    {
        if (WorldState.IsChanged(objectId))
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null && changedSprite != null)
            {
                sr.sprite = changedSprite;
            }
        }
    }
}