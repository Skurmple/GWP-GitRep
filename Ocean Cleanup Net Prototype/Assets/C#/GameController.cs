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

    public bool cameraDisabled = true;
    bool oneTime = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("CM StateDrivenCamera1");
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
            mainCamera.SetActive(false);
            oneTime = true;
        }
        else if (cameraDisabled == false)
        {
            drone.droneClamp.SetActive(false);
            mainCamera.SetActive(true);
            oneTime = false;
        }
    }

    public IEnumerator RestartDrone()
    {
        yield return new WaitForSeconds(2.3f);
        drone.enabled = true;
    }
}
