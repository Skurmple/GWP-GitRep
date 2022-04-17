using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;


public class DroneMovement : MonoBehaviour
{
    //Variable initialisation for values such as the net which is a child of the drone, the position of the mouse, and the move speed of the drone
    public TrashNet netChild;

    Vector2 mousePosition;
    Vector3 forwardVector;
    Vector3 startingPosition;
    public float moveSpeed = 7;
    public bool dashing;
    Coroutine dash;
    float dashMaxCooldown = 2;
    float dashCooldown;
    TrashMovement dashedTrash;
    TrashMovementNoAnim dashedTrashNoAnim;
    public GameController gc;
    public Menu menu;

    public Light2D droneLight;
    public Light2D globalLight;

    //*by Vojta
    GameObject lookForEmotions;
    protected Emotions EmotionsScript;

    public ParticleSystem bubbles;

    void Start()
    {
        startingPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        dashCooldown = dashMaxCooldown;

        //*by Vojta - Getting a reference to the emotions script
        lookForEmotions = GameObject.Find("DroneEmotions");
        EmotionsScript = lookForEmotions.GetComponent<Emotions>();

        CreateDust();
    }

    // FixedUpdate is called once per frame at a set frame rate
    void FixedUpdate()
    {
        //Finds the mouse position using Unity's functions
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Moves the drone towards the mouse position
        if (!Input.GetKey(KeyCode.LeftControl) && (mousePosition - new Vector2(transform.position.x, transform.position.y)).magnitude > 2 && (mousePosition - new Vector2(GameObject.Find("CameraCenter").transform.position.x, GameObject.Find("CameraCenter").transform.position.y)).magnitude < 18 || dashing)
        {
            transform.position = Vector3.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        }

        //Gets the direction the drone is moving in, and rotates it to face that direction
        forwardVector = (new Vector3(mousePosition.x, mousePosition.y, 0) - transform.position);
        forwardVector.Normalize();
        transform.right = forwardVector;

        //Stop drone from swimming upside down
        if (mousePosition.x < transform.position.x)
        {
            GameObject.Find("DroneEmotions").transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (mousePosition.x > transform.position.x)
        {
            GameObject.Find("DroneEmotions").transform.eulerAngles = new Vector3(0, 0, 0);
        }

        //Quick check to make sure the drone can't go above the water
        if (transform.position.y > GameObject.Find("Ocean Surface").transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, GameObject.Find("Ocean Surface").transform.position.y, transform.position.z);
        }

        if (transform.position.x < GameObject.Find("Net Blocker Left").transform.position.x)
        {
            transform.position = new Vector3(GameObject.Find("Net Blocker Left").transform.position.x, transform.position.y, transform.position.z);
        }

        if (transform.position.x > GameObject.Find("Net Blocker Right").transform.position.x)
        {
            transform.position = new Vector3(GameObject.Find("Net Blocker Right").transform.position.x, transform.position.y, transform.position.z);
        }
    }

    IEnumerator DroneDash()
    {
        moveSpeed += 10;
        bubbles.emissionRate += 100;
        FindObjectOfType<AudioManager>().Play("Dash");
        dashing = true;

        yield return new WaitForSeconds(0.5f);

        moveSpeed -= 10;
        bubbles.emissionRate -= 100;
        dashing = false;
        dashCooldown = dashMaxCooldown;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            menu.PlayStage1();
            Debug.Log("test");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            menu.PlayStage2();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            menu.PlayStage3();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            menu.CavesTest();
        }

        if (dashCooldown > 0)
        {
            dashCooldown -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && !dashing && dashCooldown <= 0)
        {
            dash = StartCoroutine(DroneDash());
        }

        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    //Collision detection of triggers
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks to see if the drone is over the boat
        if (collision.gameObject.tag == "Boat")
        {
            //If the drone is on the boat, set that flag to true
            netChild.onBoat = true;

            //*by Vojta - Changes the emotion of the drone
            if (netChild.trashList.Count > 0)
            {
                EmotionsScript.HappyFace();
            }

        }

        //Checks to see if the drone is over a fish
        if (collision.gameObject.tag == "Fish")
        {
            //Reverses the direction of the fish to make it swim away from the drone, and rotates it to face away from the drone
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x * -1, Random.Range(-1, 1));
            collision.gameObject.transform.Rotate(new Vector2(0, 180));
            
            //Decreases the score, although this at the moment isnt useful or being kept afaik
            netChild.score--;

            //*by Vojta
            EmotionsScript.SadFace();
            FindObjectOfType<AudioManager>().Play("HitFish");

            //Checks to see if the net has any trash in it
            if (netChild.trashList.Count > 0)
            {
                //Runs the HitFish() method in the nets code
                netChild.HitFish();
            }
        }

        if (collision.gameObject.tag == "Otter")
        {
            //Decreases the score, although this at the moment isnt useful or being kept afaik
            netChild.score--;

            //*by Vojta
            EmotionsScript.SadFace();
            FindObjectOfType<AudioManager>().Play("HitFish");

            //Checks to see if the net has any trash in it
            if (netChild.trashList.Count > 0)
            {
                //Runs the HitFish() method in the nets code
                netChild.HitFish();
            }
        }

        if (collision.gameObject.tag == "Pufferfish")
        {
            gc.isDisabled = true;
            enabled = false;
        }

        if (collision.gameObject.tag.Contains("Trash") && dashing)
        {
            if (collision.gameObject.GetComponent<TrashMovement>() != null && collision.gameObject.GetComponent<TrashMovement>().stuckInCoral == true)
            {
                dashedTrash = collision.GetComponent<TrashMovement>();
                dashedTrash.reefDashed = true;
            }
            else if (collision.gameObject.GetComponent<TrashMovementNoAnim>() != null && collision.gameObject.GetComponent<TrashMovementNoAnim>().stuckInCoral == true)
            {
                dashedTrashNoAnim = collision.GetComponent<TrashMovementNoAnim>();
                dashedTrashNoAnim.reefDashed = true;
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
    public void ResetPosition()
    {
        transform.position = startingPosition;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Scannable")
        {
            gc.isDisabled = true;
            enabled = false;
        }
    }

    void CreateDust()
    {
        bubbles.Play();
    }

}
