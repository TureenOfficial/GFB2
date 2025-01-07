using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomMusic : MonoBehaviour
{
    public AudioSource aud;
    public int currentCN;
    public AudioClip[] audioClips;
    public AudioClip[] audioClipsNonOffensive;
    public FlarpScript fs;
    public NowPlaying np;
    public Button skipButton;
    private void Start()
    {
        InitializeAudioSettings();
        UpdateSkipButtonInteractable();
        NewMusic();
    }
    private void InitializeAudioSettings()
    {
        aud.volume = PlayerPrefs.GetFloat("audioLevel");
    }

    private void UpdateSkipButtonInteractable()
    {
        skipButton.interactable = PlayerPrefs.GetInt("currentCN") == 0;
    }
    public void Skip()
    {
        aud.Pause();
        NewMusic();
    }
    public void NewMusic()
    {
        currentCN = PlayerPrefs.GetInt("currentCN");
        aud.clip = GetSelectedClip();
        
        PlayerPrefs.SetString("songName", aud.clip.name);
        np.DisplayMusicName();

        aud.Play();
    }
    private AudioClip GetSelectedClip()
    {
        if(PlayerPrefs.GetInt("OffensiveItems") == 1)
        {
            if (currentCN == 0)
            {
                return audioClips[Random.Range(1, audioClips.Length)];
            }
            else
            {
                return audioClips[currentCN];
            }
        }
        else
        {
            if (currentCN == 0)
            {
                return audioClipsNonOffensive[Random.Range(1, audioClipsNonOffensive.Length)];
            }
            else
            {
                return audioClipsNonOffensive[currentCN];
            }
        }
    }
}
