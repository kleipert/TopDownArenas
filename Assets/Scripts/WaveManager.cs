using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Enemy Prefabs
    public GameObject[] enemy_prefabs = new GameObject[1];
    public static int enemyCount = 0;
    private static int overallEnemyWaveCount = 0;
    
    
    
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

        StartCoroutine(CreateWaveOne());
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(!wavesStarted)
            StartWaves();
        */
    }

    private void SpawnEnemy(GameObject enemy, Transform pos)
    {
        
            Instantiate(enemy, pos);
            Debug.Log("Spawned Enemy!");
            enemyCount++;
        
    }

    private IEnumerator CreateWaveOne()
    {
        UIManager.ResetCurrentKills();
        overallEnemyWaveCount = 3;
        while (enemyCount < 3)
        {
            int spawn = Random.Range(0,3);
            SpawnEnemy(enemy_prefabs[(int)Enemy.Demon_Small], spawnPoints[spawn]);

            yield return new WaitForSeconds(3);
        }
    }

    public static int GetCurrentWaveMaxCount()
    {
        return overallEnemyWaveCount;
    }

    public static int GetCurrentWaveCount()
    {
        return enemyCount;
    }
}
