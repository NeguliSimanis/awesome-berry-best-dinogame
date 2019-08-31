using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    private CharacterHealth charHealth;
    private CharacterController controller;
    private GameController gc;
    private Animator anim;
    private AudioSource ac;

    public bool carryingItem;
    public bool canRoar;

    public GameObject body;
    public GameObject[] hands;

    public Sprite defaultBody;
    public Sprite carryingBody;

    public GameObject roarText;
    public AudioClip stomp;
    public AudioClip roar;
    public AudioClip pickup;
    public AudioClip score;

    private void Start()
    {
        charHealth = GetComponent<CharacterHealth>();
        controller = GetComponent<CharacterController>();
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        anim = GetComponent<Animator>();
        ac = GetComponent<AudioSource>();
        canRoar = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Roar") && canRoar)
        {
            Roar();
            StartCoroutine("RoarReset");
        }
       /* if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            charHealth.DamageCharacter(25);
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            charHealth.HealthPickup(25);
        }*/
    }

    public void pickupItem()
    {
        carryingItem = true;
        body.GetComponent<SpriteRenderer>().sprite = carryingBody;
        SetHands(false);
        ac.PlayOneShot(pickup);
    }

    public void dropItem()
    {
        carryingItem = false;
        body.GetComponent<SpriteRenderer>().sprite = defaultBody;
        SetHands(true);
        ac.PlayOneShot(score);
    }

    void SetHands(bool value)
    {
        for (int i = 0; i < hands.Length; i++)
        {
            hands[i].SetActive(value);
        }
    }

    void DisableRoar()
    {
        anim.SetBool("roar", false);
    }
    void DisableRoarText()
    {
        roarText.SetActive(false);
    }

    void EnableRoarText()
    {
        if(transform.rotation.y == 180)
        {
            roarText.transform.rotation = Quaternion.Euler(0, 180f, 0);
        } else {
            roarText.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        roarText.SetActive(true);
        ac.PlayOneShot(roar);
    }

    public void Stomp()
    {
        ac.PlayOneShot(stomp, Random.Range(0.5f, 1));
    }

    public void Roar()
    {
        canRoar = false;
        anim.SetBool("roar", true);
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 10);
        for(int i = 0; i < hitColliders.Length; i++)
        {
            if(hitColliders[i].gameObject.tag == "Enemy")
            {
                Debug.Log(hitColliders[i].gameObject.name);
                EnemyAI foundEnemy = hitColliders[i].gameObject.GetComponent<EnemyAI>();
                foundEnemy.isFleeing = true;
                foundEnemy.StartScream();
            }
        }
    }

    IEnumerator RoarReset()
    {
        yield return new WaitForSeconds(3f);
        canRoar = true;
    }
}
