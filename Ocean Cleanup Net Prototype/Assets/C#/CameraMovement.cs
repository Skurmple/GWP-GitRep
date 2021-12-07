using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float wantedXPosition;
    public GameObject caveEntrance;
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
        if(this.gameObject.name != "Zoomed Out" && transform.position.y > caveEntrance.transform.position.y)
        {
            Vector3 newPosition = drone.transform.position;
            newPosition.x = wantedXPosition;
            transform.position = newPosition;
        }

        if(this.gameObject.name == "Zoomed Out" && transform.position.y > caveEntrance.transform.position.y)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = wantedXPosition;
            transform.position = newPosition;
        }
    }
}
