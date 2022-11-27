using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CapsuleCollider2D playerCollider;
    public LayerMask groundLayer;
    public Rigidbody2D rb;
    float move;
    public float playerSpeed = 30f;
    public float jumpPower = 36f;

    public bool isgrounded;

    void Start()
    {
        playerCollider = gameObject.GetComponent<CapsuleCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        isgrounded = isGrounded();

        if(isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpPower;
        }

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
