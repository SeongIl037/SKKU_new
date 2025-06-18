using System;
using UnityEngine;

public class Ranking
{
    public readonly string Nickname;
    public readonly string Email;

    public int Rank { get; private set; }
    public int Score { get; private set; }

    public Ranking(string nickname, string email, int score)
    {
        var emailspecification = new AccountEmailSpecification();
        if (!emailspecification.IsStatisfiedBy(email))
        {
            throw new Exception(emailspecification.ErrorMessage);
        }
        // 닉네임 검증

        var nicknamespecification = new AccountNicknameSpecification();
        if (!nicknamespecification.IsStatisfiedBy(nickname))
        {
            throw new Exception(nicknamespecification.ErrorMessage);
        }
        
        if (score < 0)
        {
            throw new Exception("올바르지 못한 점수입니다.");
        }
        
        Nickname = nickname;
        Email = email;
        Score = score;
    }

    public void SetRank(int rank)
    {
        if (rank <= 0)
        {
            throw new Exception("올바르지 못한 등수입니다.");
        }
        
        Rank = rank;
    }

    public void AddScore(int score)
    {
        if (score <= 0)
        {
            throw new Exception("추가될 수 없는 점수입니다.");
        }
        
        Score += score;
    }

    public RankingDTO ToDTO()
    {
        return new RankingDTO(this);
    }
}
