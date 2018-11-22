using System;
using System.Collections.Generic;
using UnityEngine;
//1 can be seen and edited in the editor when used by a MonoBehaviour.
[Serializable]
public class EnemyWave
{
    //2 The index of the path this wave should take
    public int pathIndex;
    //3 Time in seconds before this wave starts
    public float startSpawnTimeInSeconds;
    //4 Delay in seconds between each spawn
    public float timeBetweenSpawnsInSeconds = 1f;
    //5 The list of enemies in this wave
    public List<GameObject> listOfEnemies = new List<GameObject>();
}
