using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    float wantedXPosition;
    public GameObject caveEntrance;
    GameObject drone;
    bool cameraLocked;
    public GameObject clamp;
    Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        wantedXPosition = transform.position.x;
        drone = GameObject.Find("Drone");
        if(SceneManager.GetActiveScene().name == "Stage 3")
        {
            clamp.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (clamp.activeInHierarchy)
        {
            Vector3 newPosition = drone.transform.position;
            newPosition.z = -10;
            newPosition.x = wantedXPosition;

            transform.position = newPosition;

            if (transform.position.y < clamp.transform.position.y)
            {
                transform.position = clamp.transform.position;
            }
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

        if (transform.position.y > startingPosition.y && SceneManager.GetActiveScene().name != "Stage 3")
        {
            transform.position = startingPosition;
        }
    }
}
