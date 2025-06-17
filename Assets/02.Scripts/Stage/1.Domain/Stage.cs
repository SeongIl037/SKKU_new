using System;
using System.Collections.Generic;
using UnityEngine;

public class Stage
{
    public int LevelNumber { get; private set; }
    private StageLevel _currentLevel;
    public int SubLevelNumber => _currentLevel.CurrentLevel;
    public List<StageLevel> Levels { get; private set; } = new List<StageLevel>();
    private float _progressTime;
    public StageLevel CurrentLevel => _currentLevel;

    public Stage(int levelNumber, int subLevelNumber, float progressTime, List<StageLevelSO> levelSOList)
    {
        if (levelNumber < 0)
        {
            throw new Exception("올바르지 않은 레벨입니다.");
        }

        if (subLevelNumber < 0)
        {
            throw new Exception("올바르지 않은 서브레벨 넘버입니다.");
        }

        if (progressTime < 0)
        {
            throw new Exception("올바르지 않은 진행 시간 입니다.");
        }

        if (levelSOList == null)
        {
            throw new Exception("올바르지 않은 레벨 데이터입니다.");
        }
        
        LevelNumber = levelNumber;
        _progressTime = progressTime;

        foreach (StageLevelSO levelSO in levelSOList)
        {
            // 서브레벨을 start와 end사이로 고정한다.
            int sub = levelSO.StartLevel;

            if (sub < subLevelNumber)
            {
                sub = levelSO.EndLevel;

                if (subLevelNumber < sub)
                {
                    sub = subLevelNumber;
                }
            }
            AddLevel(new StageLevel(levelSO, subLevelNumber));
        }

        _currentLevel = Levels[levelNumber - 1];
    }
    
    private void AddLevel(StageLevel level)
    {
        if (level == null)
        {
            throw new Exception("레벨이 null입니다.");
        }
        
        Levels.Add(level);
    }

    public void Progress(float dt, Action onDataChanged = null)
    {
        _progressTime += dt;
        
        if (_currentLevel.TryLevelUp(_progressTime))
        {
            _progressTime = 0;
        
            if (_currentLevel.IsClear())
            {
                LevelNumber += 1;
                _currentLevel = Levels[LevelNumber - 1];
            }
            onDataChanged?.Invoke();
        };
    }
}
