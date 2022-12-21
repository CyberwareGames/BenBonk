using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CapsuleCollider2D playerCollider;
    public LayerMask groundLayer;
    public Rigidbody2D rb;
    float move;
    public float playerSpeed;
    public float jumpPower = 40f;
    public AudioSource Jump;


    void Start()
    {
        playerCollider = gameObject.GetComponent<CapsuleCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        if (isGrounded())
        {
            playerSpeed = 28f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump.Play();
                rb.velocity = Vector2.up * jumpPower;
            }
        }
        else playerSpeed = 20f;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(playerCollider.bounds.center , playerCollider.bounds.size - new Vector3(0.1f, 0f, 0f), 0f, Vector2.down, 1f, groundLayer);
        return raycastHit2D.collider != null;
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2((move * playerSpeed), rb.velocity.y);
        if(rb.velocity.y <= 1f)
            rb.AddForce(new Vector2(0f, -jumpPower), ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            FindObjectOfType<GameManager>().LosePanel.SetActive(true);
            Upgrades.PierceCounter = 1;
            Upgrades.FireRateCounter = 1;
            Upgrades.DamageCounter = 1;
            Upgrades.ExtraBulletCounter = 1;
            Time.timeScale = 0f;
        }
    }
}
