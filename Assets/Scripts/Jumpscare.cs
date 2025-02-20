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
        if(UnityEngine.Random.Range(1, 5476) == 5)
        {
            canvasdie.SetActive(false);
            jumpscaretype = 1;
            StartCoroutine(DoJumpscare());      
        }
        else if(UnityEngine.Random.Range(5477, 9200) == 6666 & System.DateTime.Now.Hour == 3)
        {
            canvasdie.SetActive(false);
            jumpscaretype = 2;
            StartCoroutine(DoJumpscare());      
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
                yield return new WaitForSeconds(0.2f);
                theJUMP.SetActive(false);
                SceneManager.LoadScene("MainMenu");
                break;
            }
            case 2:
            {
                theJUMP.SetActive(true);
                imageren.sprite = spookies[1];
                yield return new WaitForSeconds(0.2f);
                theJUMP.SetActive(false);
                SceneManager.LoadScene("MainMenu");
                break;
            }

        }
    }
}
