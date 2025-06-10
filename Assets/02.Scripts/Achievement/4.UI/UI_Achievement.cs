using UnityEngine;
using System.Collections.Generic;
public class UI_Achievement : MonoBehaviour
{
    [SerializeField]
    private List<UI_AchievementSlot> _slots;
    [SerializeField]
    private GameObject _slotPrefab;
    public GameObject _scrollContent;
    
    
    private void Start()
    {
        MakeSlots();
        
        Refresh();
        
        AchieveManager.Instance.OnAchievementsUpdated += Refresh;
    }

    private void MakeSlots()
    {
        for (int i = 0; i < AchieveManager.Instance.Achievements.Count; i++)
        {
            GameObject pre = Instantiate(_slotPrefab, transform.position, Quaternion.identity);
            pre.transform.SetParent(_scrollContent.transform, false);
            _slots.Add(pre.GetComponent<UI_AchievementSlot>());
            
        }
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
