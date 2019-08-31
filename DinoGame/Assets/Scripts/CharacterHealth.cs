using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{
    public float health;
    public bool isDead;
    public AudioClip hurt;
    public AudioClip wow;
    public GameObject roarText;

    private AudioSource ac;

    void Start()
    {
        health = 80;
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
        //ac.PlayOneShot(wow);
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("GameOver_Bad");
    }

}
