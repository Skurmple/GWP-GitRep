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
    bool reverseOrder;
    GameObject nextNode;

    // Start is called before the first frame update
    void Start()
    {
        nextNode = nodes[0];
        i = 0;
        reverseOrder = false;
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
        if(time >= 3.3f)
        {
            if (!reverseOrder)
            {
                switch (i)
                {
                    case 3:
                        i = 2;
                        reverseOrder = true;
                        break;
                    case 2:
                        i = 3;
                        break;
                    case 1:
                        i = 2;
                        break;
                    case 0:
                        i = 1;
                        break;
                }
            }
            else if (reverseOrder)
            {
                switch (i)
                {
                    case 0:
                        i = 1;
                        reverseOrder = false;
                        break;
                    case 1:
                        i = 0;
                        break;
                    case 2:
                        i = 1;
                        break;
                    case 3:
                        i = 2;
                        break;
                }
            }

            nextNode = nodes[i];
            time = 0;
        }
    }

    void BuildUp()
    {
        moveDirection = nextNode.transform.position - transform.position;
        moveSpeed = 0.01f;
        transform.position += moveSpeed * moveDirection.normalized;
    }

    void Dash()
    {
        moveSpeed = 0.4f;
        transform.position += moveSpeed * moveDirection.normalized;
    }
}
