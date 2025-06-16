using System;
using System.Collections.Generic;
using UnityEngine;

public class Attendance
{
    // new를 통해 메모리에 할당하려면 MonoBehaviour를 사용하면 안된다.
    // MonoBehaviour는 게임오브젝트이므로 => Instantiate를 사용해야한다.
    public readonly string ID;
    public readonly DateTime StartTime; // 출석 이벤트를 언제 시작할 것인가?
    public DateTime LastCheckDate { get; private set; } // 마지막 출석일
    public int DayCount { get; private set; } // 출석수
    
    private List<AttendanceReward> _rewards;
    public List<AttendanceReward> Rewards => _rewards;
    public Attendance(string id,DateTime startTime, DateTime lastCheckDate, int dayCount)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentNullException("ID는 비어있을 수 없습니다.");
        }
        if (startTime == new DateTime())
        {
            throw new Exception("출석 시작일이 지정되지 않았습니다.");
        }

        if (lastCheckDate == new DateTime())
        {
            throw new Exception("마지막 출석일이 지정되지 않았습니다.");
        }
        
        if (startTime > lastCheckDate)
        {
            throw new Exception("시작일자는 마지막 출석일을 넘을 수 없습니다.");
        }

        if (dayCount <= 0)
        {
            throw new Exception("출석일은 음수가 될 수 없습니다.");
        }
        StartTime = startTime;
        LastCheckDate = lastCheckDate;
        DayCount = dayCount;
        ID = id;
        
        
        _rewards = new List<AttendanceReward>();
    }

    public void Check(DateTime date)
    {
        if (date == new DateTime())
        {
            throw new Exception("출석체크하는 데이트가 지정되지 않았습니다.");
        }
        // ToDo : year과 month도 비교해야한다.
        if (LastCheckDate.Day < date.Day && LastCheckDate.Year == date.Year && LastCheckDate.Month == date.Month)
        {
            DayCount += 1;
            LastCheckDate = date;
        }
        
    }
    // 상위 도메인 만이 하위 도메인을 수정할 수 있다.
    public void AddReward(AttendanceReward reward)
    {
        if (reward == null)
        {
            throw new Exception("출석 보상은 null일 수 없습니다.");
        }
        _rewards.Add(reward);
    }
    
    public bool TryClaim(int day)
    {
        if (day < 1 || day >= _rewards.Count)
        {
            throw new Exception("출석 인덱스가 올바르지 않습니다.");
        }

        if (DayCount < day)
        {
            return false;
        }
        
        return _rewards[day -1].TryClaim();
    }

    public AttendanceDTO ToDTO()
    {
        return new AttendanceDTO(ID,StartTime, LastCheckDate, DayCount, _rewards);
    }

    
    public AttendanceRewardDTO GetReward(int day)
    {
        return new AttendanceRewardDTO(_rewards[day].CurrencyType, _rewards[day].Amount, _rewards[day].Claimed, true);
    }
}
