using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the on-screen inventory display.
/// Attach this to the InventoryPanel GameObject in your Canvas.
/// Place your Slot prefab in Assets/Resources and name it "Slot".
/// </summary>
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;

    private List<GameObject> slotInstances = new List<GameObject>();

    private void Awake()
    {
        if (slotPrefab == null)
        {
            slotPrefab = Resources.Load<GameObject>("Slot");
        }

        if (slotParent == null)
        {
            slotParent = transform;
        }
    }

    /// <summary>
    /// Call this whenever the inventory changes to refresh the display.
    /// </summary>
    public void UpdateUI(List<InventoryItem> items)
    {
        if (slotPrefab == null)
        {
            slotPrefab = Resources.Load<GameObject>("Slot");
            if (slotPrefab == null)
            {
                Debug.LogError("Slot prefab not found! Place it in Assets/Resources and name it 'Slot'.");
                return;
            }
        }

        // Remove only tracked slots
        foreach (var slot in slotInstances)
        {
            if (slot != null)
            {
                Destroy(slot);
            }
        }
        slotInstances.Clear();

        // Wait a frame then create new slots
        StartCoroutine(CreateSlots(items));
    }

    private System.Collections.IEnumerator CreateSlots(List<InventoryItem> items)
    {
        // Wait one frame for Destroy to complete
        yield return null;

        foreach (var item in items)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);
            slot.SetActive(true);
            slotInstances.Add(slot);

            SlotUI slotUI = slot.GetComponent<SlotUI>();
            if (slotUI != null && slotUI.iconImage != null && item.icon != null)
            {
                slotUI.iconImage.sprite = item.icon;
                slotUI.iconImage.color = Color.white;
                slotUI.iconImage.enabled = true;
            }
        }
    }
}