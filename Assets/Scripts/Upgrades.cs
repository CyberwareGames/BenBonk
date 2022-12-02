using System;
using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public GameObject upgradePanel;
    bool upgradeActive = false;

    //Pierce
    public GameObject PierceCoinRequirementTXT;
    TextMeshProUGUI PierceCoinTXT;
    private int PierceLimit = 5;
    public static int PierceCounter;
    private double PierceCoinRequirement = 30;

    //FireRate
    public GameObject FireRateCoinReqirementTXT;
    TextMeshProUGUI FireRateCoinTXT;
    private int FireRateLimit = 7;
    public static int FireRateCounter;
    private double FireRateCoinReqirement = 70;

    //Damage
    public GameObject DamageCoinRequirementTXT;
    TextMeshProUGUI DamageCoinTXT;
    private int DamageLimit = 9;
    public static int DamageCounter;
    private double DamageCoinRequirement = 90;


    void Start()
    {
        upgradePanel.SetActive(false);
        FireRateCounter = 1;
        DamageCounter = 1;
        PierceCounter = 1;
        PierceCoinTXT = PierceCoinRequirementTXT.GetComponent<TextMeshProUGUI>();
        FireRateCoinTXT = FireRateCoinReqirementTXT.GetComponent<TextMeshProUGUI>();
        DamageCoinTXT = DamageCoinRequirementTXT.GetComponent<TextMeshProUGUI>();
        PierceCoinTXT.text = "$" + PierceCoinRequirement.ToString();
        FireRateCoinTXT.text = "$" + FireRateCoinReqirement.ToString();
        DamageCoinTXT.text = "$" + DamageCoinRequirement.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Pause();
        }
    }

    public void Pause()
    {
        upgradeActive = !upgradeActive;
        upgradePanel.SetActive(upgradeActive);
        if (upgradeActive)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }


    public void PierceUpgrade()
    {
        if (GameManager.Coins >= PierceCoinRequirement && !(PierceCounter >= PierceLimit))
        {
            PierceCounter++;
            GameManager.Coins = Math.Round(GameManager.Coins - PierceCoinRequirement);
            PierceCoinRequirement = Math.Round(PierceCoinRequirement * 1.8);
            PierceCoinTXT.text = "$" + PierceCoinRequirement.ToString();
            if (PierceCounter >= PierceLimit)
            {
                PierceCoinTXT.text = "MAX";
            }
        }
    }

    public void FireRateUpgrade()
    {
        if (GameManager.Coins >= FireRateCoinReqirement && !(FireRateCounter >= FireRateLimit))
        {
            FireRateCounter++;
            GameManager.Coins = Math.Round(GameManager.Coins - FireRateCoinReqirement);
            FireRateCoinReqirement = Math.Round(FireRateCoinReqirement * 1.8);
            FireRateCoinTXT.text = "$" + FireRateCoinReqirement.ToString();
            if (FireRateCounter >= FireRateLimit)
            {
                FireRateCoinTXT.text = "MAX";
            }
        }
    }

    public void DamageUpgrade()
    {
        if (GameManager.Coins >= DamageCoinRequirement && !(DamageCounter >= DamageLimit))
        {
            DamageCounter++;
            GameManager.Coins = Math.Round(GameManager.Coins - DamageCoinRequirement);
            DamageCoinRequirement = Math.Round(DamageCoinRequirement * 1.8);
            DamageCoinTXT.text = "$" + DamageCoinRequirement.ToString();
            if (DamageCounter >= DamageLimit)
            {
                DamageCoinTXT.text = "MAX";
            }
        }
    }
}
