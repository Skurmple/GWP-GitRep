using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    //Initialisation of variables to store the Animator, integers to know what page the book is on, and
    //GameObject variables to store each page
    Animator animator;

    [SerializeField] int pageNumberBefore;
    [SerializeField] int pageNumberAfter;

    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;

    void Start()
    {
        //Set the page before and after to the first page
        pageNumberBefore = 1;
        pageNumberAfter = 1;
        //Gets the Animator and stores it
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Series of if statements to check what page the book is on, and to act accordingly

        //Checks if the player is on the first page, and sets the trigger for the animation for that page to true, and sets the other pages to false
        if(pageNumberBefore == 1)
        {
            if(pageNumberAfter == 1) { page1.SetActive(true); }
            page2.SetActive(false);
            page3.SetActive(false);
            page4.SetActive(false);
            page5.SetActive(false);
        }
        //Checks if the player is on the second page, and sets the trigger for the animation for that page to true, and sets the other pages to false
        if (pageNumberBefore == 2)
        {
            if (pageNumberAfter == 2) { page2.SetActive(true); }
            page1.SetActive(false);
            page3.SetActive(false);
            page4.SetActive(false);
            page5.SetActive(false);
        }
        //Checks if the player is on the third page, and sets the trigger for the animation for that page to true, and sets the other pages to false
        if (pageNumberBefore == 3)
        {
            if (pageNumberAfter == 3) { page3.SetActive(true); }
            page1.SetActive(false);
            page2.SetActive(false);
            page4.SetActive(false);
            page5.SetActive(false);
        }
        //Checks if the player is on the fourth page, and sets the trigger for the animation for that page to true, and sets the other pages to false
        if (pageNumberBefore == 4)
        {
            if (pageNumberAfter == 4) { page4.SetActive(true); }
            page1.SetActive(false);
            page3.SetActive(false);
            page2.SetActive(false);
            page5.SetActive(false);
        }
        //Checks if the player is on the fifth page, and sets the trigger for the animation for that page to true, and sets the other pages to false
        if (pageNumberBefore == 5)
        {
            if (pageNumberAfter == 5) { page5.SetActive(true); }
            page1.SetActive(false);
            page3.SetActive(false);
            page2.SetActive(false);
            page4.SetActive(false);
        }
    }

    //Method to start the "page flip to the right" animation, and increase the page number
    public void BookStartAnimation()
    {
        //Sets the trigger for the animation to true to start the animation
        animator.SetBool("Flip", true);
        //Increases the page number
        pageNumberBefore++;
    }

    //Method to stop the "page flip to the right" animation, and increase the number of the next page
    void BookStopAnimation()
    {
        //Sets the trigger for the animation to false to stop the animation
        animator.SetBool("Flip", false);
        //Increases the next page number
        pageNumberAfter++;
    }

    //Same thing as "BookStartAnimation" above, except for the page flipping to the left, and decreasing the page number
    public void BookStartAnimation2()
    {
        animator.SetBool("ReverseFlip", true);
        pageNumberBefore--;
    }

    //Same thing as "BookStopAnimation" above, except for the page flipping to the left, and decreasing the next page number
    void BookStopAnimation2()
    {
        animator.SetBool("ReverseFlip", false);
        pageNumberAfter--;
    }

}
