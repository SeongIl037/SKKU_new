using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_AchievementSlot : MonoBehaviour
{
    public TextMeshProUGUI NameTextUI;
    public TextMeshProUGUI DescriptionTextUI;
    public TextMeshProUGUI RewardCountTextUI;
    public TextMeshProUGUI RewardCountextUI;
    public TextMeshProUGUI RewardClaimDateTextUI;
    
    public Slider ProgressSlider;
    public Button RewardClaimButton;

    private AchievementDTO _achievementDTO;
    public void Refresh(AchievementDTO achievement)
    {
        _achievementDTO = achievement;
        
        NameTextUI.text = _achievementDTO.Name;
        DescriptionTextUI.text = _achievementDTO.Description;
        RewardCountTextUI.text = _achievementDTO.GoalValue.ToString();
        RewardCountextUI.text = _achievementDTO.CurrentValue.ToString();
        ProgressSlider.value = (float)_achievementDTO.CurrentValue / _achievementDTO.GoalValue;
        
        RewardClaimButton.interactable = achievement.canClaimReward();
    }

    public void ClaimReward()
    {
        if (AchieveManager.Instance.TryClaimReward(_achievementDTO))
        {
            //ㅊㅊ
        }
        else
        {
            // 부족
        }

        ;
    }
}
