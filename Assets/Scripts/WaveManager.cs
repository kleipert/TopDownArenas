using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Enemy Prefabs
    public GameObject[] enemy_prefabs = new GameObject[1];
    public int enemyCount = 0;
    public GameObject testEnemy;
    
    
    
    private List<Transform> spawnPoints;
    private bool wavesStarted = false;
    

    // Enemy Enum
    private enum Enemy
    { 
        Demon_Small = 0
    }


    // Start is called before the first frame update
    void Start()
    {
        this.spawnPoints = new List<Transform>();

        // Get all the spawnPoints
        foreach (Transform transform in GetComponentInChildren<Transform>())
            this.spawnPoints.Add(transform);

        Debug.Log($"Got {this.spawnPoints.Count} spawns");
        Debug.Log($"Got {this.enemy_prefabs.Length} enemy types");

        
    }

    // Update is called once per frame
    void Update()
    {
        if(!wavesStarted)
            StartWaves();
    }

    private void SpawnEnemy(GameObject enemy, Transform pos)
    {

        //Debug.Log("Entered Spawn Method");
        //Instantiate(enemy, new Vector3(pos.position.x, pos.position.y, 10), Quaternion.identity);
        GameObject enemySpawned = Instantiate(testEnemy, new Vector3(pos.position.x, pos.position.y, 10), Quaternion.identity);
        Debug.Log("Spawned Enemy!");
    }

    private void CreateWaveOne()
    {
        this.enemyCount = 3;
        double spawnCooldown = 1000.0f;

        Debug.Log("Starting Wave One");

        Timer timerWaveOne = new Timer();
        timerWaveOne.Interval = spawnCooldown;
        timerWaveOne.Elapsed += TimerWaveOne_Elapsed;
        timerWaveOne.AutoReset = true;
        timerWaveOne.Start();

        Debug.Log("Timer Wave One started");
                
        
    }

    private void TimerWaveOne_Elapsed(object sender, ElapsedEventArgs e)
    {
        //Debug.Log("Timer Wave One elapsed");
        /*
        if(this.enemyCount == 0)
        {
            Debug.Log("Wave One Done, stopping Timer");
            Timer timer = (Timer)sender;
            timer.AutoReset = false;
        }
        */
        SpawnEnemy(enemy_prefabs[(int)Enemy.Demon_Small], spawnPoints[0]);
        //this.enemyCount--;
            
    }

    private void StartWaves()
    {
        this.wavesStarted = true;
        Debug.Log("Starting Waves");
        CreateWaveOne();
    }


}
