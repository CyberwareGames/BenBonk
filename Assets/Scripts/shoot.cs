using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public GameObject upgradePanel;
    public GameObject spawn;
    bool upgradeactive = false;
    public float speed = .5f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

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
        attackRate += 1;
    }
}
