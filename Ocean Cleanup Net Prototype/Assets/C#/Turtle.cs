using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    GameObject net;

    // Start is called before the first frame update
    void Start()
    {
        net = GameObject.Find("Net");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToNetVector = net.transform.position - transform.position;
        float distanceToNet = distanceToNetVector.magnitude;

        if(distanceToNet < 3)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.4f, 0);
        }
    }
}
