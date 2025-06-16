using UnityEngine;

public class AttendanceRewardDTO : MonoBehaviour
{
    public readonly EcurrencyType CurrencyType;
    public readonly int Amount;
    public readonly bool Claimed;
    public readonly bool canClaimed;
    public AttendanceRewardDTO(EcurrencyType currencyType, int amount, bool claimed, bool canClaimed)
    {
        this.CurrencyType = currencyType;
        this.Amount = amount;
        this.Claimed = claimed;
        this.canClaimed = canClaimed;
    }

}