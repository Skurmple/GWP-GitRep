using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashNet : MonoBehaviour
{
    Vector2 mousePosition;
    public float moveSpeed = 7;

    GameObject trash;
    GameObject trashToDestroy;
    public List<GameObject> trashList = new List<GameObject>();

    bool onBoat;

    public int score;

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

        if (onBoat == true && trashList.Count > 0)
        {
            for(int i = 0; i < trashList.Count; i++)
            {
                trashToDestroy = trashList[i];
                Destroy(trashToDestroy.gameObject);
                trashList.RemoveAt(i);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (trashList.Count < 5)
        {
            if (collision.gameObject.tag == "Trash")
            {
                trash = collision.gameObject;               
                trashList.Add(trash);
                Debug.Log(trashList.Count);
                trash.gameObject.transform.SetParent(this.gameObject.transform);
            }
        }

        if (collision.gameObject.tag == "Fish")
        {
            Destroy(collision.gameObject);
            score--;
        }

        if (collision.gameObject.tag == "Boat")
        {
            onBoat = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            
        }
        if (collision.gameObject.tag == "Boat")
        {
            onBoat = false;
        }
    }
}
