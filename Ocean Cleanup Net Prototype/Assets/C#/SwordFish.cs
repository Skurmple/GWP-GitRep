using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFish : MonoBehaviour
{
    public float circleDistance;
    Vector3 distanceToNet;
    bool aggro;
    GameObject net;
    bool startTimer;
    bool dashing;
    float time;
    bool canBeDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        circleDistance = 7.0f;
        net = GameObject.Find("Net");
        time = 0;
        aggro = false;
    }

    void OnBecameInvisible()
    {
        aggro = false;
    }

    void OnBecameVisible()
    {
        aggro = true;    
    }

    // Update is called once per frame
    void Update()
    {
        distanceToNet = net.transform.position - transform.position;
        transform.right = -distanceToNet.normalized;

        if (!dashing)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        if (startTimer)
        {
            time += Time.deltaTime;
            if(time >= 2.0f)
            {
                StartCoroutine("Dash");
            }
        }
        if (distanceToNet.magnitude > circleDistance && !dashing && aggro)
        {
            transform.position = Vector2.MoveTowards(transform.position, net.transform.position, 5 * Time.deltaTime);
        }
        else if(distanceToNet.magnitude <= circleDistance)
        {
            startTimer = true;
        }
    }

    IEnumerator Dash()
    {
        dashing = true;
        startTimer = false;
        time = 0;
        yield return new WaitForSeconds(2.0f);
        gameObject.GetComponent<Rigidbody2D>().velocity = distanceToNet.normalized * 20;
        yield return new WaitForSeconds(1.5f);
        aggro = false;
        dashing = false;
    }

}
