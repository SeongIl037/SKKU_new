using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class Account
{
    public readonly string Email;
    public readonly string Nickname;
    public readonly string Password;
    
    // 금지된 닉네임 (비속어 등)
    private static readonly string[] ForbiddenNicknames = { "바보", "멍청이", "운영자", "김홍일" };

    public Account(string email, string nickname, string password)
    {   // 규칙을 객체로 캡슐화해서 분리한다.
        // 그래서 도메인과 UI 모두 그 규칙을 만족하는지 판단하면 된다. => 유지보수성이 뛰어나다.
        // 캡슐화한 규칙 : 명세 (specificanttion)
        // 이메일 검증
        var emailspecification = new AccountEmailSpecification();
        var nicknamespecification = new AccountNicknameSpecification();
        
        if (!emailspecification.IsStatisfiedBy(email))
        {
            throw new Exception(emailspecification.ErrorMessage);
        }
        // 닉네임 검증

        if (!nicknamespecification.IsStatisfiedBy(nickname))
        {
            throw new Exception(nicknamespecification.ErrorMessage);
        }

        // 비밀번호 검증
        if (string.IsNullOrEmpty(password))
        {
            throw new Exception("비밀번호는 비어있을 수 없습니다.");
        }
        
        var passwordspecification = new AccountPasswordSpecification();
        Debug.Log($"{password}");

        Email = email;
        Nickname = nickname;
        Password = password;
    }

    public AccountDTO ToDTO()
    {
        return new AccountDTO(Email, Nickname, Password);
    }
}