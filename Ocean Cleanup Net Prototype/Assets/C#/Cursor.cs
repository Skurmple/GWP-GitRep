using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    Vector3 mousePosition;
    GameObject trash;
    bool onTrash;

    public int score;

    void Update()
    {
        //indetifying where the mouse is
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //move with the mouse
        transform.position = new Vector2(mousePosition.x, mousePosition.y);

        if(onTrash == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Destroy(trash.gameObject);
                //score++;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.tag == "Trash")
        {
            onTrash = true;
            trash = other.gameObject;
        }
        if (other.gameObject.tag == "Fish")
        {
            //Destroy(other.gameObject);
            //score--;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trash")
        {
            onTrash = false;
            trash = null;
        }
    }
}
