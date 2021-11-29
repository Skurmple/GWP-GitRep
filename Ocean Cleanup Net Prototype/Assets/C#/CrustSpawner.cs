using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrustSpawner : MonoBehaviour
{

    public GameObject crust;
    GameObject clone;
    float smoothFactor = 0.5f;
    Vector3 spawningPosition, randomTargetPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawningPosition = new Vector3(transform.position.x + 20, transform.position.y, 0); //Crust will spawn to the far right of the screen
        StartCoroutine(SpawnCrust());
    }

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
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 3; i++)
        {
            randomTargetPosition = new Vector3(transform.position.x + Random.Range(-4.0f, 4.0f), transform.position.y + Random.Range(-0.2f, 0.2f), 0); //A random position is selected
            clone = Instantiate(crust, spawningPosition, Quaternion.identity);
            clone.transform.parent = transform; //Make the crust a child of this game object
            yield return new WaitForSeconds(3f);
        }
        StartCoroutine(WaitForSpawn());
    }

    IEnumerator WaitForSpawn()
    {
        //If there are no children (CrustTrashSpawners that spawn trash) then start the coroutine to make more
        if (transform.childCount <= 0)
        {
            yield return new WaitForSeconds(2);
            StartCoroutine(SpawnCrust());
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(WaitForSpawn());
        }
    }
}
