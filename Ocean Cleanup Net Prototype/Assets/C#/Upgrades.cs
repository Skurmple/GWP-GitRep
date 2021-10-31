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
        if(!opened)
        {
            if(Input.GetKey(KeyCode.Tab))
            {
                StartCoroutine(Open());
                animator.SetBool("Stay", false);
            }
        } 
        
        if (opened)
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                StartCoroutine(Close());
                animator.SetBool("Stay", false);
            }
        }
    }
    IEnumerator Open()
    {
        animator.SetBool("Opened", true);
        yield return new WaitForSeconds(1.5f);
        opened = true;
        animator.SetBool("Stay", true);
    }
    IEnumerator Close()
    {
        animator.SetBool("Opened", false);
        yield return new WaitForSeconds(1.5f);
        opened = false;
        animator.SetBool("Stay", true);
    }
}