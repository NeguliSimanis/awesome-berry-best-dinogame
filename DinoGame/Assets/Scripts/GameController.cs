using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float score;
    
    public void increaseScore()
    {
        score++;
        Debug.Log("Score: " + score);
    }

}
