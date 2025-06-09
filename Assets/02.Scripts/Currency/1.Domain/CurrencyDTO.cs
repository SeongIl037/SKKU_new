using UnityEngine;

// 계층 간 데이터 전송을 위해 도메인 모델 대신에 사용하는 것
public class CurrencyDTO
{
    public readonly EcurrencyType Type;
    public readonly int Value;

    public CurrencyDTO(Currency currency)
    {
        Type = currency.Type;
        Value = currency.Value;
    }

    public CurrencyDTO(EcurrencyType type, int value)
    {
        Type = type;
        Value = value;
    }
    public bool HaveEnough(int value)
    {
        return Value >= value;
    }
}
