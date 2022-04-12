using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oarfish : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject rotatePoint;
    float rotationDirection;

    // Start is called before the first frame update
    void Start()
    {
        rotatePoint = GameObject.Find("OarfishPOI");
        rotationDirection = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.RotateAround(rotatePoint.transform.position, new Vector3(0, 0, rotationDirection), rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Environment":
                rotationDirection *= -1;
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                break;
        }
    }
}
