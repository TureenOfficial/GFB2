using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{
    public GameObject theJUMP;
    public SpriteRenderer imageren;
    public Sprite[] spookies;
    public AudioSource aud;
    public AudioClip[] jumpscaresound;
    public GameObject canvasdie;
    public int jumpscaretype;
    
    void Start()
    {
        theJUMP.SetActive(false);
    }
    public void JumpscareDeath()
    {
        if(Random.Range(1, 5476) == 5)
        {
            canvasdie.SetActive(false);
            jumpscaretype = 1;
            StartCoroutine(DoJumpscare());      
        }
        else
        {
            jumpscaretype = 0;
        }

    }

    public IEnumerator DoJumpscare()
    {       
        aud.PlayOneShot(jumpscaresound[0]);
        switch(jumpscaretype)
        {
            case 1:
            {
                theJUMP.SetActive(true);
                imageren.sprite = spookies[0];
                yield return new WaitForSeconds(0.4f);
                theJUMP.SetActive(false);
                SceneManager.LoadScene("MainMenu");
                break;
            }
        }
    }
}
