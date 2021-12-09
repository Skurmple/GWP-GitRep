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
    bool spawnTop;
    bool rotateToZero;
    bool stopMoving;

    Vector3 pos;
    Quaternion targetRot = Quaternion.Euler(new Vector3(0, 0, 0));

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

        stopMoving = false;

        magnitude = Random.Range(0.3f, 1.5f);

        CheckWhereSpawn();
    }

    private void CheckWhereSpawn()
    {
        if (pos.y > -1)
        {
            spawnTop = true;
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
        if (spawnTop == true)
        {
            if (stopMoving == false)
            {
                MoveDown();
            }
        }
        else
        {
            if (stopMoving == false)
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

        if (collision.gameObject.name == "Rock_ss")
        {
            stopMoving = true;
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
