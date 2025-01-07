using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public int level;
    public int xpToNext;
    public int stage;
    public int xp;
    public GameObject levelSys;
    public TMP_Text StageText;
    public TMP_Text TrueXPText;
    public TMP_Text LevelStage;
    public TMP_Text xpText;
    private string currentLevelTitle = "LevelTitleDefault_0";
    public void LevelNew()
    {
        PlayerPrefs.SetInt("xp", 0);
        level ++;
        PlayerPrefs.SetInt("level", level);
        LoadLevel();
        //YOU NEED LOADLEVEL() I TRIED TO REMOVE IT AND I HAD LIKE -2000 XP TO NEXT LEVEL
    }
    public void ViewLevelSystem()
    {
        levelSys.SetActive(true);
    }
    public void ReturnFromSys()
    {
        levelSys.SetActive(false);
    }
    public void Start()
    {
        ReturnFromSys();
        LoadLevel();
    }
    public void Save()
    {
        PlayerPrefs.SetInt("level", level);   
    }
    public void LoadLevel()
    {
        xp = PlayerPrefs.GetInt("xp");
        
        level = PlayerPrefs.GetInt("level");


        if(level == 0)
        {
            xpToNext = 200 - PlayerPrefs.GetInt("xp");
        }
        else
        {
            xpToNext = 200 * PlayerPrefs.GetInt("level") - PlayerPrefs.GetInt("xp");
        }
        if(xpToNext <= 0)
        {
            LevelNew();
        }

        TrueXPText.text = "CURRENT XP: " + PlayerPrefs.GetInt("xp");
        xpText.text = "XP TO NEXT LEVEL: " + xpToNext;
        LevelStage.text = "LEVEL: " + PlayerPrefs.GetInt("level");
        
        if (level <= 0)
        {
            stage = 0;
        } 
        else 
        {
            stage = (level - 1) / 10 + 1;
            if (stage > 6) 
            {
                stage = 6;
            }
        }


        switch(stage)
        {
            case 0:
            currentLevelTitle = "EARLY";
            StageText.color = new Color(0, 0.8f, 0.550f);
            break;

            case 1:
            currentLevelTitle = "FLARP";
            StageText.color = Color.white;
            break;

            case 2:
            currentLevelTitle = "GOOD FLARP";
            StageText.color = new Color(0.6f, 1f, 0);
            break;

            case 3:
            currentLevelTitle = "GREAT FLARP";
            StageText.color = new Color(0, 1f, 0.750f);
            break;

            case 4:
            currentLevelTitle = "GREATER FLARP";
            StageText.color = Color.green;
            break;

            case 5:
            currentLevelTitle = "ULTIMATE FLARP";
            StageText.color = new Color (1f, 0, 0.3f);
            break;
            
            case 6:
            currentLevelTitle = "CLIMACTIC FLARP";
            StageText.color = Color.yellow;
            break;

            default:
            currentLevelTitle = "Unknown";
            StageText.color = Color.gray;
            break;
        }

        StageText.text = "STAGE: " + currentLevelTitle + " BIRB";        
    }
}
