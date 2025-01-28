using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefaultLeftMovingObject : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float killzone = -13;

    public void Update()
    {
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;

        if(transform.position.x < killzone)
        {
            Destroy(this.gameObject);
        }
    }
   
}
