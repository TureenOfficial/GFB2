using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
using TMPro;

public class RandomImageMenu : MonoBehaviour
{
    public Texture[] imagetex;
    public TMP_Text creditText;
    private string creditTextString;
    public RawImage actual_image;
    void Start()
    {
        int index = Random.Range(0, imagetex.Length);
        actual_image.texture = imagetex[index];

        switch(index)
        {   
            case 0:
            case 1:
            case 3:
            {
                creditTextString = "Tureen";
                break;
            }
            case 2:
            {
                creditTextString = "grza3";
                break;
            }
            case 4:
            {
                creditTextString = "Mackas & Tureen";
                break;
            }
            default:
            {
                creditTextString = "Unlisted";
                break;
            }
        }
        creditText.text = "Artist: " + creditTextString;
    }
}
