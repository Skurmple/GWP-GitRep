using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public DroneMovement drone;
    public bool isDisabled;
    float time;
    public SwordFish swordfish;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 10)
        {
            Instantiate(swordfish, new Vector3(1, -24, 0), swordfish.transform.rotation);
            time = 0;
        }


        if (!drone.enabled && isDisabled)
        {
            StartCoroutine(RestartDrone());
            isDisabled = false; 
        }
    }

    public IEnumerator RestartDrone()
    {
        yield return new WaitForSeconds(2.3f);
        drone.enabled = true;
    }
}
