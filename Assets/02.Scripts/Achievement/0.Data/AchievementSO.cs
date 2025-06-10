using UnityEngine;
// 런타임시 변하지 않는 값을 SO로 관리하면
// 기획자가 에디터에서 직접 수정이 가능하다.
// 유지보수와 확장성이 증가한다.
// 도메인 객체는 상태만 관리한다.

[CreateAssetMenu(fileName = "AchievementSO", menuName = "Scriptable Objects/AchievementSO")]
public class AchievementSO : ScriptableObject
{
    [SerializeField]
    private string _id;
    public string ID => _id;
    
    [SerializeField]
    private string _name;
    public string Name => _name;
    
    [SerializeField]
    private string _description;
    public string Description => _description;
    
    [SerializeField]
    private EachievementCondition _condition;
    public EachievementCondition Condition => _condition;
    
    [SerializeField]
    private int _goalValue;
    public int GoalValue => _goalValue;
    
    [SerializeField]
    private EcurrencyType _rewardCurrencyType;
    public EcurrencyType RewardCurrencyType => _rewardCurrencyType;
    
    [SerializeField]
    private int _rewardAmount;
    public int RewardAmount => _rewardAmount;
}
