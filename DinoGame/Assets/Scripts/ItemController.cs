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
    public Transform explosionLocation;

    public GameObject flyingCrate;
    public GameObject layingCrate;
    
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
            InstantiateExplosion();
            DestroyObjectImmediately();
        }

        if(collision.tag == "Environment" && this.gameObject.tag == "Debris")
        {
            InstantiateExplosion();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            DestroyObjectImmediately();
        }
        if (collision.tag == "Environment" && this.gameObject.tag == "HealthPickup")
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            flyingCrate.SetActive(false);
            layingCrate.SetActive(true);
            ac.PlayOneShot(crateImpact);
        }
        if (collision.tag == "Environment" && this.gameObject.tag == "PointsPickup")
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            flyingCrate.SetActive(false);
            layingCrate.SetActive(true);
            ac.PlayOneShot(crateImpact);
        }
        if (collision.tag == "Enemy" && this.gameObject.tag == "PointsPickup")
        {
            rb.isKinematic=true;
            flyingCrate.SetActive(false);
            layingCrate.SetActive(true);
            this.transform.parent = collision.transform;
            collision.GetComponentInChildren<EnemyAI>().hasCrate = true;
            transform.Translate(-2, 0, 0);
            this.tag = "Empty";
        }
    }

    private void InstantiateExplosion()
    {
        GameObject newExplosion = Instantiate(explosion);//, explosionLocation.position, explosionLocation.rotation);
        newExplosion.transform.position = explosionLocation.position;
        newExplosion.transform.parent = null;
    }

    public void Dropped()
    {
        transform.tag = "PointsPickup";
        transform.parent = null;
        rb.isKinematic = false;
    }

    private void DestroyObjectImmediately()
    {
        Destroy(gameObject);
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.55f);
        StopCoroutine(DestroyObject());
        Destroy(gameObject);
    }

}
