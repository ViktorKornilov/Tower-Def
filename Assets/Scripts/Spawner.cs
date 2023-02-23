using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float interval = 1;
    public int enemyCount = 10;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Spawn();
            yield return new WaitForSeconds(interval);
        }
    }

    void Spawn()
    {
        if (prefab == null) return;
        
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position,1f);
    }
}
