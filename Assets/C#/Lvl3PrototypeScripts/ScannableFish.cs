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
    void Update()
    {
        if (!beingScanned && scanProgress > 0)
        {
            scanProgress -= 0.25f;
        }

        if (!finishedScanning)
        {
            colour = new Vector4(scanProgress/ 100, scanProgress / 100, scanProgress / 100, 1);
            gameObject.GetComponent<SpriteRenderer>().color = colour;
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
