using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UI_AttendanceRewardSlot : MonoBehaviour
{
    private string _attendanceID;
    private int _attendanceReward;
    [SerializeField]private List<Sprite> _attendanceIcon;
    private AttendanceRewardDTO _dto;

    public TextMeshProUGUI RewardAmountTextUI;
    public Image RewardTypeIcon;
    public Button RewardClaimButton;
    
    
    public void Refresh(string id, int index, AttendanceRewardDTO dto)
    {
        _attendanceID = id;
        _attendanceReward = index;
        _dto = dto;
        RewardAmountTextUI.text = $"{dto.Amount:N0}개";
        RewardClaimButton.enabled = dto.canClaimed;
        RewardTypeIcon.sprite = _attendanceIcon[(int)dto.CurrencyType];
    }

    public void TryRewardClaim()
    {
        //어떤 id 출석의 몇 번째 보상을 달라.
        AttendanceManger.Instance.TryRewardClaim(_attendanceID, _attendanceReward);
    }
}
