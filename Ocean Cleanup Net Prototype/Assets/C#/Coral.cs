using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coral : MonoBehaviour
{
    public Color tempColor;
    public float oceanTemp;

    int coralDamage = 12;

    public GameObject[] coralArray;

    // Start is called before the first frame update
    void Start()
    {
        tempColor = GetComponent<SpriteRenderer>().color;
        tempColor.a = 0.2f;
        GetComponent<SpriteRenderer>().color = tempColor;
        oceanTemp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (coralDamage >= 10)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            GameObject Reef = Instantiate(coralArray[0], transform.position, Quaternion.identity);
            Reef.transform.parent = gameObject.transform;
        }
        else if (coralDamage >= 7)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            GameObject Reef = Instantiate(coralArray[1], transform.position, Quaternion.identity);
            Reef.transform.parent = gameObject.transform;
        }
        else if (coralDamage >= 4)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            GameObject Reef = Instantiate(coralArray[2], transform.position, Quaternion.identity);
            Reef.transform.parent = gameObject.transform;
        }
        else if (coralDamage >= 1)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            GameObject Reef = Instantiate(coralArray[3], transform.position, Quaternion.identity);
            Reef.transform.parent = gameObject.transform;
        }
        else
        {
            //GameLost (For playtest only)
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "MetalTrash":
            case "GlassTrash":
            case "PlasticTrash":
                //tempColor = GetComponent<SpriteRenderer>().color;
                //tempColor.a -= 0.05f;
                //GetComponent<SpriteRenderer>().color = tempColor;
                oceanTemp += 1;
                coralDamage -= 1;
                Destroy(collision.gameObject);
                break;
        }
    }
}
