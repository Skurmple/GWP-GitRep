using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public DroneMovement drone;
    public bool isDisabled;

    float phoneOpen;
    public GameObject phone;

    [SerializeField]
    GameObject tutorialPopup;

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

        if (this.GetComponent<SceneFader>().faded == true)
        {
            OpenPopup();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.GetComponent<Menu>().ExitToMenu();
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

        if (!drone.enabled && isDisabled)
        {
            //*by Vojta
            EmotionsScript.StunnedFace();

            StartCoroutine(RestartDrone());
            isDisabled = false;
        }
    }

    public void OpenPopup()
    {
        tutorialPopup.SetActive(!tutorialPopup.activeSelf);

        if (tutorialPopup.activeSelf)
        {
            GameObject.Find("Settings").GetComponent<Button>().enabled = false;
            GameObject.Find("OpenTablet").GetComponent<Button>().enabled = false;
            GameObject.Find("OpenTutorial").GetComponent<Button>().enabled = false;
            Time.timeScale = 0f;
        }
    }

    public void ClosePopup()
    {
        tutorialPopup.SetActive(!tutorialPopup.activeSelf);

        if (!tutorialPopup.activeSelf)
        {
            GameObject.Find("Settings").GetComponent<Button>().enabled = true;
            GameObject.Find("OpenTablet").GetComponent<Button>().enabled = true;
            GameObject.Find("OpenTutorial").GetComponent<Button>().enabled = true;
            Time.timeScale = 1f;
        }
    }

    public IEnumerator RestartDrone()
    {
        yield return new WaitForSeconds(2.3f);
        drone.enabled = true;
    }
}
