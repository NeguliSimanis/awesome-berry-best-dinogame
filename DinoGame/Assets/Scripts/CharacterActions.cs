using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    public string[] roars;
    private CharacterHealth charHealth;
    private CharacterController controller;
    private GameController gc;

    private bool carryingItem;

    private void Start()
    {
        charHealth = GetComponent<CharacterHealth>();
        controller = GetComponent<CharacterController>();
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Roar"))
        {
            int i = Random.Range(0, roars.Length);
            Debug.Log(roars[i]);
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
        controller.SetSpeed(4);
    }

    void dropItem()
    {
        carryingItem = false;
        controller.ResetSpeed();
    }
}
