using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public bool hardmodeactive;
    public bool normactive;
    public bool speedactive;
    public void HardActivate()
    {
        hardmodeactive = true;
        speedactive = false;
        normactive = false;
        Check();
    }
    public void DefActivate()
    {
        hardmodeactive = false;
        normactive = true;
        speedactive = false;
        Check();
    }
    public void SpeedActivate()
    {
        speedactive = true;
        normactive = false;
        hardmodeactive = false;
        Check();
    }
    public void Check()
    {
        if(hardmodeactive == true)
        {
            PlayerPrefs.SetString("Mode", "Hard");
        }
        if(normactive == true)
        {
            PlayerPrefs.SetString("Mode", "Default");
        }
        if(speedactive == true)
        {
            PlayerPrefs.SetString("Mode", "Speed");
        }
    }
}
