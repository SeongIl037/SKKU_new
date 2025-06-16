using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using DateTime = System.DateTime;

public class AttendanceManger : MonoBehaviour
{
    public static AttendanceManger Instance;

    [SerializeField] private List<AttendaceSO> _attendaceSOList;
    
    private List<Attendance> _attendances;
    public Action OnDateChanged;
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

    private void Init()
    {
        _attendances = new List<Attendance>(_attendaceSOList.Count);
        DateTime today = DateTime.Today;
        
        foreach (AttendaceSO attendaceSO in _attendaceSOList)
        {
            if (attendaceSO.StartDate < today)
            {
                continue;
            }
            Attendance attendance = new Attendance(attendaceSO.ID,attendaceSO.StartDate, today,1);
            foreach (var attendanceRewardSO in attendaceSO.AttendanceRewards)
            {
                attendance.AddReward(new AttendanceReward(attendanceRewardSO.CurrnecyType, attendanceRewardSO.Amount,false));   
            }
        }
        StartCoroutine(Check_Coroutine());
    }

    private Attendance FindById(string id)
    {
        Attendance attendance = _attendances.Find(x => x.ID == id);
        return attendance;
    }
    public AttendanceDTO GetAttendance(string id)
    {
        Attendance attendance = FindById(id);

        if (attendance == null)
        {
            throw new Exception("Attendance not found");
        }
        
        return attendance.ToDTO();
    }

    public bool TryRewardClaim(string id, int index)
    {
        Attendance attendance = FindById(id);
        if (FindById(id).TryClaim(index))
        {
            return false;
        };
        if (attendance.TryClaim(index))
        {
            AttendanceRewardDTO reward = attendance.GetReward(index);
            return true;
            
            CurrencyManager.Instance.Add(reward.CurrencyType, reward.Amount);
            OnDateChanged?.Invoke();
        }

        return false;
    }
    private IEnumerator Check_Coroutine()
    {
        //yield return을 미리 변수로 만들어서 사용하는 이유 => 매번 객체를 생성하지 않게 하기 위함
        var hourtime = new WaitForSecondsRealtime(60 * 60);
        
        while (true)
        {
            DateTime today = DateTime.Today;

            foreach (Attendance attendance in _attendances)
            {
                attendance.Check(today);
            }

            OnDateChanged?.Invoke();

            yield return hourtime;
        }
    }
}
