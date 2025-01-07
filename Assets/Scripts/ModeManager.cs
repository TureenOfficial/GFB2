using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public string toActivate;
    public void ToActivate()
    {
        PlayerPrefs.SetString("Mode", toActivate);
    }
}
