using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float health;
    void Start()
    {
        health = 3f;
    }

    void Update()
    {
        if (health <= 0)
        {
            GameManager.Coins += 5;
            GameManager.Kills++;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            decreaseHealth();
        }
    }
    public void decreaseHealth()
    {
        health -= Shoot.BulletDamage;
    }
}
