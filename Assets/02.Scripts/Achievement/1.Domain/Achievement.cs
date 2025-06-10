using System;
using Unity.VisualScripting;
using UnityEngine;

public enum EachievementCondition
{
    GoldCollect,
    DronKillCount,
    BossKillCount,
    PlayTime,
    Trigger,

    GoldAmount
}
public class Achievement
{
    public readonly string ID;
    public readonly string Name;
    public readonly string Description;
    public readonly EachievementCondition Condition;
    public int GoalValue;
    public EcurrencyType RewardCurrencyType;
    public int RewardAmount;

    private int _currentValue;
    public int CurrentValue => _currentValue;

    private bool _rewardClaimed;
    public bool RewardClaimed => _rewardClaimed;
    
    

    public Achievement(AchievementSO metaData, AchievementSaveData saveData)
    {
        if (string.IsNullOrEmpty(metaData.ID))
        {
            throw new Exception("업적 ID는 비어있을 수 없습니다.");
        }
        ID = metaData.ID;
        
        if (string.IsNullOrEmpty(metaData.Name))
        {
            throw new Exception("업적 이름은 비어있을 수 없습니다.");
        }
        
        Name = metaData.Name;
        
        if (string.IsNullOrEmpty(metaData.Description))
        {
            throw new Exception("업적 설명은 비어있을 수 없습니다.");
        }
        Description = metaData.Description;
        Condition = metaData.Condition;

        if (metaData.GoalValue <= 0)
        {
            throw new Exception("업적 목표 값은 0보다 커야합니다");
        }
        GoalValue = metaData.GoalValue;
       
        if (metaData.RewardAmount <= 0)
        {
            throw new Exception("업적 보상값은 0보다 커야합니다.");
        }

        if (saveData.CurrentValue < 0)
        {
            throw new Exception("업적 진행 값은 0보다 커야합니다.");
        }
        RewardCurrencyType = metaData.RewardCurrencyType;
        RewardAmount = metaData.RewardAmount;
        
        _currentValue = saveData.CurrentValue;
        _rewardClaimed = saveData.RewardClaimed;
        
    }

    public void Increase(int value)
    {
        if (value <= 0)
        {
            throw new Exception("증가 값은 0보다 커야합니다.");
        }
        _currentValue += value;
    }

    public bool canClaimReward()
    {
        return _rewardClaimed == false && _currentValue >= GoalValue;
    }

    public bool TryClaimReward()
    {
        if (!canClaimReward())
        {
            return false;
        }
        
        _rewardClaimed = true;
        
        return true;
    }
}
