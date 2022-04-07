using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    bool stopMoving;
    public bool reefDashed;
    public bool stuckInCoral = false;

    [Header("Radial Timer")]
    bool dissolvePlastic = false;
    float indicatorTimer = 10.0f;
    float maxIndicatorTimer = 1.0f;
    [SerializeField] private Image DissolveTimer = null;


    Vector3 pos;
    Quaternion targetRot = Quaternion.Euler(new Vector3(0, 0, 0));

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

        magnitude = Random.Range(0.3f, 1.5f);

        stopMoving = false;

        if (SceneManager.GetActiveScene().name == "Stage 2")
        {
            stopMoving = true;
        }

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
            if (pos.x > 20)
            {
                spawnRight = true;
            }
            else if (pos.x < -20)
            {
                spawnRight = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (reefDashed == true)
        {
            stuckInCoral = false;
            stopMoving = false;
            MoveBlown();
        }

        if (spawnTop == true && reefDashed == false)
        {
            if (stopMoving == false)
            {
                MoveDown();
            }
        }
        else
        {
            if (stopMoving == false && reefDashed == false)
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

        if (dissolvePlastic)
        {
            indicatorTimer -= Time.deltaTime;
            DissolveTimer.enabled = true;
            DissolveTimer.fillAmount = indicatorTimer / 10;

            if (indicatorTimer <= 5 && indicatorTimer > 2.5f)
            {
                DissolveTimer.color = new Color32(255, 105, 0, 150);
            }
            else if (indicatorTimer <= 2.5f && indicatorTimer > 0)
            {
                DissolveTimer.color = new Color32(255, 0, 0, 150);
            }
            else if (indicatorTimer <= 0)
            {
                Destroy(gameObject);
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
        pos += transform.up * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * magnitude;

        if (transform.position.y > GameObject.Find("Ocean Surface").transform.position.y)
        {
            reefDashed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CaveEntrance")
        {
            stopMoving = true;
        }

        if (collision.gameObject.tag == "Reef")
        {
            Invoke("TanglingInCoral", 0.5f);
        }

        if (collision.gameObject.name == "TrashShredder")
        {
            stopMoving = true;

            if (this.gameObject.tag == "PlasticTrash")
            {
                dissolvePlastic = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Reef")
        {
            CancelInvoke("TanglingInCoral");
        }
    }

    private void TanglingInCoral()
    {
        stopMoving = true;
        stuckInCoral = true;
    }
}
