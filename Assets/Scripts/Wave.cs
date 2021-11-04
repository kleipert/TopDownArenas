using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private readonly int _spawnIntervall;
    private readonly GameObject[] _enemys;
    
    public Wave(int spawnIntervall, MovingUnits[] enemys)
    {
        this._spawnIntervall = spawnIntervall;
        this._enemys = (GameObject[]) enemys.Clone();
        
    }
    public static Wave CreateWave(int spawnIntervall, MovingUnits[] enemys)
    {
        return new Wave(spawnIntervall, enemys);
    }

    public int GetSpawnIntervall()
    {
        return this._spawnIntervall;
    }

    public GameObject[] GetEnemys()
    {
        return this._enemys;
    }
}

