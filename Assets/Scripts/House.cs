using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            FindObjectOfType<GameManager>().LosePanel.SetActive(true);
            Upgrades.PierceCounter = 1;
            Upgrades.FireRateCounter = 1;
            Upgrades.DamageCounter = 1;
            Time.timeScale = 0f;
        }
    }
}
