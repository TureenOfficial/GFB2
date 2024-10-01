using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PipeSpawn : MonoBehaviour
{
    public GameObject pipe;
    public GameObject pipeHard;
    public float spawnTime;
    private float _Timer;
    public float heightOfst;
    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        StartCoroutine(RandomizeTime());
        if(_Timer < spawnTime)
        {
            _Timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            _Timer = 0;
        }
        
    }
    void SpawnPipe()
    {
        float lowestPart = transform.position.y - heightOfst;
        float highestPart = transform.position.y + heightOfst;

        if(PlayerPrefs.GetString("Mode") == "Hard")
        {
            heightOfst = 2f;
            Instantiate(pipeHard, new Vector3(transform.position.x, Random.Range(lowestPart, highestPart), 0), transform.rotation);
        }
        if(PlayerPrefs.GetString("Mode") == "Speed")
        {
            heightOfst = 1.6f;
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPart, highestPart), 0), transform.rotation);
        }
        //you can add other difficulties inbetween here
        if(PlayerPrefs.GetString("Mode") == "Default")
        {
            heightOfst = 1.6f;
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPart, highestPart), 0), transform.rotation);
        }

        //then make it
        
    }
    public IEnumerator RandomizeTime()
    {
        if(PlayerPrefs.GetString("Mode") == "Default")
        {
            spawnTime = Random.Range(4, 8);
        }
        if(PlayerPrefs.GetString("Mode") == "Hard")
        {
            spawnTime = Random.Range(3, 6);
        }
        if(PlayerPrefs.GetString("Mode") == "Speed")
        {
            spawnTime = Random.Range(2, 5);
        }
        yield return new WaitForSeconds(spawnTime);
    }
        
}
