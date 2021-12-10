using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
    float wantedXPosition;
    public GameObject caveEntrance;
    GameObject drone;
    bool cameraLocked;
    GameObject clamp;
    Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        wantedXPosition = transform.position.x;
        drone = GameObject.Find("Drone");
        clamp = GameObject.Find("Drone Clamp");
    }

    // Update is called once per frame
    void Update()
    {
        if (clamp.activeInHierarchy)
        {
            transform.position = startingPosition;
        }   
        else
        {
            Vector3 newPosition = drone.transform.position;
            newPosition.z = -10;

            if (transform.position.y > caveEntrance.transform.position.y)
            {
                newPosition.x = wantedXPosition;
            }

            transform.position = newPosition;
        }

        if (transform.position.y > startingPosition.y)
        {
            transform.position = startingPosition;
        }
    }
}
