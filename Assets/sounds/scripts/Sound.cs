using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [Range(0f, 1f)]
    public float SpatialBlend;

    [Header("3D Sound Settings")]
    [Space]

    [Range(0f, 5f)]
    public float DopplerLevel;

    [Range(0f, 360f)]
    public float Spread;

    [Range(0f, 11000f)]
    public float MinDistance;

    [Range(0f, 11000f)]
    public float MaxDistance;

    [HideInInspector]
    public AudioSource source;

}
