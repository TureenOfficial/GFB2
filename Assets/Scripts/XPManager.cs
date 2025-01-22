using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPManager : MonoBehaviour
{
    public int xp;
    void Update()
    {
        PlayerPrefs.SetInt("XP", xp);
    }
}
