using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Audio 
{
    public string name;
    public AudioClip clip;
    public AudioMixerGroup audioMixer;
    [Range(0.0f,1.0f)]
    public float volume;
    [Range(0.1f,3.0f)]
    public float pitch;
    [Range(0.0f, 1.0f)]
    public float spatialBlend;
    public bool loop;
    public bool playOnAwake;

    [HideInInspector]
    public AudioSource audioSource;
}
