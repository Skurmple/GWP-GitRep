using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Vector2 dimesions, startPos;
    private Vector3 camStartPos;
    public GameObject cam;
    public float parallaxEffect;
    
    void Start()
    {
        startPos = transform.position;
        camStartPos = cam.transform.position;
        //dimesions = GetComponent<SpriteRenderer>().bounds.size;
        //startposX = transform.position.x;
        //startposY = transform.position.y;
        //length = GetComponent<SpriteRenderer>().bounds.size.x;
        //height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        Vector3 updatedCamPos = camStartPos - cam.transform.position;
        Vector2 dist = updatedCamPos * parallaxEffect;
        transform.position = new Vector3(startPos.x + dist.x, startPos.y + dist.y, transform.position.z);
    }
}
