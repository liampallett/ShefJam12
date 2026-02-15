using System.Threading;
using UnityEngine;

public class Overture : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    AudioSource overtureLoop;
    float introTimer;
    bool isPlayingLoop;
    void Start()
    {
        AudioSource[] osts = this.GetComponents<AudioSource>();
        overtureLoop = osts[1];
        introTimer = 0f;
        isPlayingLoop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (introTimer < 6f || isPlayingLoop)
        {
            introTimer += Time.deltaTime;
        }
        else
        {
            isPlayingLoop = true;
            overtureLoop.Play();
        }
    }
}
