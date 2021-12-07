using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public DroneMovement drone;
    public bool isDisabled;
    float time;
    public SwordFish swordfish;

    GameObject mainCamera;
    Vector3 mainCameraStartPos;

    public bool cameraDisabled = true;
    bool oneTime = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        mainCameraStartPos = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 30)
        {
            Instantiate(swordfish, new Vector3(1, -24, 0), swordfish.transform.rotation);
            time = 0;
        }

        if (!drone.enabled && isDisabled)
        {
            StartCoroutine(RestartDrone());
            isDisabled = false; 
        }

        if (cameraDisabled == true && oneTime == false)
        {
            drone.ResetPosition();
            mainCamera.transform.position = mainCameraStartPos;
            oneTime = true;
        }
        
    }

    public IEnumerator RestartDrone()
    {
        yield return new WaitForSeconds(2.3f);
        drone.enabled = true;
    }
}
