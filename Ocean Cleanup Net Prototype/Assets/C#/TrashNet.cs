using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashNet : MonoBehaviour
{
    Vector2 mousePosition;
    Vector3 forwardVector;
    public float moveSpeed = 7;
    public float speedReduction = 0.8f;

    public GameObject centerLocation;

    GameObject trash;
    GameObject trashToDestroy;
    public List<GameObject> trashList = new List<GameObject>();

    bool onBoat;

    public int score;
    public int plasticTrashAmt = 0, metalTrashAmt = 0, glassTrashAmt = 0;

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = Vector3.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

        forwardVector = (new Vector3(mousePosition.x, mousePosition.y, 0) - transform.position);
        forwardVector.Normalize();
        transform.right = forwardVector;

        if (onBoat == true && trashList.Count > 0)
        {
            for (int i = 0; i < trashList.Count; i++)
            {
                trashToDestroy = trashList[0];
                trashList.RemoveAt(0);
                moveSpeed /= speedReduction;
                if (trashToDestroy.gameObject.tag == "PlasticTrash")
                {
                    plasticTrashAmt++;
                }
                else if (trashToDestroy.gameObject.tag == "MetalTrash")
                {
                    metalTrashAmt++;
                }
                else if (trashToDestroy.gameObject.tag == "GlassTrash")
                {
                    glassTrashAmt++;
                }
                Destroy(trashToDestroy.gameObject);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (trashList.Count < 5)
        {
            if (collision.gameObject.tag.Contains("Trash"))
            {
                trash = collision.gameObject;               
                trashList.Add(trash);
                trash.gameObject.transform.SetParent(centerLocation.gameObject.transform);
                trash.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                trash.gameObject.transform.localPosition = Vector2.zero;
                trash.gameObject.GetComponent<TrashMovement>().enabled = false;
                moveSpeed *= speedReduction;
            }
        }

        if (collision.gameObject.tag == "Fish")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x * -1, Random.Range(-1, 1));
            collision.gameObject.transform.Rotate(new Vector2(0, 180));
            score--;
        }

        if (collision.gameObject.tag == "Boat")
        {
            onBoat = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boat")
        {
            onBoat = false;
        }
    }

    public void UpgradeNet()
    {
        if (plasticTrashAmt > 4 && metalTrashAmt > 4 && glassTrashAmt > 4)
        {
            plasticTrashAmt -= 5;
            metalTrashAmt -= 5;
            glassTrashAmt -= 5;
            moveSpeed += 2;
            speedReduction += 0.05f;
        }
    }
}
