using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otter : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2f;

    [SerializeField]
    float frequency = 1f;

    [SerializeField]
    float magnitude = 3f;

    Vector3 pos;
    bool spawnRight;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Random.Range(1f, 2.5f);
        frequency = Random.Range(0.5f, 1.5f);
        magnitude = Random.Range(1f, 3.5f);

        pos = transform.position;

        CheckWhereSpawn();
    }

    private void CheckWhereSpawn()
    {
        if (pos.x > 10)
        {
            spawnRight = true;
        }
        else if (pos.x < -10)
        {
            spawnRight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnRight == true)
        {
            pos -= transform.right * Time.deltaTime * moveSpeed;
            transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;

            if (transform.position.y > GameObject.Find("Ocean Surface").transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, GameObject.Find("Ocean Surface").transform.position.y, transform.position.z);
            }
        }
        else
        {
            pos += transform.right * Time.deltaTime * moveSpeed;
            transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;

            if (transform.position.y > GameObject.Find("Ocean Surface").transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, GameObject.Find("Ocean Surface").transform.position.y, transform.position.z);
            }
        }
    }
}
