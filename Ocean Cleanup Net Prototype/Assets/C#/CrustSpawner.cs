using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrustSpawner : MonoBehaviour
{

    public GameObject crust;
    public GameController gameController;
    GameObject clone;
    float smoothFactor = 0.5f;
    Vector3 spawningPosition, randomTargetPosition;
    GameObject clamp;

    // Start is called before the first frame update
    void Start()
    {
        clamp = GameObject.Find("Drone Clamp");
        spawningPosition = new Vector3(transform.position.x - 20, transform.position.y, 0); //Crust will spawn to the far right of the screen
        StartCoroutine(SpawnCrust());
        //StartCoroutine(WaitForSpawn()); //For testing, uncomment this, comment line above to start with free camera movement
    }

    // amie wuz here
    // Update is called once per frame
    void Update()
    {
        //Allows for smooth movement between the spawning position to the random target position
        if (clone != null)
        {
            clone.transform.position = Vector3.Lerp(clone.transform.position, randomTargetPosition, Time.deltaTime * smoothFactor);
        }
    }

    IEnumerator SpawnCrust()
    {
        clamp.SetActive(true);
        gameController.cameraDisabled = true;
        yield return new WaitForSeconds(0.5f);

        randomTargetPosition = new Vector3(transform.position.x + Random.Range(-4.0f, 0.0f), transform.position.y, 0); //A random position is selected
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
            clamp.SetActive(false);
            yield return new WaitForSeconds(60);
            StartCoroutine(SpawnCrust());
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(WaitForSpawn());
        }
    }
}
