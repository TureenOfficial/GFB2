using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float _Timer;
    public bool cloudsActive;
    public void Start()
    {
        if(PlayerPrefs.GetInt("cloudsActive") == 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Spawn()
    {
        float lowestPart = -4.5f;
        float highestPart = 4.5f;
        Instantiate(cloudPrefab, new Vector3(transform.position.x, Random.Range(lowestPart, highestPart), 0), transform.rotation);
    }
    public void Update()
    {
        {
            float timeToSpawn = Random.Range(1.2f, 2.5f); 
            if(PlayerPrefs.GetInt("cloudsActive") == 1)
            {
                if(_Timer < timeToSpawn)
                {
                    _Timer += Time.deltaTime;
                }
                else
                {
                    _Timer = 0;
                    Spawn();
                }
            }
        }
    }
}
