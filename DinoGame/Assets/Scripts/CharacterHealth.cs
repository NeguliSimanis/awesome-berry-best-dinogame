using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public float health;
    public bool isDead;
    public AudioClip hurt;
    public GameObject roarText;

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
            GetComponent<CharacterActions>().canRoar = false;
            roarText.SetActive(false);
            StartCoroutine(EndEx());
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

    IEnumerator EndEx()
    {
        // wait for 1 second
        yield return new WaitForSeconds(3.0f);
        GameObject.Find("GameController").SendMessage("RestartGame");
    }
}
