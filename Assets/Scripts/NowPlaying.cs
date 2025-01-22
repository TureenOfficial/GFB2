using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class NowPlaying : MonoBehaviour
{
    
    public TMP_Text musictext;
    public string currentsong;
    public Animation anim;
    public GameObject nowplayingtext;
    public AudioSource aud;

    public void FlarpEntireStart()
    {
        this.gameObject.SetActive(true);
        DisplayMusicName();
    }
    public void DisplayMusicName()
    {
        musictext.text = "NOW PLAYING: " + PlayerPrefs.GetString("songName");
        anim = nowplayingtext.GetComponent<Animation>();
        PlayMusicName();
    }
    public void PlayMusicName()
    {
        //restarts the animation so if the animation is on the last frame you can actually see the song name lol
        
        if(!anim.isPlaying)
        {
            anim.Play();
        }
        else
        {
            anim.Stop();
            anim.Play();
        }
    }
}
