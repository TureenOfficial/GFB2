using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite[] cloudSprites;
    public void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond * System.DateTime.Now.Second);
        sr.sprite = cloudSprites[Random.Range(0, 4)];
    }
    public void Update()
    {
        transform.position = transform.position  + Vector3.left * 2.2f * Time.deltaTime;

        if(transform.position.x < -11)
        {
            Destroy(this.gameObject);
        }
    }
}
