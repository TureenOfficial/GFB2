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


    public void Start()
    {  
        fs = GameObject.FindGameObjectWithTag("Player").GetComponent<FlarpScript>();  
    }
}
