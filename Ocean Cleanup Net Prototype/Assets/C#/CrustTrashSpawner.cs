using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrustTrashSpawner : MonoBehaviour
{

    public Rigidbody2D plasticBottle, plasticBag;
    public Rigidbody2D metalScrap, metalCan;
    public Rigidbody2D glassBottle;
    Vector3 spawningPosition;
    Vector3 droppedPosition;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {

    }
    //spawning food between 1-3 seconds
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(6);
        int waves = Random.Range(4, 8);
        for (int i = 0; i < waves; i++)
        {
            int amountOfTrash = Random.Range(4, 8);

            yield return new WaitForSeconds(Random.Range(3, 7));

            for (int j = 0; j < amountOfTrash; j++)
            {
                yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));

                spawningPosition = new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y, 0);

                //Generate a random number between 0 and 100
                int trashChoice = Random.Range(0, 100);

                //If random number is less than 50, clone red trash, if it is greater than 50, spawn green trash
                if (trashChoice <= 33)
                {
                    int plasticChoice = Random.Range(0, 100);

                    if (plasticChoice < 50)
                    {
                        Rigidbody2D clone;
                        clone = Instantiate(plasticBottle, spawningPosition, Quaternion.identity); //Quaternion.Euler(new Vector3(0, 0, Random.Range(-25, 25)))
                    }
                    else
                    {
                        Rigidbody2D clone;
                        clone = Instantiate(plasticBag, spawningPosition, Quaternion.identity);
                    }
                }
                else if (trashChoice > 33 && trashChoice <= 66)
                {
                    int metalChoice = Random.Range(0, 100);

                    if (metalChoice < 50)
                    {
                        Rigidbody2D clone;
                        clone = Instantiate(metalScrap, spawningPosition, Quaternion.identity);
                    }
                    else
                    {
                        Rigidbody2D clone;
                        clone = Instantiate(metalCan, spawningPosition, Quaternion.identity);
                    }
                }
                else if (trashChoice > 66)
                {
                    Rigidbody2D clone;
                    clone = Instantiate(glassBottle, spawningPosition, Quaternion.identity);
                }
            }
        }
        Destroy(gameObject);
        yield break;
    }
    public void SpawnReplaceTrash(Vector3 dronePosition, GameObject trash)
    {
        droppedPosition = dronePosition;
        droppedPosition.y = dronePosition.y - 2;

        Rigidbody2D clone;
        clone = Instantiate(trash.GetComponent<Rigidbody2D>(), droppedPosition, Quaternion.identity);
        clone.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        clone.gameObject.GetComponent<TrashMovement>().enabled = true;
    }
}
