using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public GameObject pauseButton;
    public Texture[] countdown_image;
    public Texture waitingForInput;
    public Animator anim;
    public RawImage displayed_image;
    public GameObject scoreText;
    public FlarpScript fs;
    public PipeSpawn pipe;
    public GameObject flarpBirb;
    public RandomMusic randomMusicScript;
    public RectTransform image_rect;
    public NowPlaying np;
    public FireballHardMode fbhm;
    public AudioSource aud;
    public AudioSource waitingMusic;
    void Start()
    {
        scoreText.SetActive(false);
        this.gameObject.SetActive(true);
        fs = flarpBirb.GetComponent<FlarpScript>();
        pauseButton.SetActive(false);
        StartCoroutine(TimerStart());
    }
    IEnumerator TimerStart()
    {
        waitingMusic.Play();
        aud.pitch = 1f;

        anim.Play("countdownLeap");

        image_rect.sizeDelta = new Vector2(400,100);
        displayed_image.texture = waitingForInput;
        yield return new WaitUntil(()=> Input.GetKeyDown(KeyCode.Space));
        waitingMusic.Stop();
        image_rect.sizeDelta = new Vector2(100,100);
        //COUNTDOWN => START GAME
        displayed_image.texture = countdown_image[2];
        aud.Play();
        yield return new WaitForSeconds(1);


        displayed_image.texture = countdown_image[1];
        aud.Play();
        yield return new WaitForSeconds(1);


        displayed_image.texture = countdown_image[0];
        aud.Play();
        yield return new WaitForSeconds(1);
        aud.Play();

        pauseButton.SetActive(true);
        scoreText.SetActive(true);
        fs.FlarpEntireStart();
        pipe.FlarpEntireStart();
        np.FlarpEntireStart();
        fbhm.FlarpEntireStart();
        randomMusicScript.FlarpEntireStart();
        this.gameObject.SetActive(false);
    }
}
