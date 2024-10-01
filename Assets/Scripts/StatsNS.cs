using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsNS : MonoBehaviour
{
    public GameObject notif;
    private void Start()
    {
        LoadNotifs();
    }
    public void LoadNotifs()
    {
        if(PlayerPrefs.GetInt("notifnew") == 1)
        {
            notif.SetActive(true);
        }
        else
        {
            notif.SetActive(false);
        }
    }

    public void ResetNotifs()
    {
        PlayerPrefs.SetInt("notifnew", 0);
        LoadNotifs();
    }
}
