using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FlarpScript : MonoBehaviour, ISingleton
{
    public static FlarpScript Instance { get; private set; }
    public Rigidbody2D rb;
    public GameObject lashgo;
    public Jumpscare JumpscareScript;
    public int lashenabled;
    public GameObject crown;
    public Color color;
    public float colort;
    public SpriteRenderer customcrown;
    public Sprite[] crownsprites;
    public SpriteRenderer customcolor;
    public XPGrant XPScript;
    public int highscore_;
    public Collider2D cl;
    //public Light lg;          THIS WAS ORIGINALLY GUNNA BE A FEATURE WHERE FLARP WOULD GLOW DEPENDING HOW GOOD YOUR SCORE WAS
    public int timesPlayedDeadSound;
    public SpriteRenderer birbrend;
    public float flarpingShit;
    public GameObject flarp;
    public GameObject canvasDef;
    public GameObject canvasDIE;
    public GameObject flarpBG;
    public bool flarpAlive;
    public int RandomType;
    public AudioSource aud;
    public AudioClip[] flap;
    public Sprite[] birb;
    public AudioClip dead;
    public AudioClip specdead;
    public LOGIC LOGICscript;
    public int flapsound;
    public pauseButton pbs;
    public TMP_Text highscoreText;
    public void Update()
    {
        //colort(PlayerPrefs.GetString("")) ;

        if(flarpAlive && pbs.JohnRoute == true)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = Vector2.up * flarpingShit;
                FlarpSound();
            }
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.up * flarpingShit;
                FlarpSound();
            }
            
        }
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Pipe"))
        {
            FlarpDie();
        }
    }
    public void FlarpSound()
    {
        flapsound = Random.Range(1, 4);
        aud.PlayOneShot(flap[flapsound]);  
    }
    public void Start()
    {   
        if (PlayerPrefs.GetInt("lashes") == 1 && PlayerPrefs.GetInt("FlarpC") == 5)
        {
            lashenabled = true;
        }
        else
        {
            lashenabled = false;
        }
        if (PlayerPrefs.GetInt("crownactive") == 1 && PlayerPrefs.GetInt("crowncanactive") == 1)
        {
            crown.SetActive(true);
        }
        else
        {
            crown.SetActive(false);
        }
        
        XPScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<XPGrant>(); 
        flarpAlive = true;
        timesPlayedDeadSound = 0;
        

        if(PlayerPrefs.GetInt("FlarpC") == 0)
        {
            birbrend.sprite = birb[Random.Range(1, 4)];
            flarpBG.SetActive(false);
        }
        else
        {
            birbrend.sprite = birb[PlayerPrefs.GetInt("FlarpC")];
            flarpBG.SetActive(false);
        }
        if(PlayerPrefs.GetInt("FlarpC") == 5)
        {
            flarpBG.SetActive(true);
            customcolor.color = Color.HSVToRGB(PlayerPrefs.GetFloat("colorvalue"), PlayerPrefs.GetFloat("satvalue"), PlayerPrefs.GetFloat("brightvalue"));
        }

        if(lashenabled == 1)
        {
            lashgo.SetActive(true);
        }
        else
        {
            lashgo.SetActive(false);
        }

    }

    public void FlarpDie()
    {
            canvasDIE.SetActive(true);
            JumpscareScript.JumpscareDeath();
            PlayerPrefs.SetInt("alltimeflarps", PlayerPrefs.GetInt("alltimeflarps") + LOGICscript.totalflarps);
            PlayerPrefs.SetInt("timesdead", PlayerPrefs.GetInt("timesdead") + 1);
            timesPlayedDeadSound ++;
            rb.freezeRotation = false;
            rb.velocity = (Vector2.right * 2);
            rb.velocity = (Vector2.up * 4.3f);
            rb.MoveRotation(200);
            highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
            XPScript.GrantXP();
        
            if(timesPlayedDeadSound !> 1)
            {
                if(Random.Range(1, 1000) == 500)
                {aud.PlayOneShot(specdead);}

                else
                {aud.PlayOneShot(dead);}

               
            }

            if (LOGICscript.totalflarps > PlayerPrefs.GetInt("Highscore", 0))
            {
                PlayerPrefs.SetInt("Highscore", LOGICscript.totalflarps);
                highscore_ = PlayerPrefs.GetInt("Highscore");
            }
            if (LOGICscript.totalflarps >= 100 && PlayerPrefs.GetInt("crownactive") == 0 && PlayerPrefs.GetInt("crowncanactive") == 0)
            {
                PlayerPrefs.SetInt("crownactive", 1);
                PlayerPrefs.SetInt("crowncanactive", 1);
            }
            
            //trophies

            if (LOGICscript.totalflarps >= 100 && PlayerPrefs.GetInt("trophy1active") == 0)
            {
                PlayerPrefs.SetInt("trophy1active", 1);
                PlayerPrefs.SetInt("notifnew", 1);
            }
            if (LOGICscript.totalflarps >= 500 && PlayerPrefs.GetInt("trophy2active") == 0)
            {
                PlayerPrefs.SetInt("trophy2active", 1);
                PlayerPrefs.SetInt("notifnew", 1);
            }
            if (LOGICscript.totalflarps >= 1000 && PlayerPrefs.GetInt("trophy3active") == 0)
            {
                PlayerPrefs.SetInt("trophy3active", 1);
                PlayerPrefs.SetInt("notifnew", 1);
            }


            
        flarpAlive = false;
        canvasDef.SetActive(false);
        Destroy(cl);
    }


}
