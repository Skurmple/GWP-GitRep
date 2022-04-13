using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public GameObject[] scannedFish;
    ScannableFish scannableFish;
    FishDexManager fdm;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        scannedFish = new GameObject[10];
        i = 0;
        if(GameObject.Find("FishDexManager") != null)
        {
            fdm = GameObject.Find("FishDexManager").GetComponent<FishDexManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Scannable")
        {
            scannableFish = collision.GetComponent<ScannableFish>();
            scannableFish.beingScanned = true;
        }

        if (collision.gameObject.tag.Contains("Trash") && collision.gameObject.GetComponent<TrashMovement>().stuckInCoral == true)
        {
            //reefBlower = collision.GetComponent<TrashMovement>();
            //reefBlower.reefBlown = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Scannable")
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
                        fdm.hasScanned[0] = true;
                        break;
                    case "Oarfish":
                        fdm.hasScanned[1] = true;
                        break;
                    case "Squid":
                        fdm.hasScanned[2] = true;
                        break;
                }
            }

        }
    }
}
