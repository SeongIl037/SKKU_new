using System;
using System.Collections.Generic;
using UnityEngine;

public class AchieveManager : MonoBehaviour
{
    public static AchieveManager Instance;

    public List<AchievementDTO> Achievements => _achievements.ConvertAll((achievement) => new AchievementDTO(achievement));
    
    [SerializeField] private List<AchievementSO> _metaDatas;
    private List<Achievement> _achievements;
    
    private AchievementRepository _achievementRepository;

    public event Action OnAchievementsUpdated;
    public event Action<AchievementDTO> OnAchievementRewarded;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Init();
        
    }

    private Achievement FindByID(string id)
    {
        return _achievements.Find((achievement) => achievement.ID == id);
    }
    private void Init()
    {
        
        _achievements = new List<Achievement>();
        
        _achievementRepository = new AchievementRepository();
        List<AchievementSaveData> saveDatas = _achievementRepository.Load();
        
        foreach (var metaData in _metaDatas)
        {
            Achievement duplicate = FindByID(metaData.ID);
            
            if (duplicate != null)
            {
                throw new Exception($"업적 아이디 : {metaData.ID}가 중복됩니다.");
            }
            AchievementSaveData saveData = saveDatas?.Find(a => a.ID == metaData.ID) ?? new AchievementSaveData();
            Achievement achievement = new Achievement(metaData, saveData);
            _achievements.Add(achievement);
        }

    }

    public void Increase(EachievementCondition condition, int value)
    {
        foreach (var achievement in _achievements)
        {
            if (achievement.Condition == condition)
            {
                bool prevCanClaimReward = achievement.canClaimReward();
                achievement.Increase(value);
                
                bool canClaimReward = achievement.canClaimReward();

                if (prevCanClaimReward == false && canClaimReward == true)
                {
                    // 리워드를 받을 수 있음
                    OnAchievementRewarded?.Invoke(new AchievementDTO(achievement));
                }
            }
        }
        
        OnAchievementsUpdated?.Invoke();
    }

    public bool TryClaimReward(AchievementDTO achievementDTO)
    {
        Achievement achievement = FindByID(achievementDTO.ID);
        
        if (achievement == null)
        {
            return false;
        }

        if (achievement.TryClaimReward())
        {
            CurrencyManager.Instance.Add(achievement.RewardCurrencyType, achievement.RewardAmount);
            _achievementRepository.Save(Achievements);
            OnAchievementsUpdated?.Invoke();
            return true;
        }
        
        return false;
    }
}
