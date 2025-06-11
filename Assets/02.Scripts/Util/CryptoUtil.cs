using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

// 암호화 기능을 제공하는 유틸
public class CryptoUtil : MonoBehaviour
{
    public static string Encryption(string plainText, string salt ="")
    {
        SHA256 sha256 = SHA256.Create();
        // 운영체제 혹은 프로그래밍 언어별로 string 표현하는 방식이 다 다르므로
        // utf8 버전으로 바꿔주어야한다.
        byte[] bytes = Encoding.UTF8.GetBytes(plainText + salt);
        byte[] hash = sha256.ComputeHash(bytes);

        string resultText = String.Empty;
        
        foreach (byte b in hash)
        {
            resultText += b.ToString("x2");
        }
        
        return resultText;
    }

    public static bool Verify(string plainText, string hash, string salt = "" )
    {
        return Encryption(plainText, salt) == hash;
    }
}
