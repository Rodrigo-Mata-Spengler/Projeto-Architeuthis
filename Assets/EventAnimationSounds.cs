using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAnimationSounds : MonoBehaviour
{
    public AudioClip WalkSound;
    public AudioClip DeathSound;

    public AudioSource AudioSource;

    public void Walk()
    {
        AudioSource.PlayOneShot(WalkSound);
        Debug.LogError("foi em");
    }

    public void Death()
    {
        AudioSource.PlayOneShot(DeathSound);
    }
}
