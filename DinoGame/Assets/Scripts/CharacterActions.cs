using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    public string[] roars;
    private CharacterHealth charHealth;
    private CharacterController controller;
    private GameController gc;
    private Animator anim;

    private bool carryingItem;

    public GameObject body;
    public GameObject[] hands;

    public Sprite defaultBody;
    public Sprite carryingBody;

    public GameObject roarText;

    private void Start()
    {
        charHealth = GetComponent<CharacterHealth>();
        controller = GetComponent<CharacterController>();
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Roar"))
        {
            int i = Random.Range(0, roars.Length);
            Debug.Log(roars[i]);
            anim.SetBool("roar", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            charHealth.DamageCharacter(25);
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            charHealth.HealthPickup(25);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "HealthPickup")
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !carryingItem)
            {
                Debug.Log("Picking up item");
                pickupItem();
                Destroy(collision.gameObject);
            }
        }
        if(collision.tag == "FriendlyStructure" && carryingItem)
        {
            dropItem();
            gc.increaseScore();
        }
    }

    void pickupItem()
    {
        carryingItem = true;
        body.GetComponent<SpriteRenderer>().sprite = carryingBody;
        SetHands(false);
        controller.SetSpeed(4);
    }

    void dropItem()
    {
        carryingItem = false;
        body.GetComponent<SpriteRenderer>().sprite = defaultBody;
        SetHands(true);
        controller.ResetSpeed();
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
    }
}
