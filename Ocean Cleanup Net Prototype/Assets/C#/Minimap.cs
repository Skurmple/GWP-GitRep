using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        Vector3 newPosition_x = player.position;
        newPosition_x.x = transform.position.x;
        transform.position = newPosition_x;

        Vector3 newPosition_y = player.position;
        newPosition_y.y = transform.position.y;
        transform.position = newPosition_y;
    }

}
