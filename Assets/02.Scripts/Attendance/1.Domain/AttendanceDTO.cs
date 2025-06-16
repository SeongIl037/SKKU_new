using System;
using System.Collections.Generic;
using UnityEngine;

public class AttendanceDTO : MonoBehaviour
{
    public readonly string ID;
    public readonly DateTime StartDate;
    public readonly int DayCount;
    public readonly DateTime LastAttendanceDate;
    public readonly List<AttendanceRewardDTO> Rewards;

    public AttendanceDTO(string id,DateTime startDate, DateTime lastAttendanceDate,int dayCount, List<AttendanceReward> rewards)
    {
        ID = id;
        StartDate = startDate;
        DayCount = dayCount;
        LastAttendanceDate = lastAttendanceDate;
        Rewards = new List<AttendanceRewardDTO>(rewards.Count);

        for (int i = 0; i < rewards.Count; i++)
        {
            
            bool canClim = !rewards[i].Claimed && i >= dayCount;
            Rewards.Add(new AttendanceRewardDTO(rewards[i].CurrencyType, rewards[i].Amount, rewards[i].Claimed,canClim));
            
        }
    }
} 