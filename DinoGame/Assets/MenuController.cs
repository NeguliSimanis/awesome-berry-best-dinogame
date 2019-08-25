using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    public void onPlay()
    {
        SceneManager.LoadScene("Intro");
    }
    public void onCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void onExit()
    {
        Application.Quit();
    }
}
