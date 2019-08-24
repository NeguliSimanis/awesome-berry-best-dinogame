using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject debrisPrefab = null;
    [SerializeField]
    private GameObject healthPickupPrefab;
    [SerializeField]
    private GameObject suppliesPickupPrefab;
    [SerializeField, Tooltip("Max spawned items on map")]
    private int maxItemCount = 5;
    [SerializeField, Tooltip("Timer between spawns")]
    private float timer;
    [SerializeField, Tooltip("Powerup spawn rate")]
    private int chance = 6;
    private int childCount;
    private GameObject obj;
    private GameObject spawnableObj;
    private float xRandom;

    void Update()
    {
        CreateItem();
    }

    private void CreateItem()
    {
        //starts timer for spawn
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            //gets child count for spawner
            childCount = this.gameObject.transform.childCount;
            if (childCount < maxItemCount)
            {
                //randomly selects debris or pickup
                xRandom = Random.Range(0, 10);
                if (xRandom < chance)
                    spawnableObj = debrisPrefab;
                else
                {
                    if (Random.Range(0, 10) > 8)
                        spawnableObj = healthPickupPrefab;
                    else
                        spawnableObj = suppliesPickupPrefab;
                }
                    

                //instantiates and resets timer
                xRandom = Random.Range(-10.0f, 10.0f);
                obj = Instantiate(spawnableObj, new Vector3(xRandom, 15f, 0), Quaternion.identity);
                obj.transform.parent = this.gameObject.transform;
                timer = 3f;
            }
        }
        
           
    }
}
