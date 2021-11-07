using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private readonly int _spawnIntervall;
    private readonly MovingUnits[] _enemys;
    
    public Wave(int spawnIntervall, MovingUnits[] enemys)
    {
        this._spawnIntervall = spawnIntervall;
        this._enemys = (MovingUnits[]) enemys.Clone();
        
    }
    public static Wave CreateWave(int spawnIntervall, MovingUnits[] enemys)
    {
        return new Wave(spawnIntervall, enemys);
    }

    public int GetSpawnIntervall()
    {
        return this._spawnIntervall;
    }

    public MovingUnits[] GetEnemys()
    {
        return this._enemys;
    }
}

