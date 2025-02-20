using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlarpHeadwear : MonoBehaviour
{
    public SpriteRenderer flarpHeadwear;
    private int flarpHeadwearLocal;
    public GameObject headwear;
    public Sprite[] hatSprites;
    void Start()
    {

        if(PlayerPrefs.GetString("headwear") == "None")
        {
            headwear.SetActive(false);
        }
        else
        {
            headwear.SetActive(true);
        }

        switch(PlayerPrefs.GetString("headwear"))
        {
            case "None":
            {
                flarpHeadwearLocal = 0;
                break;
            }
            case "Stetson":
            {
                flarpHeadwearLocal = 1;
                break;
            }
            case "Hippie Hat":
            {
                flarpHeadwearLocal = 2;
                break;
            }
            case "Crown":
            {
                flarpHeadwearLocal = 3;
                break;
            }
        }

        flarpHeadwear.sprite = hatSprites[flarpHeadwearLocal];   

    }
}
