using System;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private static AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public static void Play(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
