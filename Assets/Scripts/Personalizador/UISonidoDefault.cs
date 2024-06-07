using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UISonidoDefault : MonoBehaviour
{
    public static UISonidoDefault singleton;
    AudioSource aSource;

    public AudioClip[] audios;

    private void Awake()
    {
        singleton = this;
        aSource = GetComponent<AudioSource>();
    }

    public void ReproducirAudio(int cual)
    {
        if (cual<0 || cual >= audios.Length)
        {
            return;
        }
        aSource.clip = audios[cual];
        aSource.Play();
    }
}
