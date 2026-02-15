using UnityEngine;
using UnityEngine.Tilemaps;

public class coralPresentFixedCheck : MonoBehaviour
{
    public TilemapRenderer wallFixed;
    public TilemapRenderer water;
    public TilemapRenderer coral;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FixPipes.coralFixed)
        {
            wallFixed.enabled = true;
            water.enabled = true;
            coral.enabled = true;
        }
    }
}
