using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class pauseButton : MonoBehaviour
{   
    public GameObject pbutton;
    public GameObject canvasPause;
    public GameObject spnp;
    public Rigidbody2D rb;
    public AudioSource aud;
    public GameObject ps;
    public bool JohnRoute;


    public void Start()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        spnp.SetActive(true);
        JohnRoute = true;
        Time.timeScale = 1;
    }
    public void Clicked()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        rb.mass = 0;
        Time.timeScale = 0;
        spnp.SetActive(false);
        JohnRoute = false;
        ps.SetActive(false);
        aud.Pause();
        pbutton.SetActive(false);
        canvasPause.SetActive(true);
    }
    public void ReturnClick()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.mass = 1;
        Time.timeScale = 1;
        spnp.SetActive(true);
        JohnRoute = true;
        ps.SetActive(true);
        aud.UnPause();
        pbutton.SetActive(true);
        canvasPause.SetActive(false);
    }
}
