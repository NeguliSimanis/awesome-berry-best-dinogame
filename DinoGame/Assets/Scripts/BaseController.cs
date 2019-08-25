using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseController : MonoBehaviour
{
    [SerializeField, Tooltip("Base default health")]
    private int baseHealth = 100;
    [SerializeField, Tooltip("unit count")]
    private int unitCount = 10;
    [SerializeField, Tooltip("spawn rate")]
    private float spawnRate = 5f;
    [SerializeField]
    private GameObject enemyPrefab;
    private int currentCount;
    private GameObject obj;
    private float xRandom;
    public int points;
    private Text scoreText;
    [SerializeField]
    private bool skip = false;

    private void Start()
    {
        //scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    public  void Update()
    {
        SpawnUnits();
        if (skip == true)
            SceneManager.LoadScene("GameOver_Bad");
    }

    public void SpawnUnits()
    {
        spawnRate -= Time.deltaTime;
        
        if(spawnRate<=0)
        {
            currentCount = this.gameObject.transform.childCount;
            if (currentCount<unitCount)
            {
                xRandom = Random.Range(-15.0f, -12.0f);
                obj = Instantiate(enemyPrefab, this.gameObject.transform.position, Quaternion.identity);
                obj.transform.position = transform.position;
                obj.transform.parent = this.gameObject.transform;
                spawnRate = 5f;
                Debug.Log(transform.position);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && collision.GetComponentInChildren<EnemyAI>().hasCrate == true)
        {
            Destroy(collision.gameObject);
            points++;
            //scoreText.text = points.ToString();
            if(points >=10)
                SceneManager.LoadScene("GameOver_Bad");

        }
            
    }
}
