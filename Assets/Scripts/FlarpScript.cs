using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class FlarpScript : MonoBehaviour, ISingleton
{
    public static FlarpScript Instance { get; private set; }
    public Rigidbody2D rb;
    public TMP_Text diedToText;
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
    public SpriteRenderer birbrend;
    public float flarpingShit;
    public GameObject flarp;
    public GameObject canvasDef;
    public GameObject canvasDIE;
    public GameObject flarpBG;
    public bool flarpAlive;
    public int RandomType;
    public AudioSource aud;
    public string whatKilled;
    public AudioClip[] flap;
    public Sprite[] birb;
    public AudioClip dead;
    public AudioClip longass_scream;
    public AudioClip specdead;
    public LOGIC LOGICscript;
    public int flapsound;
    public GameObject flarpBirbEyelash;
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
        // MOST TO LEAST COMMON
        if(collider.CompareTag("Pipe"))
        {
            whatKilled = "Pipe";
            FlarpDie();
        }
        else if(collider.CompareTag("Fireball"))
        {
            whatKilled = "Fireball";
            FlarpDie();
        }
        else if(collider.CompareTag("Fall"))
        {
            whatKilled = "Fall";
            FlarpDie();
        }
        else if(collider.CompareTag("LowAirDensity"))
        {
            whatKilled = "Lower Air Density";
            FlarpDie();
        }
    }
    public void FlarpSound()
    {
        flapsound = Random.Range(1, 4);
        aud.PlayOneShot(flap[flapsound]);  
    }
    public void UpdateAudioVolume()
    {
        aud.volume = PlayerPrefs.GetFloat("audioLevel");
    }
    public void Start()
    {
        rb.gravityScale = 0f;

        // sprite/color manager




        int flarpC_local = PlayerPrefs.GetInt("FlarpC");
        bool flarpBGactive;
        switch(flarpC_local)
        {
            case 5:
            {
                customcolor.color = Color.HSVToRGB(PlayerPrefs.GetFloat("colorvalue"), PlayerPrefs.GetFloat("satvalue"), PlayerPrefs.GetFloat("brightvalue"));
                birbrend.sprite = birb[5];
                flarpBGactive = true;
                if(PlayerPrefs.GetInt("lashes") == 1)
                {
                    flarpBirbEyelash.SetActive(true);
                }
                else
                {
                    flarpBirbEyelash.SetActive(false);
                }
                break;
            }
            case 0:
            { 
                birbrend.sprite = birb[Random.Range(1, 4)];
                flarpBGactive = false;
                break;
            }
            default:
            {
                birbrend.sprite = birb[PlayerPrefs.GetInt("FlarpC")];
                flarpBGactive = false;
                break;
            }   
        }
        if(flarpC_local != 5)
        {
            flarpBirbEyelash.SetActive(false);
        }
        flarpBG.SetActive(flarpBGactive);
    }
    public void FlarpEntireStart()
    {   
        rb.gravityScale = 1f;
        XPScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<XPGrant>(); 
        flarpAlive = true;
    }

    public void FlarpDie()
    {
            Destroy(col);
            flarpAlive = false;
            canvasDIE.SetActive(true);
            JumpscareScript.JumpscareDeath();
            PlayerPrefs.SetInt("alltimeflarps", PlayerPrefs.GetInt("alltimeflarps") + LOGICscript.totalflarps);
            PlayerPrefs.SetInt("timesdead", PlayerPrefs.GetInt("timesdead") + 1);
            rb.freezeRotation = false;
            rb.velocity = Vector2.right * 2;
            rb.velocity = Vector2.up * 4.3f;
            rb.MoveRotation(200);
            highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
            XPScript.GrantXP();


            diedToText.text = $"(TO A {whatKilled.ToUpper()})"; 
                    if(Random.Range(1, 1000) == 500)
                    {
                        aud.PlayOneShot(specdead);
                    }
                    else
                    {
                            switch(PlayerPrefs.GetInt("level"))
                            {
                                case 0:
                                {
                                    aud.pitch = 1.04f;
                                    break;
                                }
                                case 1:
                                {
                                    aud.pitch = 1f;
                                    break;
                                }
                                case int n when n > 1:
                                {
                                    aud.pitch = 1 - PlayerPrefs.GetInt("level") * 0.01f; 
                                    break;
                                }
                                case int n when n >= 50:
                                {
                                    aud.pitch = 0.5f;
                                    break;
                                }
                            }

                        if(whatKilled == "Fireball" | whatKilled == "Fall")
                        {
                            aud.PlayOneShot(longass_scream);
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
                            PlayerPrefs.SetInt("trophy2active", 1);  //these have to be here so that the other trophies also unlock
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
                    //no unlock cuz what
                    break;
            }
        canvasDef.SetActive(false);
    }
    private void NewFlarpTrophy(string trophytype)
    {
        PlayerPrefs.SetInt("crowncanactive", 1);
        PlayerPrefs.SetInt(trophytype + "active", 1);
        PlayerPrefs.SetInt("notifnew", 1);
    }
}