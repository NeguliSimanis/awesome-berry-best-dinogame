using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public float _health;
    public bool isDead;

    private float health;

    void Start()
    {
        health = _health;
        isDead = false;
    }

    public void DamageCharacter(float damageAmount)
    {
        if(health <= 0)
        {
            isDead = true;
        } else {
            health -= damageAmount;
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
