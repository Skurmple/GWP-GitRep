using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pufferfish : MonoBehaviour
{
    public GameObject[] waypoints;

    int current;
    float rotationSpeed;
    public float speed;
    float radius = .5f;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
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



    //When the player is near then it expands
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            speed = 6;
            animator.SetBool("Expand", true);
            animator.SetBool("StayExpanded", true);
        }
    }

    //When the player isnt near then it deflates 
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            speed = 10;
            animator.SetBool("Expand", false);
            animator.SetBool("StayExpanded", false);
        }
    }

}
