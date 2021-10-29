using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTrashSpawner : MonoBehaviour
{

    public Rigidbody2D redTrash;
    public Rigidbody2D greenTrash;
    Vector3 spawningPosition;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        spawningPosition = new Vector3(transform.position.x, Random.Range(-2, 2), 0);
    }
    //spawning food between 1-3 seconds
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1.5f);

        //Generate a random number between 0 and 100
        int trashChoice = Random.Range(0, 100);

        //If random number is less than 50, clone red trash, if it is greater than 50, spawn green trash
        if (trashChoice <= 49)
        {
            Rigidbody2D clone;
            clone = Instantiate(redTrash, spawningPosition, transform.rotation);
            clone.velocity = new Vector2(1.5f, 0f);
        }
        else if (trashChoice >= 50)
        {
            Rigidbody2D clone;
            clone = Instantiate(greenTrash, spawningPosition, transform.rotation);
            clone.velocity = new Vector2(1.5f, 0f);
        }

        yield return new WaitForSeconds(Random.Range(2, 4));
        StartCoroutine(Spawn());
    }
}
