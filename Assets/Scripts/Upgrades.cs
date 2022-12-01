using System;
using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public GameObject upgradePanel;
    bool upgradeActive = false;

    //FireRate
    public GameObject FireRateCoinReqirementTXT;
    TextMeshProUGUI FireRateCoinTXT;
    private int FireRateLimit = 6;
    private int FireRateCounter;
    private double FireRateCoinReqirement = 30;

    //Damage
    public GameObject DamageCoinRequirementTXT;
    TextMeshProUGUI DamageCoinTXT;
    private int DamageLimit = 2;
    public static float BulletDamage;
    private int DamageCounter;
    private double DamageCoinRequirement = 40;

    //Pierce
    public GameObject PierceCoinRequirementTXT;
    TextMeshProUGUI PierceCoinTXT;
    private int PierceLimit = 5;
    public static float BulletPierce;
    private int PierceCounter;
    private double PierceCoinRequirement = 50;

    void Start()
    {
        upgradePanel.SetActive(false);
        FireRateCounter = 0;
        BulletDamage = 1;
        DamageCounter = 0;
        PierceCounter = 0;
        BulletPierce = 1;

        FireRateCoinTXT = FireRateCoinReqirementTXT.GetComponent<TextMeshProUGUI>();
        DamageCoinTXT = DamageCoinRequirementTXT.GetComponent<TextMeshProUGUI>();
        PierceCoinTXT = PierceCoinRequirementTXT.GetComponent<TextMeshProUGUI>();
        FireRateCoinTXT.text = "$" + FireRateCoinReqirement.ToString();
        DamageCoinTXT.text = "$" + DamageCoinRequirement.ToString();
        PierceCoinTXT.text = "$" + PierceCoinRequirement.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
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
    }

    public void FireRateUpgrade()
    {
        if (GameManager.Coins >= FireRateCoinReqirement && !(FireRateCounter >= FireRateLimit))
        {
            FireRateCounter++;
            GameManager.Coins = Math.Round(GameManager.Coins - FireRateCoinReqirement);
            Shoot.attackRate += 1;
            FireRateCoinReqirement = Math.Round(FireRateCoinReqirement * 1.6);
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
            BulletDamage++;
            DamageCoinRequirement = Math.Round(DamageCoinRequirement * 1.8);
            DamageCoinTXT.text = "$" + DamageCoinRequirement.ToString();
            if (DamageCounter >= DamageLimit)
            {
                DamageCoinTXT.text = "MAX";
            }
        }
    }

    public void PierceUpgrade()
    {
        if (GameManager.Coins >= PierceCoinRequirement && !(PierceCounter >= PierceLimit))
        {
            PierceCounter++;
            GameManager.Coins = Math.Round(GameManager.Coins - PierceCoinRequirement);
            BulletPierce++;
            PierceCoinRequirement = Math.Round(PierceCoinRequirement * 1.4);
            PierceCoinTXT.text = "$" + PierceCoinRequirement.ToString();
            if (PierceCounter >= PierceLimit)
            {
                PierceCoinTXT.text = "MAX";
            }
        }
    }


    
}
