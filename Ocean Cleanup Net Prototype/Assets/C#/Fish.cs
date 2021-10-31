using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    PauseGame pg;
    public Vector2 speed;
    Rigidbody2D rb;
    bool oneTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = rb.velocity;
        pg = GameObject.Find("GameController").GetComponent<PauseGame>();
        oneTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pg.gamePaused && oneTime)
        {
            rb.velocity = speed;
            speed = rb.velocity;
            oneTime = false;
        }
        else if (pg.gamePaused)
        {
            rb.velocity = new Vector2(0, 0);
            oneTime = true;
        }
    }
}
