using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otter : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2f;

    [SerializeField]
    float frequency = 10f;

    [SerializeField]
    float magnitude = 0.5f;

    Vector3 pos;
    bool spawnRight;

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
        }
        else
        {
            pos += transform.right * Time.deltaTime * moveSpeed;
            transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
        }
    }
}
