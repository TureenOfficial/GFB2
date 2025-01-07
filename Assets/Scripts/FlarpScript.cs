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
    public Color color;
    public float colort;
    public SpriteRenderer customcolor;
    public XPGrant XPScript;
    public int highscore_;
    public Collider2D col;
    //public Light lg;
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

    }

    public void FlarpDie()
    {
            Destroy(col);
            flarpAlive = false;
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
                {
                    aud.PlayOneShot(specdead);
                }
                else
                {
                    aud.PlayOneShot(dead);
                }
            }

            if (LOGICscript.totalflarps > PlayerPrefs.GetInt("Highscore", 0))
            {
                PlayerPrefs.SetInt("Highscore", LOGICscript.totalflarps);
                highscore_ = PlayerPrefs.GetInt("Highscore");
            }
            //trophies manager on death
            int totalflarps = LOGICscript.totalflarps;
            string trophytype;
            switch(totalflarps)
            {
                    case int t when t >= 1000:
                        if (PlayerPrefs.GetInt("trophy3active") == 0)
                        {
                            trophytype = "trophy3";
                            NewFlarpTrophy(trophytype);
                            PlayerPrefs.SetInt("trophy2active", 1);
                            PlayerPrefs.SetInt("trophy1active", 1);
                        }
                        break;

                    case int t when t >= 500:
                        if (PlayerPrefs.GetInt("trophy2active") == 0)
                        {
                            trophytype = "trophy2";
                            NewFlarpTrophy(trophytype);
                            PlayerPrefs.SetInt("trophy1active", 1);
                        }
                        break;

                    case int t when t >= 100:
                        if (PlayerPrefs.GetInt("trophy1active") == 0)
                        {
                            trophytype = "trophy1";
                            NewFlarpTrophy(trophytype);
                        }
                        break;

                    default:
                    //no unlock
                        break;
            }
        canvasDef.SetActive(false);
    }
    private void NewFlarpTrophy(string trophytype)
    {
        PlayerPrefs.SetInt(trophytype + "active", 1);
        PlayerPrefs.SetInt("notifnew", 1);
    }
}