using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlarpCurrent : MonoBehaviour
{
    //this is the thing in the options menu that shows the current thing
    public GameObject bg;
    public RawImage bgimage;
    public GameObject crown;
    public bool bgenabled;
    public Color _Color;
    public int birbType;
    public Texture[] texture;
    public GameObject lashes; //I forgot to do It Yes
    public RawImage birbimage;
    public void Update()
    {
        birbType = PlayerPrefs.GetInt("FlarpC");
        birbimage.texture = texture[birbType];
        bg.SetActive(bgenabled);

        if(birbType == 5)
        {
            bgenabled = true;
            bgimage.color = _Color;
            
            _Color = Color.HSVToRGB(PlayerPrefs.GetFloat("colorvalue"), PlayerPrefs.GetFloat("satvalue"), PlayerPrefs.GetFloat("brightvalue"));
        }
        else
        {
            bgenabled = false;
        }

        if(PlayerPrefs.GetInt("lashes") == 1 && birbType == 5)
        {
            lashes.SetActive(true);
        }
        else
        {
            lashes.SetActive(false);
        }

        if(PlayerPrefs.GetInt("crownactive") == 1)
        {
            crown.SetActive(true);
        }
        else
        {
            crown.SetActive(false);
        }

    }
}
