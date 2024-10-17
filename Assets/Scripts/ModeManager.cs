using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    //this script was heavily overcomplicated
    public void HardActivate()
    {
        PlayerPrefs.SetString("Mode", "Hard");
    }
    public void DefActivate()
    {
        PlayerPrefs.SetString("Mode", "Default");
    }
    public void SpeedActivate()
    {
        PlayerPrefs.SetString("Mode", "Speed");
    }
}
