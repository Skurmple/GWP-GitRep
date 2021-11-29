using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFish : MonoBehaviour
{
    public float circleDistance;
    Vector3 distanceToNet;
    GameObject net;
    bool rotating;
    bool startTimer;
    bool dashing;
    float time;
    Vector3 distanceNormalized;
    bool canBeDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        circleDistance = 5.0f;
        net = GameObject.Find("Net");
        rotating = true;
        time = 0;
    }

    void OnBecameInvisible()
    {
        if (canBeDestroyed)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        distanceToNet = net.transform.position - transform.position;
        distanceNormalized = distanceToNet;
        distanceNormalized.Normalize();
        transform.right = -distanceNormalized;


        if (startTimer)
        {
            time += Time.deltaTime;
            if(time >= 3.5f)
            {
                StartCoroutine("Dash");
                time = 0;
            }
        }
        if (distanceToNet.magnitude > circleDistance && !dashing)
        {
            transform.position = Vector2.MoveTowards(transform.position, net.transform.position, 5 * Time.deltaTime);
        }
        else if(distanceToNet.magnitude <= circleDistance && !dashing)
        {
            if (rotating)
            {
                transform.RotateAround(net.transform.position, new Vector3(0, 0, 1), 100 * Time.deltaTime);
            }
            transform.position = Vector2.MoveTowards(transform.position, net.transform.position, -(5 * Time.deltaTime));
            startTimer = true;
        }
    }

    IEnumerator Dash()
    {
        dashing = true;
        rotating = false;
        yield return new WaitForSeconds(2.0f);
        gameObject.GetComponent<Rigidbody2D>().velocity = distanceNormalized * 20;
        canBeDestroyed = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "Net":
                //Stop the net working not 100% sure exactly to what degree we wanna stop it working
                break;
        }
    }
}
