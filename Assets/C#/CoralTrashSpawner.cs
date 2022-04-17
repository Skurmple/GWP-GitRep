using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralTrashSpawner : MonoBehaviour
{
    public Rigidbody2D[] trashList;
    Vector3 spawningPosition;
    public bool gotTrash;

    // Start is called before the first frame update
    void Start()
    {
        gotTrash = true;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int amountOfTrash = Random.Range(2, 5);

        for (int i = 0; i < amountOfTrash; i++)
        {
            spawningPosition = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
            int trashChoice = Random.Range(1, trashList.Length);

            Rigidbody2D clone;
            clone = Instantiate(trashList[trashChoice - 1], spawningPosition, Quaternion.Euler(new Vector3(0, 0, Random.Range(-25, 25))));
        }
        yield break;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Trash"))
        {
            gotTrash = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Trash"))
        {
            gotTrash = false;
        }
    }
}
