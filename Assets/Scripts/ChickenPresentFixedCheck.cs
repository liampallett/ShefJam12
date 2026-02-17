using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ChickenPresentFixedCheck : MonoBehaviour
{
    public GameObject chickenFixed;
    public GameObject chickens;

    // Update is called once per frame
    void Update()
    {
        if (FeedChicken.chickensFed)
        {
            chickenFixed.SetActive(true);
            chickens.SetActive(false);
        }
    }
}
