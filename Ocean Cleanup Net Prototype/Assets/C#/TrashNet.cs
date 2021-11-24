using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashNet : MonoBehaviour
{
    public GameObject centerLocation;
    public DroneMovement droneParent;
    public Coral coral;

    GameObject trash;
    GameObject trashToDestroy;
    GameObject trashToLose;
    public List<GameObject> trashList = new List<GameObject>();

    public bool onBoat;
    bool holdingCoral;
    GameObject rainbowCoral;

    public int score;
    public int plasticTrashAmt = 0, metalTrashAmt = 0, glassTrashAmt = 0;
    int netUpgradeTimes = 0;

    void Update()
    {
        if (onBoat == true && trashList.Count > 0)
        {
            for (int i = 0; i < trashList.Count; i++)
            {
                coral.tempColor = coral.GetComponent<SpriteRenderer>().color;
                coral.tempColor.a += 0.05f;
                coral.GetComponent<SpriteRenderer>().color = coral.tempColor;
                trashToDestroy = trashList[0];
                trashList.RemoveAt(0);
                droneParent.moveSpeed /= droneParent.speedReduction;
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
                droneParent.moveSpeed *= droneParent.speedReduction;
            }
        }

        //For the pick-uppable coral
        if(collision.gameObject.tag == "Coral")
        {
            rainbowCoral = collision.gameObject;
            rainbowCoral.gameObject.transform.SetParent(centerLocation.gameObject.transform);
            rainbowCoral.gameObject.transform.localPosition = Vector2.zero;
            holdingCoral = true;
        }

        //For the dying coral
        if(collision.gameObject.name == "Coral" && holdingCoral)
        {
            coral.tempColor = coral.GetComponent<SpriteRenderer>().color;
            coral.tempColor.a += 0.4f;
            coral.GetComponent<SpriteRenderer>().color = coral.tempColor;
            holdingCoral = false;
            Destroy(rainbowCoral);
        }

        //if (collision.gameObject.tag == "Fish")
        //{
        //    collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x * -1, Random.Range(-1, 1));
        //    collision.gameObject.transform.Rotate(new Vector2(0, 180));
        //    score--;
        //}
    }

    public void UpgradeNet()
    {
        if (netUpgradeTimes < 3)
        {
            if (plasticTrashAmt > 3 && metalTrashAmt > 1 && glassTrashAmt > 1)
            {
                plasticTrashAmt -= 4;
                metalTrashAmt -= 2;
                glassTrashAmt -= 2;
                netUpgradeTimes += 1;
            }
        }
    }

    public void HitFish()
    {
        trashToLose = trashList[0];
        trashList.RemoveAt(0);
        Destroy(trashToLose.gameObject);
        droneParent.moveSpeed /= droneParent.speedReduction;
    }
}
