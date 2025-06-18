using System;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public static RankingManager Instance;
    private RankingRepository _repository;
    //가져다 쓸 때는 DTO를 활용해야한다.
    private List<Ranking> _rankings;
    public List<RankingDTO> Rankings => _rankings.ConvertAll(r => r.ToDTO());
    // Too
    private Ranking _myRanking;
    public RankingDTO MyRanking => _myRanking.ToDTO();
    
    public event Action OnDataChanged;
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
        _repository = new RankingRepository();

        List<RankingSaveData> saveDatas = _repository.Load();
        
        _rankings = new List<Ranking>();

        foreach (RankingSaveData saveData in saveDatas)
        {
            Ranking ranking = new Ranking(saveData.Nickname,saveData.Email, saveData.Score);
            _rankings.Add(ranking);

            if (ranking.Email == AccountManager.Instance.CurrentAccount.Email)
            {
                _myRanking = ranking;
            }
        }

        if (_myRanking == null)
        {
            AccountDTO me = AccountManager.Instance.CurrentAccount;
            _myRanking = new Ranking(me.Email, me.Nickname, 0);
            _rankings.Add(_myRanking);
        }
        
        Sort();
        
        OnDataChanged?.Invoke();
    }

    private void Sort()
    {
        _rankings.Sort((r1, r2) => r2.Score.CompareTo(r1.Score));
         
        for (int i = 0; i < _rankings.Count; i++)
        {
            _rankings[i].SetRank(i + 1);
        }
    }

    public void AddScore(int score)
    {
        _myRanking.AddScore(score);
        
        Sort();
        
        OnDataChanged?.Invoke();
    }
}
