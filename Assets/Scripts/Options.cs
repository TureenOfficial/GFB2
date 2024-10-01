using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    //Wow thats  A Lot!  Lot!     Lot!
    public float audVelocity;
    public bool fullscreen;
    public int res;
    public int hz;
    public int currentCN;
    public GameObject eyelashBIRB;
    public TMP_InputField field;
    public string flarpname;
    public TMP_Dropdown resdropdown;
    public UnityEngine.UI.Slider slide;
    public UnityEngine.UI.Slider rgbslide;
    public UnityEngine.UI.Slider satslide;
    public UnityEngine.UI.Slider valslide;
    public GameObject[] colorsliders;
    public GameObject crown;
    public Toggle fullscreentog;
    public Toggle vsync;
    public GameObject canvasColorEdit;
    public RawImage rgbhandle;
    public RawImage sathandle;
    public RawImage valhandle;
    public Toggle toglash;
    public float customcolorval;
    public TMP_Dropdown dropdownCN;
    public TMP_Dropdown dropdownFC;
    public TMP_Text leveltext;
    public int flarpColor;
    public TMP_Text huetext;
    public TMP_Text sattext;
    public TMP_Text valtext;
    public GameObject ays;
    public GameObject ddflt;
    public TMP_Text highscoreText;
    public bool lashactivebool;
    public Toggle togcrown;
    public GameObject crowntoggle;
    public bool crownactivebool;
    public int FHActive;
    public int fullscreenint;
    //public FlarpHighscore fhs;

    public void Update()
    {
        crown.SetActive(crownactivebool);
        Application.targetFrameRate = hz;
        audVelocity = slide.value;
        highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore").ToString();
        customcolorval = rgbslide.value;
        PlayerPrefs.SetFloat("colorvalue", customcolorval); 
        PlayerPrefs.SetFloat("satvalue", satslide.value);
        PlayerPrefs.SetFloat("brightvalue", valslide.value);
        PlayerPrefs.SetInt("FlarpC", flarpColor);
        huetext.text = "HUE (" + Math.Round(customcolorval, 3).ToString() + ")";
        sattext.text = "SAT (" + Math.Round(satslide.value, 3).ToString() + ")";
        valtext.text = "VAL (" + Math.Round(valslide.value, 3).ToString() + ")";
        

        if(PlayerPrefs.GetInt("FlarpC") == 5)
        {
            foreach(GameObject Object in colorsliders) 
            {
                Object.SetActive(true);
            }
        }
        else
        {   
            foreach(GameObject Object in colorsliders) 
            {
                Object.SetActive(false);
            }
        }

        if(PlayerPrefs.GetInt("crowncanactive") == 1)
        {
            crowntoggle.SetActive(true);
        }
        else
        {
            crowntoggle.SetActive(false);
        }

    }
    public void LoadEyelash()
    {
        toglash.isOn = lashactivebool;
    }
    public void ChangeName()
    {
        flarpname = field.text;
        PlayerPrefs.SetString("flarpname", flarpname);
    }
    public void ChangeEyelashToggle()
    {
        if(toglash.isOn && flarpColor == 5)
        {   
            PlayerPrefs.SetInt("lashes", 1);
            eyelashBIRB.SetActive(true);
            lashactivebool = true;
        }
        else
        {
            PlayerPrefs.SetInt("lashes", 0);
            eyelashBIRB.SetActive(false);
            lashactivebool = false;
        }
    }
    public void CrownToggle()
    {
        crownactivebool = togcrown.isOn;
        if(crownactivebool == true)
        {
            PlayerPrefs.SetInt("crownactive", 1);
        }
        else
        {
            PlayerPrefs.SetInt("crownactive", 0);
        }
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
        if(flarpColor != 5)
        {
            lashactivebool = false;
            eyelashBIRB.SetActive(false);
        }
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
    public void Start()
    {
        Load();
    }
    public void Load()
    {
            if(PlayerPrefs.GetInt("crowncanactive") == 1)
            {
                crowntoggle.SetActive(true);
            }
            else
            {
                crowntoggle.SetActive(false);
            }
            togcrown.isOn = crownactivebool;
            ChangeEyelashToggle();
            fullscreenint = PlayerPrefs.GetInt("fullscreen");
            if(fullscreenint == 0)
            {
                fullscreen = true;
            }
            else
            {
                fullscreen = false;
            }
            slide.value = PlayerPrefs.GetFloat("audioLevel");
            dropdownCN.value = PlayerPrefs.GetInt("currentCN");
            dropdownFC.value = PlayerPrefs.GetInt("FlarpC");
            flarpColor = dropdownFC.value;
            leveltext.text = "LEVEL: " + PlayerPrefs.GetInt("level");
            rgbslide.value = PlayerPrefs.GetFloat("colorvalue");
            satslide.value = PlayerPrefs.GetFloat("satvalue");
            valslide.value = PlayerPrefs.GetFloat("brightvalue");
            field.text = PlayerPrefs.GetString("flarpname");
            //rgbhandle.color = Color.HSVToRGB(rgbslide.value, 1, 1);
    }   
    public void Defaults()
    {
            PlayerPrefs.SetInt("Highscore", 0);
            PlayerPrefs.SetFloat("audioLevel", 0.70f);
            PlayerPrefs.SetInt("crownactive", 0);
            PlayerPrefs.SetInt("crowncanactive", 0);
            PlayerPrefs.SetInt("currentCN", 0);
            PlayerPrefs.SetInt("FlarpC", 1);
            PlayerPrefs.SetInt("level", 0);
            PlayerPrefs.SetFloat("satvalue", 1);
            PlayerPrefs.SetFloat("colorvalue", 0);
            PlayerPrefs.SetFloat("brightvalue", 1);
            PlayerPrefs.SetInt("lashes", 0);
            PlayerPrefs.SetInt("crownactive", 0);
            PlayerPrefs.SetString("flarpname", "Birb");
            PlayerPrefs.SetInt("timesdead", 0);
            PlayerPrefs.SetInt("trophy1active", 0);
            PlayerPrefs.SetInt("trophy2active", 0);
            PlayerPrefs.SetInt("trophy3active", 0);
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
        if(PlayerPrefs.GetFloat("audioLevel") == 0.70f && PlayerPrefs.GetInt("currentCN") == 0 && PlayerPrefs.GetInt("FlarpC") == 1 && PlayerPrefs.GetInt("Highscore") == 0 && PlayerPrefs.GetInt("level") == 0 && PlayerPrefs.GetString("flarpname") == "Birb" && PlayerPrefs.GetInt("trophy1active") == 0 && PlayerPrefs.GetInt("trophy2active") == 0 && PlayerPrefs.GetInt("trophy3active") == 0)
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
