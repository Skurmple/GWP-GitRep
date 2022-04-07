using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralTrashSpawner : MonoBehaviour
{
    public Rigidbody2D plasticBottle, plasticBag;
    public Rigidbody2D metalScrap, metalCan;
    public Rigidbody2D glassBottle;
    Vector3 spawningPosition;
    Vector3 droppedPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int amountOfTrash = Random.Range(2, 5);

        for (int i = 0; i < amountOfTrash; i++)
        {
            spawningPosition = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));

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
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
