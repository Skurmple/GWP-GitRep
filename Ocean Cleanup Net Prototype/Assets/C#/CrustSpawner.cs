using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrustSpawner : MonoBehaviour
{

    public GameObject crust;
    public GameController gameController;
    GameObject clone;
    float smoothFactor = 0.5f;
    Vector3 spawningPosition, targetPosition;
    GameObject clamp;
    public bool crustCleaned;

    // Start is called before the first frame update
    void Start()
    {
        clamp = GameObject.Find("Drone Clamp");
        spawningPosition = new Vector3(transform.position.x - 25, transform.position.y, 0); //Crust will spawn to the far right of the screen
        //StartCoroutine(SpawnCrust());
        StartCoroutine(WaitForSpawn()); //For testing, uncomment this, comment line above to start with free camera movement.
    }

    // amie wuz here
    // Update is called once per frame
    void Update()
    {
        //Allows for smooth movement between the spawning position to the random target position
        if (clone != null)
        {
            clone.transform.position = Vector3.Lerp(clone.transform.position, targetPosition, Time.deltaTime * smoothFactor);
        }
    }

    IEnumerator SpawnCrust()
    {
        clamp.SetActive(true);
        gameController.cameraDisabled = true;
        yield return new WaitForSeconds(0.5f);

        //targetPosition = new Vector3(0, transform.position.y + Random.Range(-0.2f, 0.2f), 0); //A random position is selected
        targetPosition = new Vector3(0, transform.position.y, 0);

        clone = Instantiate(crust, spawningPosition, Quaternion.identity);
        clone.transform.parent = transform; //Make the crust a child of this game object
        yield return new WaitForSeconds(5f);

        StartCoroutine(WaitForSpawn());
    }

    IEnumerator WaitForSpawn()
    {
        //If there are no children (CrustTrashSpawners that spawn trash) then start the coroutine to make more
        if (transform.childCount <= 0)
        {
            gameController.cameraDisabled = false;
            crustCleaned = true;
            clamp.SetActive(false);
            yield return new WaitForSeconds(1);
            StartCoroutine(SpawnCrust());
            StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "Stage 2"));
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
            crustCleaned = false;
            StartCoroutine(WaitForSpawn());
        }
    }
}
