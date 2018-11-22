using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    //1 singleton pattern to make itself available everywhere using this variable.
    public static WaveManager Instance;

    //2 list of enemy waves that’ll be spawned by this class
    public List<EnemyWave> enemyWaves = new List<EnemyWave>();

    //3 keeps track of how much time has passed since the level started in seconds
    private float elapsedTime = 0f;

    //4 wave that’s currently spawning enemies
    private EnemyWave activeWave;

    //5 This keeps track of when the last spawn happened. It gets reset to 0 with every
    //spawn, and is incremented in every frame while a wave is spawning.
    private float spawnCounter = 0f;

    //6 A list of waves that were already started. Any waves in here won’t start again.
    private List<EnemyWave> activatedWaves = new List<EnemyWave>();

    //1 Sets the Instance variable to script itself.
    void Awake()
    {
        Instance = this;
    }
    //2 Add to elapsedTime. Check if a new wave has to be started and update the wave that’s active every frame.    
        void Update()
    {
        elapsedTime += Time.deltaTime;
        SearchForWave();
        UpdateActiveWave();
    }
    private void SearchForWave()
    {
        //3 Iterate over the enemyWaves list
        foreach (EnemyWave enemyWave in enemyWaves)
        {
            //4 Check that a wave wasn’t already started
            if (!activatedWaves.Contains(enemyWave)
            && enemyWave.startSpawnTimeInSeconds <= elapsedTime)
            {
                //5 If so, make the enemy wave the active one.
                activeWave = enemyWave;
                activatedWaves.Add(enemyWave);
                spawnCounter = 0f;
                //6 Break out of the list iteration as a suitable wave has been found
                break;
            }
        }
    }
    //7 An empty method up until now. This is filled in the next part.
    private void UpdateActiveWave()
    {
        //1 Only continue if there’s an active wave
        if (activeWave != null)
        {
            spawnCounter += Time.deltaTime;
            //2
            if (spawnCounter >= activeWave.timeBetweenSpawnsInSeconds)
            {
                spawnCounter = 0f;
                //3 Check if there’s still enemies in the current wave.
                if (activeWave.listOfEnemies.Count != 0)
                {
                    //4 Spawn the first entry in the enemy list at the position of the first waypoint of the wave’s path.
                    GameObject enemy = (GameObject)Instantiate(
                    activeWave.listOfEnemies[0], WayPointManager.Instance.
                    GetSpawnPosition(activeWave.pathIndex), Quaternion.identity);

                    //5 Set the new enemy’s pathIndex
                    enemy.GetComponent<Enemy>().pathIndex = activeWave.pathIndex;

                    //6 Remove the first entry in the list of enemies
                    activeWave.listOfEnemies.RemoveAt(0);
                }
                else
                {
                    ////7 If the check in //2 fails, there are no more enemies in the current wave. Empty the
                    //activeWave variable by giving it a null value.
                    activeWave = null;

                    //8 If the number of total waves equals the number if waves that were already activated
                    //that means all waves are over.
                    if (activatedWaves.Count == enemyWaves.Count)
                    {
                        // All waves are over
                    }
                }
            }
        }
    }
    public void StopSpawning()
    {
        elapsedTime = 0;
        spawnCounter = 0;
        activeWave = null;
        activatedWaves.Clear();
        enabled = false;
    }

}
