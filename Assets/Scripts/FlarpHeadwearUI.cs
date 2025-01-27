using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlarpHeadwearUI : MonoBehaviour
{
    public UnityEngine.UI.RawImage flarpHeadwear;
    private int flarpHeadwearLocal;
    public GameObject headwear;
    public Texture[] hatSprites;
    void Start()
    {
        UpdateAppearance();
    }
    public void UpdateAppearance()
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

        flarpHeadwear.texture = hatSprites[flarpHeadwearLocal];   
        
    }
}
