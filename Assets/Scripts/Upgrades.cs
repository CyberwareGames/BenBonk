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
    private double PierceCoinRequirement = 0;

    //FireRate
    public GameObject FireRateCoinReqirementTXT;
    TextMeshProUGUI FireRateCoinTXT;
    private int FireRateLimit = 7;
    public static int FireRateCounter;
    private double FireRateCoinReqirement = 0;

    //Damage
    public GameObject DamageCoinRequirementTXT;
    TextMeshProUGUI DamageCoinTXT;
    private int DamageLimit = 6;
    public static int DamageCounter;
    private double DamageCoinRequirement = 0;

    //ExtraBullet
    public GameObject ExtraBulletCoinRequirementTXT;
    TextMeshProUGUI ExtraBulletCoinTXT;
    private int ExtraBulletLimit = 3;
    public static int ExtraBulletCounter;
    private double ExtraBulletCoinRequirement = 0;


    void Start()
    {
        upgradePanel.SetActive(false);
        FireRateCounter = 1;
        DamageCounter = 1;
        PierceCounter = 1;
        ExtraBulletCounter = 1;
        PierceCoinTXT = PierceCoinRequirementTXT.GetComponent<TextMeshProUGUI>();
        FireRateCoinTXT = FireRateCoinReqirementTXT.GetComponent<TextMeshProUGUI>();
        DamageCoinTXT = DamageCoinRequirementTXT.GetComponent<TextMeshProUGUI>();
        ExtraBulletCoinTXT = ExtraBulletCoinRequirementTXT.GetComponent<TextMeshProUGUI>();
        PierceCoinTXT.text = "$" + PierceCoinRequirement.ToString();
        FireRateCoinTXT.text = "$" + FireRateCoinReqirement.ToString();
        DamageCoinTXT.text = "$" + DamageCoinRequirement.ToString();
        ExtraBulletCoinTXT.text = "$" + ExtraBulletCoinRequirement.ToString();
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
            PierceCoinRequirement = Math.Round(PierceCoinRequirement * 1.5);
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
            FireRateCoinReqirement = Math.Round(FireRateCoinReqirement * 1.5);
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
            DamageCoinRequirement = Math.Round(DamageCoinRequirement * 1.5);
            DamageCoinTXT.text = "$" + DamageCoinRequirement.ToString();
            if (DamageCounter >= DamageLimit)
            {
                DamageCoinTXT.text = "MAX";
            }
        }
    }

    public void ExtraBulletUpgrade()
    {
        if (GameManager.Coins >= ExtraBulletCoinRequirement && !(ExtraBulletCounter >= ExtraBulletLimit))
        {
            ExtraBulletCounter++;
            GameManager.Coins = Math.Round(GameManager.Coins - ExtraBulletCoinRequirement);
            ExtraBulletCoinRequirement = Math.Round(ExtraBulletCoinRequirement * 1.5);
            ExtraBulletCoinTXT.text = "$" + ExtraBulletCoinRequirement.ToString();
            if (ExtraBulletCounter >= ExtraBulletLimit)
            {
                ExtraBulletCoinTXT.text = "MAX";
            }
        }
    }
}
