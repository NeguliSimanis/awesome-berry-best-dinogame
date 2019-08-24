using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    public string[] roars;
    private CharacterHealth charHealth;

    private void Start()
    {
        charHealth = GetComponent<CharacterHealth>();
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
}
