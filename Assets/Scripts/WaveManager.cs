using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Enemy Prefabs
    public GameObject[] enemy_prefabs = new GameObject[1];
    private List<Transform> spawnPoints;
    private List<Wave> waves;

    // Enemy Enum
    private enum Enemy
    { 
        Demon_Small = 0
    }


    // Start is called before the first frame update
    void Start()
    {
        // Get all the spawnPoints
        foreach (Transform transform in GetComponentInChildren<Transform>())
            this.spawnPoints.Add(transform);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnEnemy(GameObject enemy, Transform pos)
    {
        Instantiate(enemy, pos);
    }

    private void CreateWaveOne()
    {
        
    }


}
