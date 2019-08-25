using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroText : MonoBehaviour
{
    Text txt;
    public string[] story;
    string selected;
    bool done;
    int i;
    public Animator dino;
    public GameObject anykey;
    public AudioSource ac;
    public AudioClip confirm;

    void Awake()
    {
        i = 0;
        txt = GetComponent<Text>();
        selected = story[i];
        done = false;

        StartCoroutine("PlayText");
    }

    IEnumerator PlayText()
    {
        dino.SetBool("speaking", true);
        txt.text = "";
        anykey.SetActive(false);
        done = false;
        ac.volume = 0.6f;
        foreach (char c in selected)
        {
            txt.text += c;
            yield return new WaitForSeconds(0.055f);
        }
        Debug.Log("done");
        done = true;
        ac.volume = 0;
        anykey.SetActive(true);
        dino.SetBool("speaking", false);
    }

    private void Update()
    {
        if (done)
        {
            if (Input.anyKey)
            {
                i++;
                if(i == 8)
                {
                    LoadLevel();
                } else {
                    ac.PlayOneShot(confirm, 1);
                    selected = story[i];
                    StartCoroutine("PlayText");
                }
            }
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Other");
    }
}
