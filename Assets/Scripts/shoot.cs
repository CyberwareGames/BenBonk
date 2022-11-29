using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public GameObject upgradePanel;
    public GameObject spawn;
    bool upgradeactive = false;
    public float speed = .5f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public static float BulletDamage = 1;
    public static float BulletPierce = 1;
    private double FireRateCoinReqirement = 10;
    private double DamageCoinRequirement = 20;
    private double PierceCoinRequirement = 40;
    public GameObject FireRateCoinReqirementTXT;
    public GameObject DamageCoinRequirementTXT;
    public GameObject PierceCoinRequirementTXT;
    TextMeshProUGUI FireRateCoinTXT;
    TextMeshProUGUI DamageCoinTXT;
    TextMeshProUGUI PierceCoinTXT;
    private int FireRateLimit = 10;
    private int DamageLimit = 5;
    private int PierceLimit = 5;
    private int FireRateCounter = 0;
    private int DamageCounter = 0;
    public int PierceCounter = 0;
    private void Start()
    {
        upgradePanel.SetActive(false);
        FireRateCoinTXT = FireRateCoinReqirementTXT.GetComponent<TextMeshProUGUI>();
        DamageCoinTXT = DamageCoinRequirementTXT.GetComponent<TextMeshProUGUI>();
        PierceCoinTXT = PierceCoinRequirementTXT.GetComponent<TextMeshProUGUI>();
        FireRateCoinTXT.text = "$" + FireRateCoinReqirement.ToString();
        DamageCoinTXT.text = "$" + DamageCoinRequirement.ToString();
        PierceCoinTXT.text = "$" + PierceCoinRequirement.ToString();
    }
    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                FindObjectOfType<ScreenShaker>().shake = true;
                shooting();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            upgradeactive = !upgradeactive;
            upgradePanel.SetActive(upgradeactive);
            if (upgradeactive)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
    void FixedUpdate()
    {
        Vector3 difference = -Camera.main.ScreenToWorldPoint(Input.mousePosition) + transform.position;

        difference.Normalize();

        float rotaionangle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotaionangle);

    }
    void shooting()
    {
        GameObject projectile = (GameObject)Instantiate(bullet, spawn.transform.position, Quaternion.identity);
        projectile.transform.right = transform.right;
        
    }
    public void FireRateUpgrade()
    {
        if (GameManager.Coins >= FireRateCoinReqirement && !(FireRateCounter >= FireRateLimit))
        {
            FireRateCounter++;
            GameManager.Coins = Math.Round(GameManager.Coins - FireRateCoinReqirement);
            attackRate += 1;
            FireRateCoinReqirement = Math.Round(FireRateCoinReqirement * 1.3);
            
            FireRateCoinTXT.text = "$" + FireRateCoinReqirement.ToString();
            if (FireRateCounter >= FireRateLimit)
            {
                FireRateCoinTXT.text = "Max";
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
            DamageCoinRequirement = Math.Round(DamageCoinRequirement * 1.3);
            DamageCoinTXT.text = "$" + DamageCoinRequirement.ToString();
            if (DamageCounter >= DamageLimit)
            {
                DamageCoinTXT.text = "Max";
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
            PierceCoinRequirement = Math.Round(PierceCoinRequirement * 1.3);
            PierceCoinTXT.text = "$" + PierceCoinRequirement.ToString();
            if (PierceCounter >= PierceLimit)
            {
                PierceCoinTXT.text = "Max";
            }
        }
    }
}
