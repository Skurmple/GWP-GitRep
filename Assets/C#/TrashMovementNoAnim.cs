using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrashMovementNoAnim : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2f;

    [SerializeField]
    float originalMoveSpeed;

    [SerializeField]
    float frequency = 10f;

    [SerializeField]
    float magnitude = 0.5f;

    bool stopMoving;
    public bool netFall;
    public bool dislodged = true;
    public bool reefDashed;
    public bool stuckInCoral = false;

    Vector3 pos;
    Quaternion targetRot = Quaternion.Euler(new Vector3(0, 0, 0));

    void Start()
    {
        pos = transform.position;

        magnitude = Random.Range(0.3f, 1.5f);

        stopMoving = false;

        if (netFall)
        {
            moveSpeed = originalMoveSpeed;
        }
        else
        {
            originalMoveSpeed = moveSpeed;
        }

        if (SceneManager.GetActiveScene().name == "Stage 2" && !netFall)
        {
            stopMoving = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (reefDashed == true)
        {
            if (dislodged)
            {
                moveSpeed *= 2;
                pos.x += Random.Range(-3, 4);
                dislodged = false;
            }
            stopMoving = false;
            MoveBlown();
        }

        if (reefDashed == false)
        {
            if (stopMoving == false)
            {
                MoveDown();
            }
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

    private void MoveBlown()
    {
        Invoke("Dislodged", 1);

        pos += transform.up * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * magnitude;

        if (transform.position.y > GameObject.Find("Ocean Surface").transform.position.y)
        {
            reefDashed = false;
            moveSpeed = originalMoveSpeed;
            dislodged = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boulders")
        {
            if (reefDashed)
            {
                reefDashed = false;
                moveSpeed = originalMoveSpeed;
                dislodged = true;
            }
            else
            {
                stopMoving = true;
            }
        }

        if (collision.gameObject.tag == "Reef")
        {
            Invoke("TanglingInCoral", 0.5f);
        }

        if (collision.gameObject.name == "TrashShredder")
        {
            stopMoving = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Reef")
        {
            CancelInvoke("TanglingInCoral");
        }
    }

    private void Dislodged()
    {
        stuckInCoral = false;
    }

    private void TanglingInCoral()
    {
        stuckInCoral = true;
        stopMoving = true;
    }
}
