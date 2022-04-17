using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public DroneMovement drone;
    public bool isDisabled;

    float phoneOpen;
    public GameObject phone;

    //*by Vojta
    GameObject lookForEmotions;
    protected Emotions EmotionsScript;

    // Start is called before the first frame update
    void Start()
    {
        //*by Vojta - Getting a reference to the emotions script
        lookForEmotions = GameObject.Find("DroneEmotions");
        EmotionsScript = lookForEmotions.GetComponent<Emotions>();

        phoneOpen = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitToMenu();
        }

        if (!drone.enabled && isDisabled)
        {
            //*by Vojta
            EmotionsScript.StunnedFace();

            StartCoroutine(RestartDrone());
            isDisabled = false; 
        }

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            if (phoneOpen == 1)
            {
                phone.transform.localPosition = new Vector3(phone.transform.localPosition.x - 130, phone.transform.localPosition.y, phone.transform.localPosition.z);
                phoneOpen *= -1;
            }
            else if (phoneOpen == -1)
            {
                phone.transform.localPosition = new Vector3(phone.transform.localPosition.x + 130, phone.transform.localPosition.y, phone.transform.localPosition.z);
                phoneOpen *= -1;
            }
        }

    }

    public IEnumerator RestartDrone()
    {
        yield return new WaitForSeconds(2.3f);
        drone.enabled = true;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
