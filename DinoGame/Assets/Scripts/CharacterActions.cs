using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    public string[] roars;

    void Update()
    {
        if (Input.GetButtonDown("Roar"))
        {
            int i = Random.Range(0, roars.Length);
            Debug.Log(roars[i]);
        }
    }
}
