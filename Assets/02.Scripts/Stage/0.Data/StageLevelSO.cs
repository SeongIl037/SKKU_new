using UnityEngine;

[CreateAssetMenu(fileName = "StageLevelSO", menuName = "Scriptable Objects/StageLevelSO")]
public class StageLevelSO : ScriptableObject
{
    [SerializeField]
    private string name;
    public string Name => name;

    [SerializeField]
    private int startLevel;
    public int StartLevel => startLevel;

    [SerializeField]
    private int endLevel;
    public int EndLevel => endLevel;

    [SerializeField]
    private float healthFactor;
    public float HealthFactor => healthFactor;

    [SerializeField]
    private float damageFactor;
    public float DamageFactor => damageFactor;

    [SerializeField]
    private float spawnInterval; // 스폰 주기
    public float SpawnInterval => spawnInterval;

    [SerializeField]
    private float spawnRate; // 스폰 확률
    public float SpawnRate => spawnRate;

}
