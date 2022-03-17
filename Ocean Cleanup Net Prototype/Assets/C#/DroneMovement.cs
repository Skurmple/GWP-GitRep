using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class DroneMovement : MonoBehaviour
{
    //Variable initialisation for values such as the net which is a child of the drone, the position of the mouse, and the move speed of the drone
    public TrashNet netChild;

    Vector2 mousePosition;
    Vector3 forwardVector;
    Vector3 startingPosition;
    public float moveSpeed = 7;
    public GameController gc;
    public Menu menu;
    public GameObject droneClamp;

    private float lightTimer = 0f;
    public Light2D droneLight;
    public Light2D globalLight;
    public Light2D uiLight;
    public Light2D scoreLight;

    //*by Vojta
    GameObject lookForEmotions;
    protected Emotions EmotionsScript;

    public ParticleSystem bubbles;

    void Start()
    {
        startingPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        droneLight.intensity = 0;
        uiLight.intensity = 0;
        scoreLight.intensity = 0;
        globalLight.intensity = 1;

        //*by Vojta - Getting a reference to the emotions script
        lookForEmotions = GameObject.Find("Emotions_test");
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
        if((mousePosition - new Vector2(transform.position.x, transform.position.y)).magnitude > 0.6f && !Input.GetKey(KeyCode.LeftControl))
        {
            transform.position = Vector3.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

            
        }

        //Gets the direction the drone is moving in, and rotates it to face that direction
        forwardVector = (new Vector3(mousePosition.x, mousePosition.y, 0) - transform.position);
        forwardVector.Normalize();
        transform.right = forwardVector;

        //Quick check to make sure the drone can't go above the water
        if (transform.position.y > GameObject.Find("Ocean Surface").transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, GameObject.Find("Ocean Surface").transform.position.y, transform.position.z);
        }

        if (transform.position.y < droneClamp.transform.position.y && droneClamp.activeSelf == true)
        {
            transform.position = new Vector3(transform.position.x, droneClamp.transform.position.y, transform.position.z);
        }
        

        if(transform.position.x < GameObject.Find("Net Blocker Left").transform.position.x && transform.position.y > GameObject.Find("Cave Entrance").transform.position.y)
        {
            transform.position = new Vector3(GameObject.Find("Net Blocker Left").transform.position.x, transform.position.y, transform.position.z);
        }

        if(transform.position.x > GameObject.Find("Net Blocker Right").transform.position.x && transform.position.y > GameObject.Find("Cave Entrance").transform.position.y)
        {
            transform.position = new Vector3(GameObject.Find("Net Blocker Right").transform.position.x, transform.position.y, transform.position.z);
        }
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

        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (transform.position.y < GameObject.Find("Cave Entrance").transform.position.y)
        {
            if (lightTimer < 1)
            {
                droneLight.intensity = Mathf.Lerp(0, 1, lightTimer);
                uiLight.intensity = Mathf.Lerp(0, 1, lightTimer);
                scoreLight.intensity = Mathf.Lerp(0, 1, lightTimer);
                globalLight.intensity = Mathf.Lerp(1, 0.1f, lightTimer);
                lightTimer += 0.5f * Time.deltaTime;
            }
        }

        if (transform.position.y > GameObject.Find("Cave Entrance").transform.position.y)
        {
            if (lightTimer > 0)
            {
                droneLight.intensity = Mathf.Lerp(0, 1, lightTimer);
                uiLight.intensity = Mathf.Lerp(0, 1, lightTimer);
                scoreLight.intensity = Mathf.Lerp(0, 1, lightTimer);
                globalLight.intensity = Mathf.Lerp(1, 0.1f, lightTimer);
                lightTimer -= 0.5f * Time.deltaTime;
            }
        }
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

            //Checks to see if the net has any trash in it
            if (netChild.trashList.Count > 0)
            {
                //Runs the HitFish() method in the nets code
                netChild.HitFish();
            }
        }

        if(collision.gameObject.tag == "Pufferfish")
        {
            gc.isDisabled = true;
            enabled = false;
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
        droneClamp.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Swordfish")
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
