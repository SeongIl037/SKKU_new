using UnityEngine;


public class RankingDTO : MonoBehaviour 
{
    public readonly string Nickname;
    public readonly string Email;
    public readonly int Rank;
    public readonly int Score;

    public RankingDTO(Ranking ranking)
    {
        Nickname = ranking.Nickname;
        Email = ranking.Email;
        Rank = ranking.Rank;
        Score = ranking.Score;
    }
}
