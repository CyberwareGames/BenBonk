using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CapsuleCollider2D playerCollider;
    bool facingright = true;
    public Rigidbody2D rb;
    float move;
    float playerSpeed = 30f, jumpPower = 300f;

    void Start()
    {
        playerCollider = gameObject.GetComponent<CapsuleCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        if(isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpPower;
        }

        if (move < 0f && !facingright)
        {
            Flip();
        }
        else if (move > 0f && facingright)
        {
            Flip();
        }
    }

    private bool isGrounded()
    {
        bool isGrounded = Physics.Raycast(transform.position, -gameObject.transform.up, playerCollider.bounds.extents.y + 0.1f);
        return isGrounded;
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2((move * playerSpeed), 0);
    }

    void Flip()
    {
        facingright = !facingright;
        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
}
