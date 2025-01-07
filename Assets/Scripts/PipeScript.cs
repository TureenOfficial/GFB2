using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UIElements;

public class PipeScript : MonoBehaviour
{
    public GameObject pipe;
    public LOGIC gamelogic;
    public FlarpScript fs;
    public SpriteRenderer spriterend;
    public SpriteRenderer spriterend2;
    public Sprite[] pipesprites;
    public string gamemodetype;


    public void Start()
    {
        fs = GameObject.FindGameObjectWithTag("Player").GetComponent<FlarpScript>();
        gamemodetype = PlayerPrefs.GetString("Mode");
        
        switch(gamemodetype)
        {
            case "Hard":
            {
                spriterend.sprite = pipesprites[1];
                spriterend2.sprite = pipesprites[1];
                break;
            }

            default:
            {
                spriterend.sprite = pipesprites[0];
                spriterend2.sprite = pipesprites[0];
                break;
            }
        }
    }
}
