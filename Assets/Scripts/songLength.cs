using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class songLength : MonoBehaviour
{
    public TMP_Text songName;
    public TMP_Text remainder;
    public Slider audioPlaybackPercentageSlider;
    public AudioSource musicAud;
    void Start()
    {
        NewAudio();
        this.gameObject.SetActive(false);
    }
    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return $"{minutes}:{seconds:D2}";
    }    
    public void NewAudio()
    {
        this.gameObject.SetActive(true);
        songName.text = PlayerPrefs.GetString("songName").ToUpper();
        remainder.text = $"0:00/0:00";
        audioPlaybackPercentageSlider.value = 0f;
    }
    void Update()
    {
        if(musicAud.isPlaying)
        {       
                audioPlaybackPercentageSlider.maxValue = musicAud.clip.length;
                float playbackPercentFloat = musicAud.time;
                remainder.text = $"{FormatTime(musicAud.time)}/{FormatTime(musicAud.clip.length)}";
                audioPlaybackPercentageSlider.value = playbackPercentFloat;
        }
    }
}
