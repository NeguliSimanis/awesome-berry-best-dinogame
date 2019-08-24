using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    public float minX;
    public float maxX;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.transform.position;
    }


    void Update()
    {

        Vector3 cameraTransform = target.transform.position + offset;
        transform.position = new Vector3(Mathf.Clamp(cameraTransform.x, minX, maxX), cameraTransform.y, cameraTransform.z);


    }
}
