using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public GameObject[] scannedFish;
    ScannableFish scannableFish;
    public GameObject spotlight;
    public Emotions emotions;
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
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Scannable")
        {
            if(scannableFish.scanProgress < 100 && !scannableFish.finishedScanning)
            {
                scannableFish.scanProgress += 1.5f;
                spotlight.GetComponent<SpriteRenderer>().color = new Vector4(0.7f, 1, 0.7f, 1);
            }
            else if(scannableFish.scanProgress >= 100 && !scannableFish.finishedScanning)
            {
                spotlight.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
                emotions.HappyFace();
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Scannable")
        {
            spotlight.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
        }
    }
}
