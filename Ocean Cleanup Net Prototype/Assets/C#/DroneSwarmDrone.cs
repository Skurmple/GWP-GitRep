using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSwarmDrone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Trash") || collision.gameObject.tag == "Pile")
        {
            Destroy(collision.gameObject);
        }
    }
}
