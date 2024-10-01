using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject poptart;
    public float moveSpeed;

    public void Update()
    {
        moveSpeed = PipeMove.Instance.moveSpeed;
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if(transform.position.x < PipeMove.Instance.killpipes)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(CompareTag("Player"))
        {
            LOGIC.Instance.AddCollectable();
        }
    }
    

}
