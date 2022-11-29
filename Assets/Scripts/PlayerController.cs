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
    public float jumpPower = 46f;


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
            playerSpeed = 30f;
            if (Input.GetKeyDown(KeyCode.Space))
                rb.velocity = Vector2.up * jumpPower;
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
    }

}
