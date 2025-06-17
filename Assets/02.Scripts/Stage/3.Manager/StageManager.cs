using System;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    
    public event Action OnDataChanged;

    [SerializeField] private List<StageLevelSO> _levelSOList;
    private Stage _Stage;
    public Stage Stage => _Stage;
        // todo : stage dto 만
        //
        // 들기
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
        _Stage = new Stage(1, 2,17, _levelSOList);
        OnDataChanged?.Invoke();
    }

    private void Update()
    {
        _Stage.Progress(Time.deltaTime, OnDataChanged);
    }
}