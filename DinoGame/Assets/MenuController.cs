using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject instructions;

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

    public void onHowTo()
    {
        instructions.SetActive(true);
    }

    public void BackToMenu()
    {
        instructions.SetActive(false);
    }
}
