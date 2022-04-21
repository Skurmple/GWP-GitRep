using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emotions : MonoBehaviour
{
    public Sprite[] emotionSprites;
    public GameObject drone;

    [SerializeField]
    GameObject greenEyes = null;

    [SerializeField]
    GameObject pinkEyes = null;

    public TrashNet trashNet;
    int netLimit = 7;
    bool waitT;

    // Start is called before the first frame update
    void Start()
    {
        waitT = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (waitT == false && trashNet.trashList.Count < netLimit && drone.GetComponent<SpriteRenderer>().sprite != emotionSprites[0])
        {
            drone.GetComponent<SpriteRenderer>().sprite = emotionSprites[0];
            greenEyes.SetActive(true);
            pinkEyes.SetActive(false);
        }

        if (waitT == false && trashNet.trashList.Count == netLimit)
        {
            drone.GetComponent<SpriteRenderer>().sprite = emotionSprites[1];

        }

    }

    public void SadFace()
    {
        waitT = true;
        drone.GetComponent<SpriteRenderer>().sprite = emotionSprites[2];
        StartCoroutine(Timer());
    }

    public void HappyFace()
    {
        waitT = true;
        drone.GetComponent<SpriteRenderer>().sprite = emotionSprites[3];
        greenEyes.SetActive(false);
        pinkEyes.SetActive(true);

        //FindObjectOfType<AudioManager>().Play("FullNet");

        StartCoroutine(Timer());
    }

    public void StunnedFace()
    {
        greenEyes.SetActive(false);
        pinkEyes.SetActive(false);
        waitT = true;
        drone.GetComponent<SpriteRenderer>().sprite = emotionSprites[4];
        StartCoroutine(StunTimer());
    }


    //timers
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.0f);
        waitT = false;
    }

    private IEnumerator StunTimer()
    {
        yield return new WaitForSeconds(2.3f);
        waitT = false;
    }


        
}
