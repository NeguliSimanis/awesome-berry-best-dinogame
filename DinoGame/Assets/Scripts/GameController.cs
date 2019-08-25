using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float score;
    [SerializeField]
    private bool skip = false;

    public void Update()
    {
        if (skip == true)
            SceneManager.LoadScene("GameOver_Good");
        if (score >= 9)
            FindObjectOfType<LaserEyes>().on = true;
    }
    public void increaseScore()
    {
        score++;
        Debug.Log("Score: " + score);
        if(score>=10)
            SceneManager.LoadScene("GameOver_Good");
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
