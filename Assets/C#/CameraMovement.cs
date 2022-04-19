using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    float wantedXPosition;
    GameObject drone;
    bool cameraLocked;
    Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        wantedXPosition = transform.position.x;
        drone = GameObject.Find("Drone");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = drone.transform.position;
        newPosition.z = -10;

        if (SceneManager.GetActiveScene().name != "Stage 3")
        {
            newPosition.x = wantedXPosition;
        }

        transform.position = newPosition;

        if (transform.position.y > startingPosition.y && SceneManager.GetActiveScene().name != "Stage 3")
        {
            transform.position = startingPosition;
        }
    }
}
