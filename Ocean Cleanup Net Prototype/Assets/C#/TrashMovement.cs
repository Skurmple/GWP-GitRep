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
                pos.x += Random.Range(-2, 3);
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
                Debug.Log("HitUp");
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
