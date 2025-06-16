using System;
using System.Collections.Generic;
using UnityEngine;

public class UI_Attendance : MonoBehaviour
{
    public List<UI_AttendanceRewardSlot> Slots;

    private void Start()
    {
        Refresh();
        AttendanceManger.Instance.OnDateChanged += Refresh;
    }

    private void Refresh()
    {
        AttendanceDTO attendance = AttendanceManger.Instance.GetAttendance("3day");

        int index = 0;
        foreach (var VARIABLE in Slots)
        {
            VARIABLE.Refresh(attendance.ID, index,attendance.Rewards[0]);
            index++;
        }
    }
}
