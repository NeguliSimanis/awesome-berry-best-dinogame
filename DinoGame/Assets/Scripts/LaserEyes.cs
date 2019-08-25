using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEyes : MonoBehaviour
{
    public Transform aimTarget;
    public LineRenderer lineRenderer;
    public GameObject explosionPrefab;
    private GameObject _explosionInstance;

    private Vector3 lastHitPosition;

    private bool spawnExplosion = true;

    public bool on = false;

    // Start is called before the first frame update
    void Start()
    {
        _explosionInstance = Instantiate(explosionPrefab);
        _explosionInstance.transform.position = new Vector3(-50, -50, -50);
    }

    // Update is called once per frame
    void Update()
    {
        if (!on)
            return;

        var wasHit = Physics2D.Raycast(transform.position, aimTarget.position - transform.position);

        Debug.Log("test");
        if (wasHit)
        {
            if(spawnExplosion)
                StartCoroutine("SpawnExplosion");
            lastHitPosition = wasHit.point;
            if (wasHit.transform.tag == "Enemy")
                DestroyImmediate(wasHit.transform.gameObject);

            lineRenderer.SetPositions(new[] { transform.position, new Vector3(wasHit.point.x, wasHit.point.y) });

        }
    }

    IEnumerator SpawnExplosion()
    {
        spawnExplosion = false;

        _explosionInstance.transform.position = lastHitPosition;
        yield return new WaitForSeconds(0.1f);
        spawnExplosion = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(new Ray(transform.position, (aimTarget.position - transform.position)));
    }
}
