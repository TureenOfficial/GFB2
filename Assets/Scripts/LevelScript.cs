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
    public void LevelNew()
    {
        PlayerPrefs.SetInt("xp", 0);
        level ++;
        PlayerPrefs.SetInt("level", level);

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
    }
    public void Save()
    {
        PlayerPrefs.SetInt("level", level);   
    }
    public void Update()
    {
        xp = PlayerPrefs.GetInt("xp");
        
        level = PlayerPrefs.GetInt("level");


        if(level == 0)
        {
            xpToNext = 200 * 1 - PlayerPrefs.GetInt("xp");
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
        
        if(level <= 0)
        {
            stage = 0;
        }
        if(level >= 1 && level < 10)
        {
            stage = 1;
        }
        if(level >= 10 && level < 20)
        {
            stage = 2;
        }
        if(level >= 20 && level < 30)
        {
            stage = 3;
        }
        if(level >= 30 && level < 40)
        {
            stage = 4;
        }
        if(level >= 40 && level < 50)
        {
            stage = 5;
        }
        if(level >= 50)
        {
            stage = 6;
        }



        switch(stage)
        {
            case 0:
            StageText.text = "Stage: " + "Early Birb";
            StageText.color = new Color(0, 0.8f, 0.550f);
            break;

            case 1:
            StageText.text = "Stage: " + "Flarp Birb";
            StageText.color = Color.white;
            break;

            case 2:
            StageText.text = "Stage: " + "Good Flarp Birb";
            StageText.color = new Color(0.6f, 1f, 0);
            break;

            case 3:
            StageText.text = "Stage: " + "Great Flarp Birb";
            StageText.color = new Color(0, 1f, 0.750f);
            break;

            case 4:
            StageText.text = "Stage: " + "Greater Flarp Birb";
            StageText.color = Color.green;
            break;

            case 5:
            StageText.text = "Stage: " + "Ultimate Flarp Birb";
            StageText.color = new Color (1f, 0, 0.3f);
            break;
            
            case 6:
            StageText.text = "Stage: " + "Climax Flarp Birb";
            StageText.color = Color.yellow;
            break;
        }        
    }
}
