using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject[] crates = new GameObject[0];
    private GameObject closestCrate;
    private GameObject baseObject;
    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField]
    private float speed =0f;
    public bool hasCrate = false;
    private float timer = 2f;
    public bool called = false;
    public bool isFleeing = false;
    public Animator anim;

    public SpriteRenderer body;

    public Sprite defaultBody;
    public Sprite spookedBody;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        baseObject = GameObject.Find("HumanBase");
        player = GameObject.Find("Dinosaur");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        crates = GameObject.FindGameObjectsWithTag("PointsPickup");
        if (hasCrate == false)
        {
            moveToCrate();
            anim.SetBool("dragging", false);
        }
        else if (hasCrate == true)
        {
            moveToBase();
            anim.SetBool("dragging", true);
        }
        if (this.transform.position.y < -20f)
            Destroy(this.gameObject);

        if (isFleeing == true)
            Flee();
        if(rb.velocity.magnitude <= 0)
        {
            anim.SetBool("walking", false);
        } else {
            anim.SetBool("walking", true);
        }
    }

    public void moveToCrate()
    {
        float distance = Mathf.Infinity;
        foreach (var c in crates)
        {
            Vector3 diff = c.transform.position - transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closestCrate = c;
                distance = curDistance;
            }
        }
        Vector2 heading = Vector2.zero;
        if (closestCrate!=null)
            heading = closestCrate.transform.position - transform.position;
        //rb.AddForce(new Vector2(heading.x + 5,0) * speed);
        rb.AddForce(heading.normalized*speed);
    }
    public void moveToBase()
    {
        var heading = baseObject.transform.position - transform.position;
        rb.AddForce(heading.normalized * speed);
    }

    public void Flee()
    {
        body.sprite = spookedBody;
        gameObject.layer = 9; //LAYER!!! 
        if(hasCrate)
            GetComponentInChildren<ItemController>().Dropped();
        Vector2 heading = baseObject.transform.position - transform.position;
        //Debug.Log(heading);
        if(called==false)
        {
            rb.velocity = Vector2.zero;
            called = true;
        }
        
        rb.AddForce(heading.normalized * speed*2);
        Debug.Log(heading.normalized);
        hasCrate = false;
        timer -= Time.deltaTime;
        if(timer <=0)
        {
            body.sprite = defaultBody;
            isFleeing = false;
            gameObject.layer = 8; //LAYER!!! 
            timer = 2f;
            called = false;

        }
            
    }
}
