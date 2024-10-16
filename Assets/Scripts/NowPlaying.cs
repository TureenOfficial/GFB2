using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NowPlaying : MonoBehaviour
{
    public TMP_Text musictext;
    public string currentsong;
    public Animation anim;
    public GameObject nowplayingtext;
    public AudioSource aud;

    void Start()
    {
        anim = nowplayingtext.GetComponent<Animation>();
        DisplayNewMusic();
    }
    public void DisplayNewMusic()
    {
        currentsong = PlayerPrefs.GetString("currentsong");
        anim.Play("newmusic");
        musictext.text = "NOW PLAYING: " + currentsong;   
    }
}
