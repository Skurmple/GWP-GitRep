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

    //*by Vojta
    GameObject lookForEmotions;
    protected Emotions EmotionsScript;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        mainCameraStartPos = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);

        //*by Vojta - Getting a reference to the emotions script
        lookForEmotions = GameObject.Find("Emotions_test");
        EmotionsScript = lookForEmotions.GetComponent<Emotions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!drone.enabled && isDisabled)
        {
            //*by Vojta
            EmotionsScript.StunnedFace();

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
