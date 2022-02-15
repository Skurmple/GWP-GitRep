using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public GameObject[] scannedFish;
    ScannableFish scannableFish;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        scannedFish = new GameObject[20];
        i = 0;
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
            if(scannableFish.scanProgress < 100)
            {
                scannableFish.scanProgress += 1.0f;
            }
            else if(scannableFish.scanProgress >= 100 && !scannableFish.finishedScanning)
            {
                scannableFish.finishedScanning = true;
                scannableFish.GetComponent<SpriteRenderer>().color = new Vector4(0, 1, 0, 1);
                scannedFish[i] = collision.gameObject;
                i++;
            }

        }
    }
}
