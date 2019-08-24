﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = gameObject.GetComponentInChildren<Rigidbody2D>();
    }
    private void Update()
    {
        if (this.transform.position.y < -20f)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player" && this.gameObject.tag=="Debris")
        {
            collision.gameObject.GetComponentInChildren<CharacterHealth>()._health -= 10;
            Destroy(this.gameObject);
        }

        if(collision.tag == "Environment" && this.gameObject.tag == "Debris")
        {
            //animation or crashed debris TODO
            Destroy(this.gameObject);
        }
        if (collision.tag == "Environment" && this.gameObject.tag == "HealthPickup")
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (collision.tag == "Environment" && this.gameObject.tag == "PointsPickup")
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (collision.tag == "Enemy" && this.gameObject.tag == "PointsPickup")
        {
            rb.isKinematic=true;
            this.transform.parent = collision.transform;
            collision.GetComponentInChildren<EnemyAI>().hasCrate = true;
            this.tag = "Empty";
        }
    }

    public void Dropped()
    {
        transform.tag = "PointsPickup";
        transform.parent = null;
        rb.isKinematic = false;
    }

}
