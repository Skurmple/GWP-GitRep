using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Vector2 dimesions, startpos;
    public GameObject cam;
    public float parallaxEffect;
    
    void Start()
    {
        startpos = transform.position;
        dimesions = GetComponent<SpriteRenderer>().bounds.size;
        //startposX = transform.position.x;
        //startposY = transform.position.y;
        //length = GetComponent<SpriteRenderer>().bounds.size.x;
        //height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        Vector2 dist = cam.transform.position * parallaxEffect;
        transform.position = new Vector3(startpos.x + dist.x, startpos.y + dist.y, transform.position.z);
    }
}
