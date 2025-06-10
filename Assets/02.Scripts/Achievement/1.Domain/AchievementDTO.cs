using UnityEngine;

public class AchievementDTO
{
    
    public readonly string ID;
    public readonly string Name;
    public readonly string Description;
    public readonly EachievementCondition Condition;
    public readonly EcurrencyType RewardCurrencyType;
    public readonly int GoalValue;
    public readonly int RewardAmount;
    public readonly int CurrentValue;
    public readonly bool RewardClaimed;
    
    public AchievementDTO(Achievement achievement)
    {
        ID = achievement.ID;
        Name = achievement.Name;
        Description = achievement.Description;
        Condition = achievement.Condition;
        GoalValue = achievement.GoalValue;
        RewardCurrencyType = achievement.RewardCurrencyType;
        RewardAmount = achievement.RewardAmount;
        CurrentValue = achievement.CurrentValue;
        RewardClaimed = achievement.RewardClaimed;
    }
    public bool canClaimReward()
    {
        return RewardClaimed == false && CurrentValue >= GoalValue;
    }

}
