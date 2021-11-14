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
    bool spawnByBoat;
    bool rotateToZero;

    Vector3 pos;
    Quaternion targetRot = Quaternion.Euler(new Vector3(0, 0, 0));

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

        CheckWhereSpawn();
    }

    private void CheckWhereSpawn()
    {
        if (pos.y > 0)
        {
            spawnByBoat = true;
        }
        else
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
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnByBoat == true)
        {
            MoveDown();
        }
        else
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

        if (rotateToZero == true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, Time.time * 0.05f);
        }
    }

    private void MoveDown()
    {
        pos -= transform.up * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * magnitude;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Surface" || collision.gameObject.name == "Floor")
        {
            rotateToZero = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Surface")
        {
            rotateToZero = false;
        }
    }
}
