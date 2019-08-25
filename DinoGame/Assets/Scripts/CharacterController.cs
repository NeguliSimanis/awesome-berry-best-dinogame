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
    private CharacterHealth characterHealth;
    private Animator anim;

    void Start()
    {
        speed = _speed;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        characterHealth = GetComponent<CharacterHealth>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (!characterHealth.isDead)
        {
            MovePlayer();
        }
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
        if(moveHorizontal != 0)
        {
            anim.SetBool("moving", true);
        } else {
            anim.SetBool("moving", false);
        }

        //kinda messy, should refactor it later
        if (moveHorizontal < 0 && rb.velocity.magnitude > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        if(moveHorizontal > 0 && rb.velocity.magnitude > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

}
