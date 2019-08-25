using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource ac;

    public AudioClip meteorImpact;
    public AudioClip crateImpact;
    public GameObject explosion;
    
    private void Start()
    {
        rb = gameObject.GetComponentInChildren<Rigidbody2D>();
        ac = GetComponent<AudioSource>();
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
            collision.gameObject.GetComponentInChildren<CharacterHealth>().DamageCharacter(35);
            Instantiate(explosion, transform.position, transform.rotation);
            StartCoroutine("DestroyObject");
        }

        if(collision.tag == "Environment" && this.gameObject.tag == "Debris")
        {
            Instantiate(explosion, gameObject.transform);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine("DestroyObject");
        }
        if (collision.tag == "Environment" && this.gameObject.tag == "HealthPickup")
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            ac.PlayOneShot(crateImpact);
        }
        if (collision.tag == "Environment" && this.gameObject.tag == "PointsPickup")
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            ac.PlayOneShot(crateImpact);
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

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.55f);
        StopCoroutine(DestroyObject());
        Destroy(gameObject);
    }

}
