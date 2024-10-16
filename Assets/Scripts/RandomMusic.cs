using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class RandomMusic : MonoBehaviour
{
    public AudioSource aud;
    public int currentCN;
    public AudioClip[] audioClips;
    public FlarpScript fs;
    public NowPlaying np;

    public Button skipButton;

    public void Start()
    {
        if(PlayerPrefs.GetInt("currentCN") == 0)
        {
            skipButton.interactable = true;
        }
        else
        {
            skipButton.interactable = false;
        }
        NewMusic();
    }
    public void Skip()
    {
        NewMusic();
        aud.Pause();
    }
    public void NewMusic()
    {
    //    PlayerPrefs.SetString("currentsong", audioClips[currentCN].);
        currentCN = PlayerPrefs.GetInt("currentCN");
        np.DisplayNewMusic();
        if(PlayerPrefs.GetInt("currentCN") == 0)
        {
            aud.clip = audioClips[Random.Range(1, audioClips.Length)];
        }
        else if(PlayerPrefs.GetInt("currentCN") != 0)
        {
            aud.clip = audioClips[currentCN];
        }
    

        aud.Play();
    }

}
