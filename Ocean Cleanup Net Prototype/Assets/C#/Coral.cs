using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coral : MonoBehaviour
{
    public Color tempColor;

    // Start is called before the first frame update
    void Start()
    {
        tempColor = GetComponent<SpriteRenderer>().color;
        tempColor.a = 0.2f;
        GetComponent<SpriteRenderer>().color = tempColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "MetalTrash:":
            case "GlassTrash":
            case "PlasticTrash":
                tempColor = GetComponent<SpriteRenderer>().color;
                tempColor.a -= 0.05f;
                GetComponent<SpriteRenderer>().color = tempColor;
                break;
        }
    }
}
