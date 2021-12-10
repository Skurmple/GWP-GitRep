using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pufferfish : MonoBehaviour
{
    public GameObject[] waypoints;
    public SpriteRenderer sr;
    public Sprite[] sps;

    int current;
    float rotationSpeed;
    public float speed;
    float radius = .5f;
    bool shrink;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (transform.localScale.x > 1 && shrink)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.01f, transform.localScale.y - 0.01f, transform.localScale.z - 0.01f);
        }

        Pathfinding();
    }

    void Pathfinding()
    {
        if (Vector2.Distance(waypoints[current].transform.position, transform.position) < radius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            sr.sprite = sps[1];
        }
    }

    //When the player is near then it expands
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (transform.localScale.x < 3)
            {
                shrink = false;
                transform.localScale = new Vector3(transform.localScale.x + 0.01f, transform.localScale.y + 0.01f, transform.localScale.z + 0.01f);
                speed = 4;
            }
        }
    }

    //When the player isnt near then it deflates 
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            shrink = true;
            sr.sprite = sps[0];
            speed = 6;
        }
    }

}
