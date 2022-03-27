using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public GameObject[] scannedFish;
    ScannableFish scannableFish;
    TrashMovement reefBlower;
    FishDexManager fdm;
    bool stage3; //Allows for a check to see if it is stage 3 or stage 2 so the collider can be used as a scanner or reefblower
    int i;

    // Start is called before the first frame update
    void Start()
    {
        scannedFish = new GameObject[10];
        i = 0;
        fdm = GameObject.Find("FishDexManager").GetComponent<FishDexManager>();

        //If FishDexManager is found then it is stage 3
        if (fdm != null)
        {
            stage3 = true;
        }
        else
        {
            stage3 = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Scannable" && stage3)
        {
            scannableFish = collision.GetComponent<ScannableFish>();
            scannableFish.beingScanned = true;
        }

        if (collision.gameObject.tag.Contains("Trash") && collision.gameObject.GetComponent<TrashMovement>().stuckInCoral == true && !stage3)
        {
            reefBlower = collision.GetComponent<TrashMovement>();
            reefBlower.reefBlown = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Scannable" && stage3)
        {
            if(scannableFish.scanProgress < 100)
            {
                scannableFish.scanProgress += 1.0f;
            }
            else if(scannableFish.scanProgress >= 100 && !scannableFish.finishedScanning)
            {
                scannableFish.finishedScanning = true;
                scannedFish[i] = collision.gameObject;
                i++;
                switch (scannableFish.name)
                {
                    case "Nautilus":
                        fdm.isScanned_0 = true;
                        break;
                    case "Oarfish":
                        fdm.isScanned_1 = true;
                        break;
                    case "Squid":
                        fdm.isScanned_5 = true;
                        break;
                }
            }

        }
    }
}
