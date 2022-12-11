using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public EnemyMovement movement;
    public Rigidbody2D enemyRB;
    private float pushback;
    void Start()
    {
        movement.enabled = true;
    }

    void Update()
    {

        if (health <= 0)
        {
            GameManager.Coins += 25;
            GameManager.Kills++;
            Destroy(gameObject);
        }
        pushback = -(Upgrades.DamageCounter) -(Upgrades.PierceCounter/2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            decreaseHealth();
            movement.enabled = false;
            enemyRB.velocity = new Vector2(pushback, enemyRB.velocity.y);
            Invoke("EnableMovement", pushback/10f);
            
        }
    }
    private void EnableMovement()
    {
        movement.enabled = true;
    }
    public void decreaseHealth()
    {
        health -= Upgrades.DamageCounter;
    }
}
