using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2f;

    [SerializeField]
    float frequency = 10f;

    [SerializeField]
    float magnitude = 0.5f;

    bool spawnRight;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

        CheckWhereSpawn();
    }

    private void CheckWhereSpawn()
    {
        if (pos.x > 10)
        {
            spawnRight = true;
        }
        else
        {
            spawnRight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnRight == true)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
    }

    private void MoveRight()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    private void MoveLeft()
    {
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
