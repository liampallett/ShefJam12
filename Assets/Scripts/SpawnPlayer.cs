using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (SpawnManager.hasSpawnPosition)
        {
            rb.position = SpawnManager.spawnPosition;
            SpawnManager.hasSpawnPosition = false;
        }
    }

    void Update()
    {
        Debug.Log(rb.position);
        if (SpawnManager.hasSpawnPosition)
        {
            rb.position = SpawnManager.spawnPosition;
            SpawnManager.hasSpawnPosition = false;
        }
    }

}
