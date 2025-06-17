using System;
using UnityEngine;

public class StageLevel
{
    // 기획 데이터
    public readonly string Name;
    public readonly int StartLevel;
    public readonly int EndLevel;
    
    public float HealthFactor;
    public float DamageFactor;

    public readonly float SpawnInterval; // 스폰 주기
    public readonly float SpawnRate; // 스폰 확률
    // 상수화
    public float Duration => 60f;
    //상태 데이터

    public int CurrentLevel { get; private set; } // 스타트 레벨 ~ 엔드 레벨

    public StageLevel(StageLevelSO so, int currentLevel) : this(so.Name, so.StartLevel, so.EndLevel, so.HealthFactor, so.DamageFactor, so.SpawnInterval, so.SpawnRate,currentLevel)
    {
        
    }
    public StageLevel(string name,int startLevel, int endLevel, float healthFactor, float damageFactor,
        float spawnInterval, float spawnRate, int currentLevel)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new Exception("올바르지 않은 Name입니다.");
        }

        if (startLevel < 0 || startLevel > endLevel)
        {
            throw new Exception("시작 레벨이 올바르지 않습니다.");
        }

        if (endLevel < 0 || endLevel <= startLevel)
        {
            throw new Exception("종료 레벨이 올바르지 않습니다.");
        }
        if (healthFactor < 1)
        {
            throw new Exception("요소들이 잘못 입력되었습니다.");
        }

        if (healthFactor < 1)
        {
            throw new Exception("체력 요소가 잘못 입력되었습니다.");
        }

        if (spawnInterval <= 0)
        {
            throw new Exception("스폰 주기가 올바르지 않습니다.");
        }

        if (spawnRate <= 0 || 100 < spawnRate)
        {
            throw new Exception("스폰 확률이 올바르지 않습니다.");
        }

        if (currentLevel < startLevel || currentLevel > endLevel)
        {
            throw new Exception("현재 레벨이 올바르지 않습니다.");
        }
        
        Name = name;
        StartLevel = startLevel;
        EndLevel = endLevel;
        HealthFactor = healthFactor;
        DamageFactor = damageFactor;
        SpawnInterval = spawnInterval;
        SpawnRate = spawnRate;
        CurrentLevel = currentLevel;
        
    }

    public bool TryLevelUp(float progressTime)
    {
        if (progressTime >= Duration)
        {
            CurrentLevel += 1;
            return true;
        }

        return false;   
    }

    public bool IsClear()
    {
        return CurrentLevel == EndLevel;
        
    }
}
