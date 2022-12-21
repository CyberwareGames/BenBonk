using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float health;
    public BossMovement movement;
    public Rigidbody2D bossRB;
    private float pushback;
    void Start()
    {
        movement.enabled = true;
    }

    void Update()
    {

        if (health <= 0)
        {
            GameManager.Coins += 65;
            GameManager.Kills++;
            Destroy(gameObject);
            pushback = -(Upgrades.DamageCounter/2f) -(Upgrades.PierceCounter/4f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            decreaseHealth();
            movement.enabled = false;
            bossRB.velocity = new Vector2(pushback, bossRB.velocity.y);
            Invoke("EnableMovement", pushback/8f);

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
