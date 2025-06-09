using System.Collections.Generic;
using UnityEngine;

// 영속성을 위한 스크립트 
public class CurrencyRepository
{
    private const string SAVE_KEY = nameof(CurrencyRepository);
    // repository : 데이터의 영속성을 보장한다. + 인프라
    // 프로그램을 종료해도 데이터가 보존되는 것.
    // save
    public void Save(List<CurrencyDTO> currencies)
    {
        CurrencySaveDatas datas = new CurrencySaveDatas();
        
        datas.DataList = currencies.ConvertAll(data => new CurrencySaveData()
        {
            Value = data.Value,
            Type = data.Type
        });
        
        string json = JsonUtility.ToJson(datas);
        PlayerPrefs.SetString (SAVE_KEY, json);
    }
    // load
    public List<CurrencyDTO> Load()
    {
        if (!PlayerPrefs.HasKey(SAVE_KEY))
        { 
            return null;   
        }
        string json = PlayerPrefs.GetString (SAVE_KEY);
        CurrencySaveDatas datas = JsonUtility.FromJson<CurrencySaveDatas> (json);
        
        return datas.DataList.ConvertAll<CurrencyDTO>(data => new CurrencyDTO(data.Type,data.Value));
    }
}

public struct CurrencySaveData
{
    public EcurrencyType Type;
    public int Value;
}
public class CurrencySaveDatas
{
    public List<CurrencySaveData> DataList;
}