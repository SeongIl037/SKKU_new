using System;
using TMPro;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using Unity.FPS.UI;
using UnityEngine;

public class UI_Currency : MonoBehaviour
{
    public TextMeshProUGUI Gold;
    public TextMeshProUGUI Diamond;
    public TextMeshProUGUI BuyHealthColor;
    private void Start()
    {
        Refresh();
        
        CurrencyManager.Instance.OnDataChange += Refresh;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            BuyHealth();
        }
    }

    private void Refresh()
    {
        var gold = CurrencyManager.Instance.Get(EcurrencyType.Gold);
        var diamond = CurrencyManager.Instance.Get(EcurrencyType.Diamond);
        
        Gold.text = $"Gold : {gold.Value}";
        Diamond.text = $"Diamond : {diamond.Value}";
        
        BuyHealthColor.color = gold.HaveEnough(300) ? Color.green : Color.red;
    }

    public void BuyHealth()
    {
        // 
        if (CurrencyManager.Instance.TryBuy(EcurrencyType.Gold, 300))
        {
            var player = GameObject.FindFirstObjectByType<PlayerCharacterController>();
            Health playerHealth = player.GetComponent<Health>();
            playerHealth.Heal(100);

        }
    }
}
