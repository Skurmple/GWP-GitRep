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

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;


        if (transform.position.x < GameObject.Find("Net Blocker Left").transform.position.x - 10)
        {
            transform.Rotate(0, 180, 0);
        }

        if (transform.position.x > GameObject.Find("Net Blocker Right").transform.position.x + 10)
        {
            transform.Rotate(0, 180, 0);
        }

    }
}
