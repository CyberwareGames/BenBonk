using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Rigidbody2D enemy;
    public int enemySpeed;
    void Start()
    {
        enemySpeed = 14;
    }

    void FixedUpdate()
    {
        enemy.velocity = new Vector2(enemySpeed, enemy.velocity.y);
        if (enemy.velocity.y > 0.1f)
            enemy.velocity = new Vector2(enemySpeed / 2f, 0f);
    }
}
