using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioLength : MonoBehaviour
{
    public AudioSource aud;
    public Sprite spritenorm;
    public Sprite spritemuted;
    public Slider slider;
    public Image handle;
    public void Start()
    {
        slider.value = PlayerPrefs.GetFloat("audioLevel");
    }

    public void Update()
    {
        aud.volume = slider.value;

        if(slider.value != 0){handle.sprite = spritenorm;}
        else{handle.sprite = spritemuted;}
    }
    public void AVerySpecificFunctionThatOnlyAppearsHere()
    {
        PlayerPrefs.SetFloat("audioLevel", slider.value);
    }
}
