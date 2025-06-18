using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class UI_Ranking : MonoBehaviour
{
    public List<UI_RankingSlot> RankingSlots;
    public UI_RankingSlot MyRankingSlot;
    
    
    public void Refresh()
    {
        var rankings = RankingManager.Instance.Rankings;
        
        int index = 0;
        foreach (UI_RankingSlot uiRanking in RankingSlots)
        {
            uiRanking.Refresh(rankings[index]);
            index++;
        }
        
        MyRankingSlot.Refresh(RankingManager.Instance.MyRanking);
    }
    
    
    
}