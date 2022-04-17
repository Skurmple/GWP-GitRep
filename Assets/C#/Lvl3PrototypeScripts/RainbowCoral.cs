using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowCoral : MonoBehaviour
{
    float moveSpeed = 2f;
    Vector3 pos;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        velocity = new Vector3(1, 1.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        pos.y -= velocity.y * Time.deltaTime * moveSpeed;
        pos.x += velocity.x * Time.deltaTime * moveSpeed;
        transform.position = pos;

        if (transform.position.y > GameObject.Find("Ocean Surface").transform.position.y)
        {
            velocity.y *= -1;
        }

        if (transform.position.y < GameObject.Find("Drone Clamp").transform.position.y)
        {
            velocity.y *= -1;
        }

        if (transform.position.x < GameObject.Find("Net Blocker Left").transform.position.x)
        {
            velocity.x *= -1;
        }

        if (transform.position.x > GameObject.Find("Net Blocker Right").transform.position.x)
        {
            velocity.x *= -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Environment")
        {
            velocity.y *= -1;
            velocity.y += Random.Range(-0.5f, 0.6f);

            velocity.x *= -1;
            velocity.x += Random.Range(-0.5f, 0.6f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Environment")
        {
            Debug.Log("Collided");
            velocity = Vector3.Reflect(velocity, collision.contacts[0].normal);
        }
    }
}
