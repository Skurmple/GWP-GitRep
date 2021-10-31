using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    public TrashNet netChild;

    Vector2 mousePosition;
    Vector3 forwardVector;
    Vector3 localScale = new Vector3(0.25f, 0.25f, 0.25f);
    public float moveSpeed = 7;
    public float speedReduction = 0.8f;

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = Vector3.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

        forwardVector = (new Vector3(mousePosition.x, mousePosition.y, 0) - transform.position);
        forwardVector.Normalize();
        transform.right = forwardVector;

        CheckFacing();
    }
    private void CheckFacing()
    {
        if ((forwardVector.x < 0 && localScale.y > 0) || (forwardVector.x > 0 && localScale.y < 0))
        {
            localScale.y *= -1;
        }
        if (forwardVector.x == 0)
        {
            localScale.y = 0.25f;
        }

        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boat")
        {
            netChild.onBoat = true;
        }

        if (collision.gameObject.tag == "Fish")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x * -1, Random.Range(-1, 1));
            collision.gameObject.transform.Rotate(new Vector2(0, 180));
            netChild.score--;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boat")
        {
            netChild.onBoat = false;
        }
    }
    public void UpgradeNetSpeed()
    {
        moveSpeed += 2;
        speedReduction += 0.05f;
    }
}
