using System.Collections.Generic;
using Unity.FPS.AI;
using Unity.FPS.Game;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public EnemyManager EManager;
    public GameObject Enemy;
    public List<Transform> SpawnPoints;
    
    private float _currentTime = 0;
    private const float RESPAWN_TIME = 0.5f;
    private const int MAX_COUNT = 10;
    
    private StageLevel _stageLevel;

    private void Start()
    {
        Refresh();
    }

    private void Refresh()
    {
        _stageLevel = StageManager.Instance.Stage.CurrentLevel;
    }

    private void Update()
    {
        if (_stageLevel == null)
        {
            return;
        }
        
        _currentTime += Time.deltaTime;
        if (_currentTime >= _stageLevel.SpawnInterval)
        {
            _currentTime = 0;
            foreach (var spawnPoint in SpawnPoints)
            {
                if (Random.Range(0, 100) < _stageLevel.SpawnRate)
                {
                    GameObject enemyGamobject = Instantiate(Enemy, spawnPoint.position, Quaternion.identity);
                    
                    // 체력과 공격력 세팅
                    var health = enemyGamobject.GetComponent<Health>();
                    
                }
            }
        }
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
