using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrashNet : MonoBehaviour
{
    public GameObject centerLocation;
    public DroneMovement droneParent;
    public List<Coral> coralReefs = new List<Coral>();

    [SerializeField]
    CrustTrashSpawner crustTrashSpawn;

    GameObject trash;
    GameObject trashToDestroy;
    GameObject trashToLose;
    public List<GameObject> trashList = new List<GameObject>();

    public bool onBoat;
    bool holdingCoral;
    GameObject rainbowCoral;

    public int score;
    public int plasticTrashAmt = 0, metalTrashAmt = 0, glassTrashAmt = 0;

    bool playSound;

    void Start()
    {
        playSound = true;
    }

    void Update()
    {
        if (onBoat == true && trashList.Count > 0)
        {
           
            FindObjectOfType<AudioManager>().Play("UnloadTrash");

        

            for (int i = 0; i < trashList.Count; i++)
            {
                trashToDestroy = trashList[0];
                trashList.RemoveAt(0);
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
                score += 5;
                Destroy(trashToDestroy.gameObject);
            }
        }

        if (score >= 100)
        {
            StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "Stage 2"));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Trash"))
        {
            if (trashList.Count == 7 && playSound == true)
            {
                FindObjectOfType<AudioManager>().Play("FullNet");
                playSound = false;
                StartCoroutine(SoundTimer());
            }
        }

        //If net is not full
        if (trashList.Count < 7)
        {
            //And if object is a trash item
            if (collision.gameObject.tag.Contains("Trash"))
            {
                trash = collision.gameObject;

                //And the trash is not stuck in coral
                if (trash.GetComponent<TrashMovement>().stuckInCoral == false)
                {
                    FindObjectOfType<AudioManager>().Play("PickTrash");

                    trashList.Add(trash);
                    trash.gameObject.transform.SetParent(centerLocation.gameObject.transform);
                    trash.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                    trash.gameObject.transform.localPosition = Vector2.zero;
                    trash.gameObject.GetComponent<TrashMovement>().enabled = false;

                    Animator animatorTrash;
                    animatorTrash = trash.gameObject.GetComponent<Animator>();
                    animatorTrash.SetBool("inNet", true);
                }
            }
        }
        

        //For the pick-uppable coral
        if(collision.gameObject.tag == "Coral" && !holdingCoral)
        {
            rainbowCoral = collision.gameObject;
            rainbowCoral.gameObject.transform.SetParent(centerLocation.gameObject.transform);
            rainbowCoral.gameObject.transform.localPosition = Vector2.zero;
            holdingCoral = true;
        }

        //For the dying coral
        if(collision.gameObject.tag == "Reef" && holdingCoral)
        {
            holdingCoral = false;
            Destroy(rainbowCoral);
            

            //!!Coral reefs are now stored in a list so there can be multiple coral reefs
            //This switch statement checks to see which coral reef was in the collision but this is a clumsy way of doing it as it relys on the reefs having specific names
            //and being is specific locations in the list
            //There must be a way of doing this automatically no matter how many coral reefs there are and no matter what they're names are but my dumby brain cant think of it rn
            switch (collision.gameObject.name)
            {
                case "CoralReef1":
                    coralReefs[0].coralHealth += 2;
                    coralReefs[0].spriteChange = true;
                    break;

                case "CoralReef2":
                    coralReefs[1].coralHealth += 2;
                    coralReefs[1].spriteChange = true;
                    break;

                case "CoralReef3":
                    coralReefs[2].coralHealth += 2;
                    coralReefs[2].spriteChange = true;
                    break;

                case "CoralReef4":
                    coralReefs[3].coralHealth += 2;
                    coralReefs[3].spriteChange = true;
                    break;
            }
        }
    }

    public void HitFish()
    {
        trashToLose = trashList[0];
        trashList.RemoveAt(0);
        crustTrashSpawn.SpawnReplaceTrash(this.transform.position, trashToLose);
        Destroy(trashToLose.gameObject);
    }

    private IEnumerator SoundTimer()
    {
        yield return new WaitForSeconds(1.0f);
        playSound = true;
    }

}
