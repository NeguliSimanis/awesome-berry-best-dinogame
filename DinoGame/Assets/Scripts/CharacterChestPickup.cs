using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChestPickup : MonoBehaviour
{

    private GameController gc;

    [SerializeField]
    CharacterActions characterActions;

    private void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PointsPickup")
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !characterActions.carryingItem)
            {
                Debug.Log("Picking up item");
                characterActions.pickupItem();
                Destroy(collision.gameObject);
            }
        }
        if (collision.tag == "FriendlyStructure" && characterActions.carryingItem)
        {
            characterActions.dropItem();
            gc.increaseScore();
        }
    }
}
