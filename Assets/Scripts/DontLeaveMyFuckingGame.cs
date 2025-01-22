using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DontLeaveMyFuckingGame : MonoBehaviour
{
    public float alpha;
    public AudioSource aud;
    public AudioSource MenuAud;
    public GameObject FLARPBIRB;
    public RawImage JumpscareImage;
    
    public void Update()
    {
        JumpscareImage.color = new Color(1f,1f,1f,alpha);
    }
    public void Start()
    {
        FLARPBIRB.SetActive(false);
    }
    public void FlarpBirbScaresYou()
    {
        if(Random.Range(1,1000) == 7)
        {
            FLARPBIRB.SetActive(true);
            MenuAud.Pause();
            aud.pitch = 0.25f;
            aud.Play();
            StartCoroutine(FLARPBIRBJUMPSCARE());
        }
        else
        {
            Application.Quit();
        }
    }
    IEnumerator FLARPBIRBJUMPSCARE()
    {
        alpha = 1f;
        MenuAud.volume = 0f;
        yield return new WaitForSeconds(0.5f);
        while (alpha > 0f)
        {
            yield return new WaitForSeconds(0.05f);
            alpha = Mathf.Min(alpha - 0.05066f, 1);
        }
        if(alpha <= 0f)
        {
            FLARPBIRB.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            MenuAud.UnPause();

            while(MenuAud.volume < PlayerPrefs.GetFloat("audioLevel"))
            {
                yield return new WaitForSeconds(0.05f);
                MenuAud.volume = Mathf.Min(MenuAud.volume + 0.005f, PlayerPrefs.GetFloat("audioLevel")); 
            }
        }
    }
}
