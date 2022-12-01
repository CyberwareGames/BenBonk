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
    public GameObject bullet;
    public GameObject spawn;
    public static float attackRate = 2f;
    
    float nextAttackTime = 0f;
    

    private void Start()
    {
        
    }
    private void Update()
    {
        bullet.transform.localScale = new Vector3(0.3f * Upgrades.BulletPierce * Upgrades.BulletPierce, 0.3f * Upgrades.BulletDamage, 1f);
        bullet.transform.localScale = new Vector3(0.3f * Upgrades.BulletPierce * Upgrades.BulletPierce, 0.3f * Upgrades.BulletDamage, 1f);
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                FindObjectOfType<ScreenShaker>().shake = true;
                Shooting();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void FixedUpdate()
    {
        Vector3 difference = -Camera.main.ScreenToWorldPoint(Input.mousePosition) + transform.position;
        difference.Normalize();
        float rotaionAngle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotaionAngle);

    }
    void Shooting()
    {
        GameObject projectile = (GameObject)Instantiate(bullet, spawn.transform.position, Quaternion.identity);
        projectile.transform.right = transform.right;
    }
}
