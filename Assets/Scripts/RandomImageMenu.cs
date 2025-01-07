using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class RandomImageMenu : MonoBehaviour
{
    public Texture[] imagetex;
    public RawImage actual_image;

    void Start()
    {
        int index = Random.Range(0, imagetex.Length);
        actual_image.texture = imagetex[index];
    }
}
