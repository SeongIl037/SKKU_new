using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// 디자인 패턴 : 설계를 구현하는 과정에서 쓰이는 패턴
// 아키텍쳐 : 설계 (설계마다 철학이 있다.)
public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;
    
    // 이 재화를 담아둘 장소
    private Dictionary<EcurrencyType, Currency> _currencies;
    
    private CurrencyRepository _repository;
    public event Action OnDataChange;
    // 세분화가 필요하지만 너무 많이 하면 안된다. => 미리하는 최적화는 의미 없다. ( 최적화는 마무리에)
    // public event Action OnGoldChanged;
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
    // 관리자 = Manager (추가, 삭제 등) , 관리 + 창구
    private void Init()
    {
        // 생성하기
        _currencies = new Dictionary<EcurrencyType, Currency>((int)EcurrencyType.Count);
 
        // 레포지토리 생성
        _repository = new CurrencyRepository();

        List<CurrencyDTO> loadedCurrencies = _repository.Load();
        
        if (loadedCurrencies == null)
        {
            for (int i = 0; i < (int)EcurrencyType.Count; ++i)
            {
                EcurrencyType type = (EcurrencyType)i;
                //골드 다이아와 같은 재화를 0으로 생성 -> 딕셔너리에 삽입
                Currency currency = new Currency(type, 0);
                _currencies.Add(type, currency);
            }
        }
        else
        {
            foreach (var data in loadedCurrencies )
            {
                Currency currency = new Currency(data.Type, data.Value);
                _currencies.Add(data.Type, currency);
            }
        }
    }

    private List<CurrencyDTO> ToDTOList()
    {
        return _currencies.ToList().ConvertAll(currency => new CurrencyDTO(currency.Value));
    }
    public CurrencyDTO Get(EcurrencyType type)
    {
        return new CurrencyDTO(_currencies[type]);
    }
    public void Add(EcurrencyType type, int value)
    {
        _currencies[type].Add(value);
        
        
        AchieveManager.Instance.Increase(EachievementCondition.GoldCollect, value);
        
        _repository.Save(ToDTOList());
        OnDataChange?.Invoke();
        
    }
    

    public bool TryBuy(EcurrencyType type, int value)
    {
        if (!_currencies[type].TryBuy(value))
        {
            return false;   
        }
        _repository.Save(ToDTOList());
        OnDataChange?.Invoke();

        return true;
    }
}
