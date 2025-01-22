using UnityEngine;
using UnityEngine.UIElements;

public class PipeSpawn : MonoBehaviour
{
    public GameObject pipe;
    public GameObject pipeHard;
    public float spawnTime;
    public bool isPipesActive;
    private float _Timer;
    public float heightOfst;
    public GameObject pipeType;

    void Start()
    {
        _Timer = 1;
        isPipesActive = false;
    }   
    public void FlarpEntireStart()
    {
        SpawnPipe();
        isPipesActive = true;
    }

    void Update()
    {
        if(isPipesActive)
        {
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
    }
    void SpawnPipe()
    {
        float timerMin = 3f;
        float timerMax = 8f;

        //suggested merge by brandon ty
        //refactored 2/10/24 after school

        switch(PlayerPrefs.GetString("Mode"))
        {
            case "Hard":
            {
                    timerMin = 3f;
                    timerMax = 6f;
                    heightOfst = 2f;
                    pipeType = pipeHard;
                break;
            }
            case "Speed":
            {
                    timerMin = 2f;
                    timerMax = 5f;
                    heightOfst = 1.6f;
                    pipeType = pipe;
                break;
            }
            case "Default":
            {
                    timerMin = 4f;
                    timerMax = 7f;
                    heightOfst = 1.6f;
                    pipeType = pipe;
                break;
            }
        }
                
        float lowestPart = transform.position.y - heightOfst;
        float highestPart = transform.position.y + heightOfst;
        Instantiate(pipeType, new Vector3(transform.position.x, Random.Range(lowestPart, highestPart), 0), transform.rotation);
        spawnTime = Random.Range(timerMin, timerMax);
        //then make it
        
    }
        
}
