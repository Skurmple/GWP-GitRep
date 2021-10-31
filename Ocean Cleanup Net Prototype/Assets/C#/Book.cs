using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{

    Animator animator;

    [SerializeField] int pageNumberBefore;
    [SerializeField] int pageNumberAfter;

    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;

    void Start()
    {
        pageNumberBefore = 1;
        pageNumberAfter = 1;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(pageNumberBefore == 1)
        {
            if(pageNumberAfter == 1) { page1.SetActive(true); }
            page2.SetActive(false);
            page3.SetActive(false);
            page4.SetActive(false);
        }
        if (pageNumberBefore == 2)
        {
            if (pageNumberAfter == 2) { page2.SetActive(true); }
            page1.SetActive(false);
            page3.SetActive(false);
            page4.SetActive(false);
        }
        if (pageNumberBefore == 3)
        {
            if (pageNumberAfter == 3) { page3.SetActive(true); }
            page1.SetActive(false);
            page2.SetActive(false);
            page4.SetActive(false);
        }
        if (pageNumberBefore == 4)
        {
            if (pageNumberAfter == 4) { page4.SetActive(true); }
            page1.SetActive(false);
            page3.SetActive(false);
            page2.SetActive(false);
        }
    }

    public void BookStartAnimation()
    {
        animator.SetBool("Flip", true);
        pageNumberBefore++;
    }

    void BookStopAnimation()
    {
        animator.SetBool("Flip", false);
        pageNumberAfter++;
    }

    public void BookStartAnimation2()
    {
        animator.SetBool("ReverseFlip", true);
        pageNumberBefore--;
    }
    void BookStopAnimation2()
    {
        animator.SetBool("ReverseFlip", false);
        pageNumberAfter--;
    }

}
