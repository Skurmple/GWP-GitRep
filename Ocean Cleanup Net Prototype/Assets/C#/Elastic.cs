using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elastic : MonoBehaviour
{
    public GameObject drone;
    public GameObject net;
    public Vector3 elasticSize;
    Vector2 elasticRotation;

    // Start is called before the first frame update
    void Start()
    {
        drone = GameObject.Find("Drone");
        net = GameObject.Find("Net");
    }

    // Update is called once per frame
    void Update()
    {
        elasticSize = drone.transform.position - net.transform.position;
        elasticRotation = elasticSize.normalized;
        transform.localScale = new Vector2(0.1f, elasticSize.magnitude);
        transform.up = elasticRotation;
        transform.position = net.transform.position + (elasticSize / 2);

        
    }
}
