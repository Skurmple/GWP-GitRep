using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannableFish : MonoBehaviour
{
    public float scanProgress;
    public bool beingScanned;
    public bool finishedScanning;
    Vector4 colour;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!beingScanned && scanProgress > 0)
        {
            scanProgress -= 0.7f;
        }

        if (!finishedScanning)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Vector4(scanProgress / 100, scanProgress / 100, scanProgress / 100, 1);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            beingScanned = false;
        }
    }
}
