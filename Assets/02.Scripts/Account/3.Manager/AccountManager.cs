using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class AccountManager : MonoBehaviour
{
    public static AccountManager Instance;
    
    private Account _account;
    public AccountDTO CurrentAccount => _account.ToDTO();
    private AccountRepository _accountRepository;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        Init();
    }

    private void Init()
    {
        // 저장된 아이디 가져오기
        _accountRepository = new AccountRepository();
        
        
    }
    
    private const string SALT = "12345678";
    // 어카운트 등록하기
    public Result TryRegisterAccount(string email, string nickname, string password)
    {
        AccountSaveData saveData = _accountRepository.Find(email);

        if (saveData != null)
        {
            return new Result(false, "이미 가입한 메일입니다.");
        }
        
        string encryptedPassword = CryptoUtil.Encryption(password + SALT);
        Account account = new Account(email, nickname, encryptedPassword);
        
        //레포지토리에 저장하기;
        
        _accountRepository.Save(account.ToDTO());
        return new Result( true, account.ToString());
    }
    
    
    public bool TryLogin(string email, string password)
    {
        AccountSaveData saveData = _accountRepository.Find(email);
        if (saveData == null)
        {
            return false;
        }

        if (CryptoUtil.Verify(password,saveData.Password, SALT))
        {
            _account = new Account(saveData.Email, saveData.Nickname, saveData.Password);
            return true;
        }
        
        return false;
    }
}
