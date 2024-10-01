using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AwardsScript : MonoBehaviour
{
    public RawImage[] trophies;
    public Texture[] trophiessprite;
    public void Start()
    {
        switch(PlayerPrefs.GetInt("trophy1active"))
        {
            case 1:
            trophies[0].texture = trophiessprite[1];
            trophies[0].color = new Color32(60, 25, 0, 255);
            break;
            case 0:
            trophies[0].texture = trophiessprite[0]; 
            trophies[0].color = new Color32(60, 25, 0, 125);
            break;
        }

        switch(PlayerPrefs.GetInt("trophy2active"))
        {
            case 1:
            trophies[1].texture = trophiessprite[1]; 
            trophies[1].color = new Color32(255, 255, 255, 255);
            break;
            case 0:
            trophies[1].texture = trophiessprite[0]; 
            trophies[1].color = new Color32(255, 255, 255, 125);
            break;
        }
                
        switch(PlayerPrefs.GetInt("trophy3active"))
        {
            case 1:
            trophies[2].texture = trophiessprite[1]; 
            trophies[2].color = new Color32(255, 210, 0, 255);
            break;
            case 0:
            trophies[2].texture = trophiessprite[0]; 
            trophies[2].color = new Color32(255, 210, 0, 125);
            break;
        }
    }
}
