using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

// DONE: ENEMY SPAWN TIMER
// DONE: CHECK IF ENEMIES ARE DEAD
// DONE: DEFINE LIST OF WAVES
// DONE: FROM THE LIST CHOOSE NEXT WAVE

[Serializable]
public class Wave
{
    public bool random;
    public float spawnInterval = 1f;
    public List<SpawnEntry> entries;
}

[Serializable]
public class SpawnEntry
{
    public int number;
    public GameObject enemy;
}


public class Spawner : MonoBehaviour
{
    public static List<Enemy> enemies = new();
    public GameObject prefab;
    public TMP_Text text;
    public float interval = 1;
    public int enemyCount = 10;

    public List<Wave> waves;
    public int currentWave;

    private void Start()
    {
        StartCoroutine(WaveRoutine());
    }
    


    IEnumerator WaveRoutine()
    {
        yield return new WaitForSeconds(3f);
        
        while (currentWave < waves.Count)
        {
            // start wave
            yield return StartCoroutine(SpawnRoutine());
            currentWave++;

            // are all enemies dead
            while (enemies.Count > 0)
            {
                yield return null; // pause for one frame
            }

            yield return new WaitForSeconds(2f);
        }
    }
    

    IEnumerator SpawnRoutine()
    {
        // Expand all entries into concrete prefabs list
        var enemiesToSpawn = new List<GameObject>();
        foreach (var entry in waves[currentWave].entries)
        {
            for(int i =0;i < entry.number;i++)enemiesToSpawn.Add(entry.enemy);
        }
        print(enemiesToSpawn.Count);
        
        
        // spawn until spawn list in not empty
        while(enemiesToSpawn.Count > 0)
        {
            var prefab = enemiesToSpawn[0];
            if (waves[currentWave].random) prefab = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Count)];
            enemiesToSpawn.Remove(prefab);
            
            Instantiate(prefab, transform.position, Quaternion.identity);
            
            yield return new WaitForSeconds(interval);
        }
    }
}
