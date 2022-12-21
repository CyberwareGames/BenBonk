using System;
using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public bool UpgradedGun;
    public GameObject upgradePanel;
    bool upgradeActive = false;

    //Pierce
    public GameObject PierceCoinRequirementTXT;
    TextMeshProUGUI PierceCoinTXT;
    private double PierceCoinRequirement = 10;
    public static int PierceLimit;
    public static int PierceCounter;

    //FireRate
    public GameObject FireRateCoinReqirementTXT;
    TextMeshProUGUI FireRateCoinTXT;
    private double FireRateCoinReqirement = 10;
    public static int FireRateLimit;
    public static int FireRateCounter;

    //Damage
    public GameObject DamageCoinRequirementTXT;
    TextMeshProUGUI DamageCoinTXT;
    private double DamageCoinRequirement = 10;
    public static int DamageLimit;
    public static int DamageCounter;


    //ExtraBullet
    public GameObject ExtraBulletCoinRequirementTXT;
    TextMeshProUGUI ExtraBulletCoinTXT;
    private double ExtraBulletCoinRequirement = 10;
    public static int ExtraBulletLimit;
    public static int ExtraBulletCounter;


    void Start()
    {
        upgradePanel.SetActive(false);
        PierceCoinTXT = PierceCoinRequirementTXT.GetComponent<TextMeshProUGUI>();
        FireRateCoinTXT = FireRateCoinReqirementTXT.GetComponent<TextMeshProUGUI>();
        DamageCoinTXT = DamageCoinRequirementTXT.GetComponent<TextMeshProUGUI>();
        ExtraBulletCoinTXT = ExtraBulletCoinRequirementTXT.GetComponent<TextMeshProUGUI>();

        if (UpgradedGun)
        {
            PierceCounter = 2;
            PierceLimit = 6;
            FireRateCounter = 2;
            FireRateLimit = 7;
            DamageCounter = 2;
            DamageLimit = 7;
            ExtraBulletCounter = 1;
            ExtraBulletLimit = 3;
            ExtraBulletCoinTXT.text = "(lvl " + ExtraBulletCounter.ToString() + ") $" + ExtraBulletCoinRequirement.ToString();
        }
        else
        {
            PierceCounter = 1;
            PierceLimit = 3;
            FireRateCounter = 1;
            FireRateLimit = 3;
            DamageCounter = 1;
            DamageLimit = 4;
            ExtraBulletCounter = 1;
            ExtraBulletLimit = 1;
            ExtraBulletCoinTXT.text = "MAX";
        }


        PierceCoinTXT.text = "(lvl " + PierceCounter.ToString() + ") $" + PierceCoinRequirement.ToString();
        FireRateCoinTXT.text = "(lvl " + FireRateCounter.ToString() + ") $" + FireRateCoinReqirement.ToString();
        DamageCoinTXT.text = "(lvl " + DamageCounter.ToString() + ") $" + DamageCoinRequirement.ToString();


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
            PierceCoinTXT.text = "(lvl " + PierceCounter.ToString() + ") $" + PierceCoinRequirement.ToString();
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
            FireRateCoinTXT.text = "(lvl " + FireRateCounter.ToString() + ") $" + FireRateCoinReqirement.ToString();
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
            DamageCoinTXT.text = "(lvl " + DamageCounter.ToString() + ") $" + DamageCoinRequirement.ToString();
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
            ExtraBulletCoinTXT.text = "(lvl " + ExtraBulletCounter.ToString() + ") $" + ExtraBulletCoinRequirement.ToString();
            if (ExtraBulletCounter >= ExtraBulletLimit)
            {
                ExtraBulletCoinTXT.text = "MAX";
            }
        }
    }
}
