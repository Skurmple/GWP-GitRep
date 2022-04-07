using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anglerfish : MonoBehaviour
{
    public GameObject[] nodes = new GameObject[25];
    int i;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += (nodes[i].transform.position - transform.position).normalized * moveSpeed / 100;
        transform.right = -(nodes[i].transform.position - transform.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == nodes[i])
        {
            i++;
            if(nodes[i] == null)
            {
                i = 0;
            }
        }
    }
}
