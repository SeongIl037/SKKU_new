using System;
using TMPro;
using System.Collections;
using UnityEngine;

public class UI_AchievementNotify : MonoBehaviour
{
    
    public GameObject UI_Notify;
    public TextMeshProUGUI NotificationNametext;
    public TextMeshProUGUI NotificationDescriptiontext;
    
    private AchievementDTO _achievementDTO;

    private void Start()
    {
        AchieveManager.Instance.OnAchievementRewarded += NotifyAchievementsClear;
    }

    public void NotifyAchievementsClear(AchievementDTO achievement)
    {
        _achievementDTO = achievement;
        
        NotificationNametext.text = _achievementDTO.Name;
        NotificationDescriptiontext.text = _achievementDTO.Description;
        
        StartCoroutine(NotifyAchievement_Coroutine());
    }

    private IEnumerator NotifyAchievement_Coroutine()
    {
        UI_Notify.SetActive(true);

        yield return new WaitForSeconds(2f);
        
        UI_Notify.SetActive(false);
    }
}
