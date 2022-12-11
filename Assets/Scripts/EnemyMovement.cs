using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D enemy;
    public int enemySpeed;
    void Start()
    {
    }

    void FixedUpdate()
    {
        enemy.velocity = new Vector2(enemySpeed + GameManager.WaveNum, enemy.velocity.y);
        if (enemy.velocity.y > 0.1f)
            enemy.velocity = new Vector2(enemySpeed / 2, 0f);
    }
}
