using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public float health;
    public bool isDead;
    public AudioClip hurt;

    private AudioSource ac;

    void Start()
    {
        health = 100;
        isDead = false;
        ac = GetComponent<AudioSource>();
    }

    public void DamageCharacter(float damageAmount)
    {
        if(health <= 0)
        {
            isDead = true;
            GetComponent<Animator>().SetBool("dead", true);
        } else {
            health -= damageAmount;
            ac.PlayOneShot(hurt);
            DebugHealth();
        }
    }
    public void HealthPickup(float pickupValue)
    {
        health += pickupValue;
        DebugHealth();
    }

    void DebugHealth()
    {
        Debug.Log(gameObject.name + " " + health);
    }
}
