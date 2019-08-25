using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns clouds when dinosaur puts foot on the ground
/// </summary>
public class DinosaurClouds : MonoBehaviour
{
    [SerializeField]
    GameObject smokeCloud;
    [SerializeField]
    Transform smokeCloudLocation;
    //[SerializeField]
    //GameObject dino;

    /// <summary>
    /// this is called from animation
    /// </summary>
    public void InstantiateSmokeCloud()
    {
        GameObject newSmokeCloud = Instantiate(smokeCloud);//, explosionLocation.position, explosionLocation.rotation);
        newSmokeCloud.transform.position = smokeCloudLocation.position;

        if (transform.rotation.y == -1)
        {
            newSmokeCloud.transform.localScale = new Vector3(-1f,1,0);
        }
        newSmokeCloud.transform.parent = null;
    }
}
