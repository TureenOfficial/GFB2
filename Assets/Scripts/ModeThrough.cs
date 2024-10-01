using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeThrough : MonoBehaviour
{   
    public PipeSpawn pss;
    public void Start()
    {
        pss.heightOfst = 2f;
    }
}
