using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagrass : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        animator.Play("SG", -1, Random.Range(0f, 0.9f));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
