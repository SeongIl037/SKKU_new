using UnityEngine;

public class AccountPasswordSpecification : ISpecification<string>
{
    
    public bool IsStatisfiedBy(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            ErrorMessage = "비밀번호가 비어있습니다.";
            
            return false;
        }
        
        if (password.Length < 6 || password.Length > 12)
        {
            ErrorMessage = "비밀번호는 6자 이상 12자 이하이어야 합니다.";
            return false;
        }

        return true;
    }
    
    public string ErrorMessage { get; private set; }
}
