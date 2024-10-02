using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBG : MonoBehaviour
{
    [SerializeField] public RawImage Image;
    [SerializeField] private float xs, ys;
    // Update is called once per frame
    void Update()
    {
        Image.uvRect = new Rect(Image.uvRect.position + new UnityEngine.Vector2(xs, ys) * Time.deltaTime, Image.uvRect.size);
    }
}
