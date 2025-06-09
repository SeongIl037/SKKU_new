using System;
using System.Collections.Generic;
using Unity.FPS.AI;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyManager EManager;
    public GameObject Enemy;
    public List<Transform> SpawnPoints;
    private void Update()
    {
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        if (EManager.NumberOfEnemiesRemaining < 10)
        {
            int randNum = UnityEngine.Random.Range(0, SpawnPoints.Count);
            
            GameObject enemy = Instantiate(Enemy);
            enemy.transform.position = SpawnPoints[randNum].position;
            
        }
        else
        {
            return;
        }
    }
}
