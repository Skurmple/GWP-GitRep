using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{

    Animator animator;

    public bool opened;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (!opened)
            {
                animator.SetBool("Opened", true);
                opened = true;
            }
            else if (opened)
            {
                animator.SetBool("Opened", false);
                opened = false;
            }
        } 
    }
}