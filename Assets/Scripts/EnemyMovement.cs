using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D enemy;
    public int enemySpeed;
    void Start()
    {
        enemySpeed = 4;
    }
    private void Update()
    {
    }

    void FixedUpdate()
    {
        enemy.velocity = new Vector2(enemySpeed + GameManager.WaveNum*2f, enemy.velocity.y);
        if (enemy.velocity.y > 0.1f)
            enemy.velocity = new Vector2(enemySpeed / 2f, 0f);
    }
}
