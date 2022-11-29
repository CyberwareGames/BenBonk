using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI WaveText;
    public TMPro.TextMeshProUGUI KillsText;
    public TMPro.TextMeshProUGUI CoinsText;

    void Start()
    {
        
    }

    void Update()
    {
        WaveText.text = "Wave: " + GameManager.WaveNum;
        KillsText.text = "Kills: " + GameManager.Kills;
        CoinsText.text = "Coins: $" + GameManager.Coins;
        
    }
}
