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
        if(SceneManager.GetActiveScene().name != "MainMenu")
        {
            if(PlayerPrefs.GetString("Mode") == "Hard")
            {
                moveSpeed = 2.5f;
            }
            if(PlayerPrefs.GetString("Mode") == "Speed")
            {
                moveSpeed = 7.7f;
            }
            else 
            {
                moveSpeed = 4f;
            }
        }
        else
        {
            moveSpeed = 4f;
        }
            
    }
}
