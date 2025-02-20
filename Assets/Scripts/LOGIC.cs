using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class LOGIC : MonoBehaviour, ISingleton
{
    public static LOGIC Instance { get; private set; }
    public int totalflarps;
    public TMP_Text text;
    public TMP_Text highscoretext;
    public AudioClip winsound;
    public TMP_Text finaltext;
    public AudioSource aud;
    public FlarpScript fs;
    public int collectableint;
    public AudioSource audiomain;
    public AudioClip pointgained;
    public TMP_Text xpText;
    public Animation animationPointGained;
    public GameObject highscorelight;
    public XPGrant xpGrant;
    public DiscordRPC rpcScript;
    public AnimationClip[] AnimationTypePointGained;
    
    public void Start()
    {
        PlayerPrefs.SetInt("flarpsThisRoundOnly", 0);
        totalflarps = 0;
        fs = GameObject.FindGameObjectWithTag("Player").GetComponent<FlarpScript>(); 
    }
    public void Update()
    {
        text.text = totalflarps.ToString();
        if(totalflarps > PlayerPrefs.GetInt("Highscore", 0))
        {
            text.color = Color.yellow; 
        }
        else
        {
            text.color = Color.white;
        }

        if(!fs.flarpAlive && fs.canvasDIE.activeSelf == true)
        {
            FinalScore();
        }
    }

    [ContextMenu("Increase")]
    public void AddToTotal()
    {
        totalflarps += 1;
        PlayerPrefs.SetInt("flarpsThisRoundOnly", PlayerPrefs.GetInt("flarpsThisRoundOnly") + 1);
        if(PlayerPrefs.GetInt("rpcOn") == 1)
        {
            rpcScript.ChangeActivity();
        }
        aud.PlayOneShot(pointgained, 1.6f);
        if(totalflarps > PlayerPrefs.GetInt("Highscore"))
        {
            animationPointGained.clip = AnimationTypePointGained[1];
            animationPointGained.Play();
        }
        else
        {
            animationPointGained.clip = AnimationTypePointGained[0];
            animationPointGained.Play();
        }

    }
    public void AddCollectable()
    {
        collectableint += 1;
        aud.PlayOneShot(pointgained, 1.6f);
    }

    public void FinalScore()
    {
        StartCoroutine(SlowAudio());
        
        highscoretext.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore").ToString();
        xpText.text = "XP EARNED: " + xpGrant.xpgranted.ToString();
        finaltext.text = "SCORE: " + totalflarps;
    }
    IEnumerator SlowAudio()
    {
        while(audiomain.pitch > 0)
        {
            audiomain.pitch = Mathf.Max(0f, audiomain.pitch - 0.001f);
            yield return new WaitUntil(() => audiomain.pitch == 0);
            audiomain.Stop();
        }
        
        
    }
}
