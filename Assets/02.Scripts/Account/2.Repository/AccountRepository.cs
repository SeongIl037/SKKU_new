using UnityEngine;

public class AccountRepository : MonoBehaviour
{
    private const string SAVE_KEY = nameof(AccountRepository);

    public void Save(AccountDTO accountDTO)
    {
        AccountSaveData data = new AccountSaveData(accountDTO);
        string json = JsonUtility.ToJson(data);
        
        PlayerPrefs.SetString(SAVE_KEY + data.Email, json);
    }

    public AccountSaveData Find(string email)
    {
        if (!PlayerPrefs.HasKey(SAVE_KEY + email))
        {
            return null;
        }
        
        return JsonUtility.FromJson<AccountSaveData>(PlayerPrefs.GetString(SAVE_KEY + email));
    }
}

public class AccountSaveData
{
    public string Email;
    public string Nickname;
    public string Password;

    public AccountSaveData(AccountDTO accountDTO)
    {
        Email = accountDTO.Email;
        Nickname = accountDTO.Nickname;
        Password = accountDTO.Password;
    }
}
