using System;
using System.Collections.Generic;
using UnityEngine;

public class UI_Attendance : MonoBehaviour
{
    public string ID;
    public List<UI_AttendanceRewardSlot> Slots;
    public GameObject SlotPrefab;
    public Transform SlotsParent;

    private void Start()
    {
        Refresh();
        
        MakeSlots();
        AttendanceManger.Instance.OnDateChanged += Refresh;
    }

    private void MakeSlots()
    {
        int RewardCount = AttendanceManger.Instance.CountAttendances(ID);
        
        for (int i = 0; i < RewardCount; i++)
        {
            GameObject slot = Instantiate(SlotPrefab, SlotsParent.parent);
            Slots.Add(slot.GetComponent<UI_AttendanceRewardSlot>());
        }
    }

    private void Refresh()
    {
        AttendanceDTO attendance = AttendanceManger.Instance.GetAttendance(ID);
        
        int index = 0;
        
        foreach (var slot in Slots)
        {
            slot.Refresh(attendance.ID, index,attendance.Rewards[0]);
            index++;
        }
    }
}
