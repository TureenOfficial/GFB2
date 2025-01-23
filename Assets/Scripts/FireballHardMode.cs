using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballHardMode : MonoBehaviour
{
    public GameObject fireballPrefab;
    private float fbSpeed;
    public float _Timer;
    public bool fireballsActive;
    public void FlarpEntireStart()
    {
        if(PlayerPrefs.GetString("Mode") == "Hard")
        {
            this.gameObject.SetActive(true);
            fireballsActive = true;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void SpawnFireball()
    {
        float lowestPart = -4.5f;
        float highestPart = 4.5f;
        Instantiate(fireballPrefab, new Vector3(transform.position.x, Random.Range(lowestPart, highestPart), 0), transform.rotation);
    }
    void Update()
    {
        int timeToSpawn = 2; 
        if(fireballsActive)
        {
            if(_Timer < timeToSpawn)
            {
                _Timer += Time.deltaTime;
            }
            else
            {
                _Timer = 0;
                SpawnFireball();
            }
        }
    }
}
