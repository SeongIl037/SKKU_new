using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementRepository
{
    private const string SAVE_KEY = nameof(AchievementRepository);
    
    public void Save(List<AchievementDTO> achievements, string id)
    {
     AchievementSaveDataList datas = new AchievementSaveDataList();
     
     datas.DataList = achievements.ConvertAll(achievement => new AchievementSaveData
     {
         ID = achievement.ID,
         CurrentValue = achievement.CurrentValue,
         RewardClaimed = achievement.RewardClaimed,
     });
     
     string json = JsonUtility.ToJson(datas);
     PlayerPrefs.SetString(SAVE_KEY + "_" + id, json);
    }

    public List<AchievementSaveData> Load(string id)
    {
        if (!PlayerPrefs.HasKey(SAVE_KEY + "_" + id))
        {
            return null;
        }
        string json = PlayerPrefs.GetString(SAVE_KEY + "_" + id);
        AchievementSaveDataList datas = JsonUtility.FromJson<AchievementSaveDataList>(json);

        return datas.DataList;
    }
}

[Serializable]
public struct AchievementSaveDataList
{
    public List<AchievementSaveData> DataList;
}