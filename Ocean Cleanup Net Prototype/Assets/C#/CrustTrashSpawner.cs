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

                spawningPosition = new Vector3(transform.position.x + Random.Range(-17, 17), transform.position.y - 2, 0);

                //Generate a random number between 0 and 100
                int trashChoice = Random.Range(0, 101);

                //If random number is less than 50, clone plastic trash, this means plastic trash is the most likely to appear (50%), then metal (35%) and then glass (15%)
                if (trashChoice <= 50)
                {
                    int plasticChoice = Random.Range(0, 100);

                    if (plasticChoice < 50)
                    {
                        Rigidbody2D clone;
                        clone = Instantiate(plasticBottle, spawningPosition, Quaternion.Euler(new Vector3(0, 0, Random.Range(-25, 25)))); 
                    }
                    else
                    {
                        Rigidbody2D clone;
                        clone = Instantiate(plasticBag, spawningPosition, Quaternion.Euler(new Vector3(0, 0, Random.Range(-25, 25))));
                    }
                }
                else if (trashChoice > 50 && trashChoice <= 85)
                {
                    int metalChoice = Random.Range(0, 100);

                    if (metalChoice < 50)
                    {
                        Rigidbody2D clone;
                        clone = Instantiate(metalScrap, spawningPosition, Quaternion.Euler(new Vector3(0, 0, Random.Range(-25, 25))));
                    }
                    else
                    {
                        Rigidbody2D clone;
                        clone = Instantiate(metalCan, spawningPosition, Quaternion.Euler(new Vector3(0, 0, Random.Range(-25, 25))));
                    }
                }
                else if (trashChoice > 85)
                {
                    Rigidbody2D clone;
                    clone = Instantiate(glassBottle, spawningPosition, Quaternion.Euler(new Vector3(0, 0, Random.Range(-25, 25))));
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

        //Animator animatorTrash;

        Rigidbody2D clone;
        clone = Instantiate(trash.GetComponent<Rigidbody2D>(), droppedPosition, Quaternion.identity);
        clone.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        clone.gameObject.GetComponent<TrashMovement>().enabled = true;

        //animatorTrash = clone.gameObject.GetComponent<Animator>();
        //animatorTrash.SetFloat("timerDissolve", 25.0f);

        clone.gameObject.GetComponent<TrashMovement>().dislodged = false;
        clone.gameObject.GetComponent<TrashMovement>().reefDashed = false;
        clone.gameObject.GetComponent<TrashMovement>().netFall = true;
    }
}
