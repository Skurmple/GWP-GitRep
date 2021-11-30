using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float wantedXPosition;
    GameObject drone;

    // Start is called before the first frame update
    void Start()
    {
        wantedXPosition = transform.position.x;
        drone = GameObject.Find("Drone");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = drone.transform.position;
        newPosition.x = wantedXPosition;
        transform.position = newPosition;
    }
}
