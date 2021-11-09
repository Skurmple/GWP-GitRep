using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    //Variable initialisation for values such as the net which is a child of the drone, the position of the mouse, and the move speed of the drone
    public TrashNet netChild;

    Vector2 mousePosition;
    Vector3 forwardVector;
    Vector3 localScale = new Vector3(0.25f, 0.25f, 0.25f);
    public float moveSpeed = 7;
    public float speedReduction = 0.8f;

    // FixedUpdate is called once per frame at a set frame rate
    void FixedUpdate()
    {
        //Finds the mouse position using Unity's functions
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Moves the drone towards the mouse position
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

        //Gets the direction the drone is moving in, and rotates it to face that direction
        forwardVector = (new Vector3(mousePosition.x, mousePosition.y, 0) - transform.position);
        forwardVector.Normalize();
        transform.right = forwardVector;

        //Quick check to make sure the drone can't go above the water
        if (transform.position.y > 3.5f)
        {
            transform.position = new Vector3(transform.position.x, 3.5f, transform.position.z);
        }
    }

    //Collision detection of triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks to see if the drone is over the boat
        if (collision.gameObject.tag == "Boat")
        {
            //If the drone is on the boat, set that flag to true
            netChild.onBoat = true;
        }

        //Checks to see if the drone is over a fish
        if (collision.gameObject.tag == "Fish")
        {
            //Reverses the direction of the fish to make it swim away from the drone, and rotates it to face away from the drone
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x * -1, Random.Range(-1, 1));
            collision.gameObject.transform.Rotate(new Vector2(0, 180));
            
            //Decreases the score, although this at the moment isnt useful or being kept afaik
            netChild.score--;

            //Checks to see if the net has any trash in it
            if (netChild.trashList.Count > 0)
            {
                //Runs the HitFish() method in the nets code
                netChild.HitFish();
            }
        }
    }

    //Collision detection for when the drone leaves the collision of something
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Checks to see if the drone has left the boat
        if (collision.gameObject.tag == "Boat")
        {
            //Sets that flag to false
            netChild.onBoat = false;
        }
    }

    //Method to increase the net's speed when called
    public void UpgradeNetSpeed()
    {
        //Increases the speed of the drone
        moveSpeed += 2;
        //Increases the rate at which the speed decreases when picking up trash
        speedReduction += 0.05f;
    }
}
