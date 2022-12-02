using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float health;
    public EnemyMovement movement;
    public Rigidbody2D enemyRB;
    void Start()
    {
        movement.enabled = true;
        health = 3f;
    }

    void Update()
    {

        if (health <= 0)
        {
            GameManager.Coins += 15;
            GameManager.Kills++;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            decreaseHealth();
            movement.enabled = false;
            enemyRB.velocity = new Vector2(-12f, enemyRB.velocity.y);
            Invoke("EnableMovement", 0.1f);
            
        }
    }
    private void EnableMovement()
    {
        movement.enabled = true;
    }
    public void decreaseHealth()
    {
        health -= Upgrades.BulletDamage;
    }
}
