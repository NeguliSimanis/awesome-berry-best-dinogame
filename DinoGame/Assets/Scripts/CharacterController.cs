using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float _speed;

    private float speed;
    private float moveHorizontal;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    void Start()
    {
        speed = _speed;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal") * speed;

        Vector2 VelocityX = rb.velocity;
        VelocityX.x = moveHorizontal;
        rb.velocity = VelocityX;

        if (rb.velocity.magnitude > speed)
        {
            rb.velocity *= speed / rb.velocity.magnitude;
        }

        //kinda messy, should refactor it later
        if (moveHorizontal < 0 && rb.velocity.magnitude > 0)
        {
            sprite.flipX = true;
        }
        if(moveHorizontal > 0 && rb.velocity.magnitude > 0)
        {
            sprite.flipX = false;
        }
    }

}
