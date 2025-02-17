using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    //Wow thats  A Lot!  Lot!     Lot!
    public float audVelocity;
    public  GameObject discordRPCobject;
    public GameObject headwearDropdown;
    public UnityEngine.UI.Toggle lyricalcensortoggle;
    public UnityEngine.UI.Toggle cloudToggle;
    public UnityEngine.UI.Toggle discordRPCToggle;
    public bool fullscreen;
    public int res;
    public int hz;
    public int currentCN;
    public GameObject eyelashBIRB;
    public TMP_InputField field;
    public TMP_Dropdown fpsDrop;
    public string flarpname;
    public TMP_Dropdown resdropdown;
    public UnityEngine.UI.Slider slide;
    public UnityEngine.UI.Slider rgbslide;
    public UnityEngine.UI.Slider satslide;
    public UnityEngine.UI.Slider valslide;
    public UnityEngine.UI.RawImage huecolorprev;
    public UnityEngine.UI.RawImage satcolorprev;
    public UnityEngine.UI.RawImage valcolorprev;
    public GameObject[] colorsliders;
    public UnityEngine.UI.Toggle fullscreentog;
    public UnityEngine.UI.Toggle eyelashToggle;
    public UnityEngine.UI.Toggle vsync;
    public GameObject canvasColorEdit;
    public RawImage rgbhandle;
    public RawImage sathandle;
    public RawImage valhandle;
    // TODO public Toggle clouds;
    public TMP_Dropdown dropdownCN;
    public TMP_Dropdown dropdownFC;
    public TMP_Text leveltext;
    public int flarpColor;
    public TMP_Text huetext;
    private int lashesAreOn;
    public TMP_Text sattext;
    public TMP_Text valtext;
    public GameObject ays;
    public GameObject ddflt;
    public TMP_Text flarpDesignerText;
    public Color _Color;
    public UnityEngine.UI.RawImage flarpbirbdesignerHeader;
    public TMP_Text highscoreText;
    public int FHActive;
    public int fullscreenint;
    //public FlarpHighscore fhs;

    public void Update()
    {
        audVelocity = slide.value;
        if(PlayerPrefs.GetInt("Highscore") >= 10000)
        {
            highscoreText.text = "HIGHSCORE: " + "10K+";
        }
        else
        {
            highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore").ToString();
        }
        PlayerPrefs.SetFloat("colorvalue", rgbslide.value); 
        PlayerPrefs.SetFloat("satvalue", satslide.value);
        PlayerPrefs.SetFloat("brightvalue", valslide.value);
        PlayerPrefs.SetInt("FlarpC", flarpColor);
        huetext.text = $"HUE ({rgbslide.value:F2})";
        sattext.text = $"SAT ({satslide.value:F2})";
        valtext.text = $"VAL ({valslide.value:F2})";

        
        _Color = Color.HSVToRGB(
            PlayerPrefs.GetFloat("colorvalue"),
            PlayerPrefs.GetFloat("satvalue"),
            PlayerPrefs.GetFloat("brightvalue")
        );

        if(PlayerPrefs.GetInt("FlarpC") == 5)
        {
            headwearDropdown.transform.localPosition = new Vector3 (197, -100, 0);
            flarpbirbdesignerHeader.color = _Color;
            if(_Color == Color.HSVToRGB(_Color.r, 0f, 1f))
            {
                flarpDesignerText.color = Color.black;
            }
            else
            {
                flarpDesignerText.color = Color.white;
            }
        }
        else
        {
            headwearDropdown.transform.localPosition = new Vector3(197, 0, 0);
            flarpbirbdesignerHeader.color = new Color(1, 0, 0.35f);
        }
        
        // New color preview feature
        huecolorprev.color = new Color(rgbslide.value, 1, 1);
        satcolorprev.color = new Color(1, satslide.value, 1);
        valcolorprev.color = new Color(1, 1, valslide.value);

        foreach (var slider in colorsliders)
        {
            slider.SetActive(flarpColor == 5);
        }

    }
    public void ChangeName()
    {
        flarpname = field.text;
        if(flarpname == "")
        {
            PlayerPrefs.SetString("flarpname", "Birb");  //ensures no blank name
        }
        else
        {
            PlayerPrefs.SetString("flarpname", flarpname);
        }
    }
    public void FPSToggle()
    {
        int fps = 0;
        switch(fpsDrop.value)
        {
            case 0:
            {
                fps = 60;
                break;
            }
            case 1:
            {
                fps = 100;

                break;
            }
            case 2:
            {
                fps = 144;

                break;
            }
            case 3:
            {
                fps = 165;

                break;
            }
            case 4:
            {
                fps = 240;

                break;
            }
            case 5:
            {
                fps = -1;

                break;
            }
        }
        PlayerPrefs.SetInt("fps", fpsDrop.value);
        Application.targetFrameRate = fps;
    }
    public void CNUpdate()
    {
        currentCN = dropdownCN.value;
    }
    public void ActivateColor()
    {
        canvasColorEdit.SetActive(true);
        
    }
    public void FCUpdate()
    {
        flarpColor = dropdownFC.value;
    }
    public void SaveJustFlarpC()
    {
        PlayerPrefs.SetInt("FlarpC", flarpColor);
    }
    public void SaveFlarpCSliders()
    {
        PlayerPrefs.SetFloat("satvalue", satslide.value);
        PlayerPrefs.SetFloat("brightvalue", valslide.value);
        PlayerPrefs.SetFloat("colorvalue", rgbslide.value);
    }
    public void LyricalCensors()
    {
        if(lyricalcensortoggle.isOn)
        {
            PlayerPrefs.SetInt("OffensiveItems", 1);
        }
        else
        {
            PlayerPrefs.SetInt("OffensiveItems", 0);
        }
    }
    public void CloudToggle()
    {
        if(cloudToggle.isOn)
        {
            PlayerPrefs.SetInt("cloudsActive", 1);
        }
        else
        {
            PlayerPrefs.SetInt("cloudsActive", 0);
        }
    }
    public void DiscordRPCToggle()
    {
        if(discordRPCToggle.isOn)
        {
            PlayerPrefs.SetInt("rpcOn", 1);
        }
        else
        {
            PlayerPrefs.SetInt("rpcOn", 0);
        }
    }
    public void EyelashToggle()
    {
        if(eyelashToggle.isOn)
        {
            PlayerPrefs.SetInt("lashes", 1);
            lashesAreOn = 1;
        }
        else
        {
            PlayerPrefs.SetInt("lashes", 0);
            lashesAreOn = 0;
        }
        eyelashBIRB.SetActive(eyelashToggle.isOn);
        
    }
    public void Start()
    {
        Load();
    }
    public void Load()
    {
            // START TOGGLES
            lashesAreOn = Convert.ToInt32(eyelashToggle.isOn);
            if(PlayerPrefs.GetInt("OffensiveItems") == 1)
            {
                lyricalcensortoggle.isOn = true;
            }
            else
            {
                lyricalcensortoggle.isOn = false;
            }
            if(PlayerPrefs.GetInt("rpcOn") == 1)
            {
                discordRPCToggle.isOn = true;
            }
            else
            {
                discordRPCToggle.isOn = false;
            }
            if(PlayerPrefs.GetInt("cloudsActive") == 1)
            {
                cloudToggle.isOn = true;
            }
            else
            {
                cloudToggle.isOn = false;
            }

            if(PlayerPrefs.GetInt("lashes") == 1)
            {
                eyelashToggle.isOn = true;
            }
            else
            {
                eyelashToggle.isOn = false;
            }
            // END TOGGLES

            fullscreenint = PlayerPrefs.GetInt("fullscreen");
            slide.value = PlayerPrefs.GetFloat("audioLevel");
            dropdownCN.value = PlayerPrefs.GetInt("currentCN");
            dropdownFC.value = PlayerPrefs.GetInt("FlarpC");
            flarpColor = dropdownFC.value;
            leveltext.text = "LEVEL: " + PlayerPrefs.GetInt("level");
            rgbslide.value = PlayerPrefs.GetFloat("colorvalue");
            satslide.value = PlayerPrefs.GetFloat("satvalue");
            valslide.value = PlayerPrefs.GetFloat("brightvalue");
            field.text = PlayerPrefs.GetString("flarpname");
            fpsDrop.value = PlayerPrefs.GetInt("fps");
            //rgbhandle.color = Color.HSVToRGB(rgbslide.value, 1, 1);
    }   
    public void Defaults()
    {   
            PlayerPrefs.SetInt("rpcOn", 0);
            PlayerPrefs.SetInt("cloudsActive", 1);
            PlayerPrefs.SetInt("OffensiveItems", 0);
            PlayerPrefs.SetInt("fps", 5);
            PlayerPrefs.SetInt("Highscore", 0);
            PlayerPrefs.SetFloat("audioLevel", 0.70f);
            PlayerPrefs.SetInt("currentCN", 0);
            PlayerPrefs.SetInt("FlarpC", 1);
            PlayerPrefs.SetInt("level", 0);
            PlayerPrefs.SetFloat("satvalue", 0.800f);
            PlayerPrefs.SetFloat("colorvalue", 0.450f);
            PlayerPrefs.SetFloat("brightvalue", 1);
            PlayerPrefs.SetInt("lashes", 0);
            PlayerPrefs.SetString("flarpname", "Birb");
            PlayerPrefs.SetInt("timesdead", 0);
            PlayerPrefs.SetInt("trophy1active", 0);
            PlayerPrefs.SetInt("trophy2active", 0);
            PlayerPrefs.SetInt("trophy3active", 0);
            PlayerPrefs.SetString("Mode", "Default");
            PlayerPrefs.SetInt("alltimeflarps", 0);
            PlayerPrefs.SetString("headwear", "None");
            PlayerPrefs.SetInt("crowncanactive", 0);
    }
    public void DeleteAll()
    {
        ays.SetActive(false);
        CheckForData();
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("audioLevel", audVelocity);
        PlayerPrefs.SetInt("currentCN", currentCN);
        PlayerPrefs.SetInt("FlarpC", flarpColor);
        PlayerPrefs.SetFloat("satvalue", satslide.value);
        PlayerPrefs.SetFloat("brightvalue", valslide.value);
        PlayerPrefs.SetFloat("colorvalue", rgbslide.value);
        PlayerPrefs.SetInt("lashes", lashesAreOn);
    }
    
    public void AreYouSureMenu()
    {
        ays.SetActive(true);
    }
    public void ReturnMenu()
    {
        FullReturn();
    }
    public void CheckForData()
    {   
    
        //subject for readability
        bool isDefaultState = 
        PlayerPrefs.GetInt("rpcOn") == 1 &&
        PlayerPrefs.GetInt("cloudsActive") == 1 &&
        PlayerPrefs.GetInt("lashes") == 0 &&
        PlayerPrefs.GetInt("fps") == 5 &&
        PlayerPrefs.GetInt("alltimeflarps") == 0 &&
        PlayerPrefs.GetFloat("audioLevel") == 0.70f &&
        PlayerPrefs.GetInt("currentCN") == 0 &&
        PlayerPrefs.GetInt("FlarpC") == 1 &&
        PlayerPrefs.GetInt("Highscore") == 0 &&
        PlayerPrefs.GetInt("level") == 0 &&
        PlayerPrefs.GetString("flarpname") == "Birb" &&
        PlayerPrefs.GetString("headwear") == "None" &&
        PlayerPrefs.GetInt("crowncanactive") == 0 &&
        PlayerPrefs.GetInt("trophy1active") == 0 &&
        PlayerPrefs.GetInt("trophy2active") == 0 &&
        PlayerPrefs.GetInt("trophy3active") == 0;

        if(isDefaultState)
        {
            ays.SetActive(false);
            ddflt.SetActive(true);
        }
        else
        {
            PlayerPrefs.DeleteAll();
            Defaults();
            Load();
        }
    }
    public void FullReturn()
    {
        canvasColorEdit.SetActive(false);
        ddflt.SetActive(false);
        ays.SetActive(false);
        Load(); 
    }

}