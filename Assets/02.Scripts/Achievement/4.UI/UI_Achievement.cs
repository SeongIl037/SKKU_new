using UnityEngine;
using System.Collections.Generic;
public class UI_Achievement : MonoBehaviour
{
    [SerializeField]
    private List<UI_AchievementSlot> _slots;
    
    private void Start()
    {
        Refresh();
        
        AchieveManager.Instance.OnAchievementsUpdated += Refresh;
    }

    private void Refresh()
    {
        List<AchievementDTO> achievements = AchieveManager.Instance.Achievements;

        for (int i = 0; i < _slots.Count; i++)
        {
            _slots[i].Refresh(achievements[i]);
        }
        
    }
    
}
