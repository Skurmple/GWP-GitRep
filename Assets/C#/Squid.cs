using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squid : MonoBehaviour
{
    public GameObject[] nodes;
    float moveSpeed;
    Vector3 moveDirection;
    float time;
    int i;
    GameObject nextNode;

    // Start is called before the first frame update
    void Start()
    {
        nextNode = nodes[0];
        i = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time < 3)
        {
            BuildUp();
        }
        else if(time >= 3)
        {
            Dash();
        }
    }

    void BuildUp()
    {
        moveDirection = nextNode.transform.position - transform.position;
        moveSpeed = 0.01f;
        transform.position += moveSpeed * moveDirection.normalized;
        transform.right = -moveDirection.normalized;
    }

    void Dash()
    {
        moveSpeed = 0.4f;
        transform.position += moveSpeed * moveDirection.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == nodes[i])
        {
            i++;
            if (nodes[i] == null)
            {
                i = 0;
            }
            nextNode = nodes[i];
            time = 0;
        }
    }
}
