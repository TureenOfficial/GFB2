using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class rewardScript : MonoBehaviour
{
    public Collider2D fs;
    public LOGIC gamelogic;
    public FlarpScript fls;
    void Start()
    {
        fs = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        gamelogic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LOGIC>();
        fls = GameObject.FindGameObjectWithTag("Player").GetComponent<FlarpScript>();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            gamelogic.AddToTotal();
            
        }
    }
}
