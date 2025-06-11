using System;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

[Serializable]
public class UI_InputFields
{
    public TMP_InputField IDInputField;
    public TMP_InputField PasswordInputField;
    public TMP_InputField NicknameInputField;
    public TMP_InputField PasswordComfirmInputField;
    public TextMeshProUGUI ResultText;
    public Button ConfirmButton;
}
public class UI_LoginScene : MonoBehaviour
{
    [Header("패널")]
    public GameObject LoginPanel;
    public GameObject RegisterPanel;
    [Header("로그인")]
    public UI_InputFields LoginInputField;
    [Header("회원가입")]
    public UI_InputFields RegisterInputField;

    private const string PREFIX = "ID_";
    private const string SALT = "1004000";
    private void Start()
    {
        LoginPanel.SetActive(true);
        RegisterPanel.SetActive(false);
        
        LoginCheck();
    }
    //회원가입하기
    public void OnClickGoToRegisterButton()
    {
        LoginPanel.SetActive(false);
        RegisterPanel.SetActive(true);
        RefreshRegister();
    }

    public void OnClickGoToLoginButton()
    {
        LoginPanel.SetActive(true);
        RegisterPanel.SetActive(false);
    }

    public void Register()
    {
        //1. 아이디 입력을 확인한다.
        string id = RegisterInputField.IDInputField.text;
        string password = RegisterInputField.PasswordInputField.text;
        string passwordComfirm = RegisterInputField.PasswordComfirmInputField.text;
        string nickname = RegisterInputField.NicknameInputField.text;
        
        var accountEmailSpecification = new AccountEmailSpecification();
        var accountNicknameSpecification = new AccountNicknameSpecification();
        var accountPasswordSpecification = new AccountPasswordSpecification();
        
        
        if (!accountEmailSpecification.IsStatisfiedBy(id))
        {
            RegisterInputField.ResultText.text = accountEmailSpecification.ErrorMessage;
            Feedback();
            return;
        }

        if (!accountNicknameSpecification.IsStatisfiedBy(nickname))
        {
            RegisterInputField.ResultText.text = accountNicknameSpecification.ErrorMessage;
            Feedback();
            return;
        }
        
        //2. 비밀번호 입력을 확인한다.
        if (!accountPasswordSpecification.IsStatisfiedBy(password))
        {
            RegisterInputField.ResultText.text = accountPasswordSpecification.ErrorMessage;
            Feedback();
            return;
        }
        //3. 2차 비밀번호 입력을 확인하고, 1차 비밀번호 입력과 같은지 확인한다.
        if (string.IsNullOrEmpty(passwordComfirm))
        {
            RegisterInputField.ResultText.text = "2차 비밀번호를 입력해주세요";
            Feedback();
            return;
        }
        else
        {
            bool result = password == passwordComfirm;
            if (!result)
            {
                RegisterInputField.ResultText.text = "입력한 비밀번호가 다릅니다.";
                Feedback();
                return;
            }
        }
        Result rs = AccountManager.Instance.TryRegisterAccount(id,nickname, password);
        if (rs.IsSuccess)
        {
            // 로그인 창으로 돌아간다.
            OnClickGoToLoginButton();
        }
        
        
        //
        // // 4. playerprefs를 이용해서 아이디와 비밀번호를 저장한다.
        // PlayerPrefs.SetString(PREFIX + id, Encryption(password + SALT));
        // LoginInputField.IDInputField.text = id;
    }

    private void RefreshRegister()
    {
        RegisterInputField.IDInputField.text = "";
        RegisterInputField.NicknameInputField.text = ""; 
        RegisterInputField.PasswordInputField.text = "";
        RegisterInputField.PasswordComfirmInputField.text = "";
        RegisterInputField.ResultText.text = "";
    }

    public string Encryption(string text)
    {
        SHA256 sha256 = SHA256.Create();
        // 운영체제 혹은 프로그래밍 언어별로 string 표현하는 방식이 다 다르므로
        // utf8 버전으로 바꿔주어야한다.
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        byte[] hash = sha256.ComputeHash(bytes);

        string resultText = String.Empty;
        foreach (byte b in hash)
        {
            resultText += b.ToString("x2");
        }
        
        return resultText;
    }
    private void Feedback()
    {
        RegisterInputField.ResultText.rectTransform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.2f).OnComplete(() =>
        {
            RegisterInputField.ResultText.rectTransform.DOScale(new Vector3(1f, 1f, 1f), 0.2f);
        });
    }

    public void LogIn()
    {
        //1. 아이디 입력을 확인한다.
        string id = LoginInputField.IDInputField.text;
        var emailSpecification = new AccountEmailSpecification();
        if (!emailSpecification.IsStatisfiedBy(id))
        {
            LoginInputField.ResultText.text = emailSpecification.ErrorMessage;
            Feedback();
            return;
        }
        
        
        string password = LoginInputField.PasswordInputField.text;
        var accountPasswordSpecification = new AccountPasswordSpecification();
        //2. 비밀번호 입력을 확인한다.
        if (accountPasswordSpecification.IsStatisfiedBy(password))
        {
            LoginInputField.ResultText.text = accountPasswordSpecification.ErrorMessage;
            Feedback();
            return;
        }
        // //3. playerprefs.Get을 이용해서 아이디와 비밀번호가 맞는지 확인한다.
        // if (!PlayerPrefs.HasKey(PREFIX + id))
        // {
        //     LoginInputField.ResultText.text = "아이디와 비밀번호를 확인해주세요";
        //     return;
        // }
        //
        // string hashedPassword = PlayerPrefs.GetString(PREFIX + id);
        // if (hashedPassword != Encryption(password + SALT))
        // {
        //     LoginInputField.ResultText.text = "아이디와 비밀번호를 확인해주세요";
        //     return;
        // }

        if (AccountManager.Instance.TryLogin(id, password))
        {
            SceneManager.LoadScene(1);
            Debug.Log("로그인 성공");
            // 맞다면 로그인
        }
        else
        {
            LoginInputField.ResultText.text = "이메일이 중복되었습니다.";
            Feedback();
        }
    }
    public void LoginCheck()
    {
        string id = LoginInputField.IDInputField.text;
        string password = LoginInputField.PasswordInputField.text;
        
        LoginInputField.ConfirmButton.enabled = !string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(password);
    }
}
