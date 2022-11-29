using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D enemy;
    public int enemySpeed;
    void Start()
    {
        enemySpeed = 5 + GameManager.WaveNum;
    }
    private void Update()
    {
    }

    void FixedUpdate()
    {
        enemy.velocity = new Vector2(enemySpeed, enemy.velocity.y);
    }
}
