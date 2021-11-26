using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrustSpawner : MonoBehaviour
{

    public GameObject crust;
    Vector3 spawningPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCrust());
    }

    // Update is called once per frame
    void Update()
    {
        spawningPosition = new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-0.5f, 0.5f), 0);
    }

    IEnumerator SpawnCrust()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 3; i++)
        {
            GameObject clone;
            clone = Instantiate(crust, spawningPosition, Quaternion.identity);
            clone.transform.parent = transform;
            clone.transform.position = spawningPosition;
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine(WaitForSpawn());
    }

    IEnumerator WaitForSpawn()
    {
        //If there are no children (CrustTrashSpawners that spawn trash) then start the coroutine to make more
        if (transform.childCount <= 0)
        {
            yield return new WaitForSeconds(10);
            StartCoroutine(SpawnCrust());
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(WaitForSpawn());
        }
    }
}
