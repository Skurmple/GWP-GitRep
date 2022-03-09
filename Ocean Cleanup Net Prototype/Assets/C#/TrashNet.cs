using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrashNet : MonoBehaviour
{
    public GameObject centerLocation;
    public DroneMovement droneParent;
    public List<Coral> coralReefs = new List<Coral>();
    public CrustTrashSpawner trashSpawn;
    public RainbowCoralSpawner coralSpawner;

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
                //coral.tempColor = coral.GetComponent<SpriteRenderer>().color;
                //coral.tempColor.a += 0.05f;
                //coral.GetComponent<SpriteRenderer>().color = coral.tempColor;
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
        if (trashList.Count < 7)
        {
            if (collision.gameObject.tag.Contains("Trash"))
            {
                trash = collision.gameObject;
                trashList.Add(trash);
                trash.gameObject.transform.SetParent(centerLocation.gameObject.transform);
                trash.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                trash.gameObject.transform.localPosition = Vector2.zero;
                trash.gameObject.GetComponent<TrashMovement>().enabled = false;
            }
        }

        //For the pick-uppable coral
        if(collision.gameObject.tag == "Coral" && !holdingCoral)
        {
            rainbowCoral = collision.gameObject;
            rainbowCoral.gameObject.transform.SetParent(centerLocation.gameObject.transform);
            rainbowCoral.gameObject.transform.localPosition = Vector2.zero;
            rainbowCoral.gameObject.GetComponent<RainbowCoral>().enabled = false;
            holdingCoral = true;
        }

        //For the dying coral
        if(collision.gameObject.tag == "Reef" && holdingCoral)
        {
            holdingCoral = false;
            Destroy(rainbowCoral);
            coralSpawner.coralSpawned = false;
            

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
        trashSpawn.SpawnReplaceTrash(this.transform.position, trashToLose);
        Destroy(trashToLose);
    }
}
