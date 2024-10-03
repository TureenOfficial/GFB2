using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeMove : MonoBehaviour
{
    public static PipeMove Instance { get; private set; }
    public float moveSpeed;
    public float killpipes = -45;

    public void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if(transform.position.x < killpipes)
        {
            Destroy(this.gameObject);
        }


    }
    public void Start()
    {
        //refactored 2/10/24 GOING TO SCHOOL
        //furthur refactor 3/10/24 unneeded variable
        if(SceneManager.GetActiveScene().name != "MainMenu")
        {
            switch(PlayerPrefs.GetString("Mode"))
            {
                case "Hard":
                    moveSpeed = 2.5f;
                     break;

                case "Speed":
                    moveSpeed = 7.7f;
                     break;

                case "Default":
                    moveSpeed = 4f;
                     break;
            }
        }
        else
        {
            moveSpeed = 4f;
        }
            
    }
}
