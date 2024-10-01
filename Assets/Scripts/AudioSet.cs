using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSet : MonoBehaviour
{
    public AudioSource aud;
    public void Start()
    {
        aud.volume = PlayerPrefs.GetFloat("audioLevel");
    }
}
