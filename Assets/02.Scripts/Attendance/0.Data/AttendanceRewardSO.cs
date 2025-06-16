using UnityEngine;

[CreateAssetMenu(fileName = "AttendanceRewardSO", menuName = "Scriptable Objects/AttendanceRewardSO")]
public class AttendanceRewardSO : ScriptableObject
{
    [SerializeField]
    private EcurrencyType _currencyType;
    public EcurrencyType CurrnecyType => _currencyType;
    [SerializeField]
    private int _amount;
    public int Amount => _amount;
    
    
}
