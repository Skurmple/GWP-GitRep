using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public TrashNet player;
    int previousScore;
    Vector3 largeTextScale = new Vector3(2, 2, 2);
    Vector3 smallTextScale = new Vector3(1, 1, 1);
    public Text scoreText;
    public Text scoreDrop;

    //public Text plasticTrashUI;
    //public Text metalTrashUI;
    //public Text glassTrashUI;
    //public Text timerUI;
    //public Text timerDrop;

    //public float timer = 60;
    //public bool timerIsRunning;

    public GameObject GamePlay, GameWon;
    List<GameObject> trashItems = new List<GameObject>();
    GameObject drone;
    CrustSpawner crustGone;

    public void Start()
    {
        //timerIsRunning = false;
        previousScore = player.score;
        drone = GameObject.Find("Drone");
        crustGone = GameObject.Find("TrashCrust").gameObject.GetComponent<CrustSpawner>();
    }

    public void Update()
    {
        if (previousScore != player.score)
        {
            StartCoroutine(ScorePop(0.5f));
            previousScore = player.score;
        }

        scoreText.text = player.score.ToString();
        scoreDrop.text = player.score.ToString();

        if (player.score >= 100)
        {
            Invoke("NextLevel", 5);
        }
        else
        {
            CancelInvoke("NextLevel");
        }

        //Timer code, may be useful later
        //if (crustGone.crustCleaned)
        //{
        //    timerIsRunning = true;
        //}
        //else
        //{
        //    timerIsRunning = false;
        //    timer = 60;
        //}
        //if (timerIsRunning)
        //{
        //    if (timer > 0)
        //    {
        //        timer -= Time.deltaTime;
        //        DisplayTime(timer);
        //    }
        //    else
        //    {
        //        timer = 0;
        //        timerIsRunning = false;
        //        timerUI.text = null;
        //        timerDrop.text = null;
        //    }
        //}
    }

    private void NextLevel()
    {
        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "Stage 2"));
    }
    IEnumerator ScorePop(float duration)
    {
        float time = 0;

        while (time < duration)
        {
            scoreText.gameObject.transform.localScale = Vector3.Lerp(smallTextScale, largeTextScale, time / duration);
            scoreDrop.gameObject.transform.localScale = Vector3.Lerp(smallTextScale, largeTextScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        time = 0;

        while (time < duration)
        {
            scoreText.gameObject.transform.localScale = Vector3.Lerp(largeTextScale, smallTextScale, time / duration);
            scoreDrop.gameObject.transform.localScale = Vector3.Lerp(largeTextScale, smallTextScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
    }

    //private void DisplayTime(float timer)
    //{
    //    float minutes = Mathf.FloorToInt(timer / 60);
    //    float seconds = Mathf.FloorToInt(timer % 60);

    //    timerUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    //    timerDrop.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    //}

    public void StartEndGame()
    {
        StartCoroutine(EndGame());
    }
    private void LostGame()
    {
        StartCoroutine(LostEndGame());
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3f);

        foreach (GameObject trashToAdd in GameObject.FindGameObjectsWithTag("PlasticTrash"))
        {
            trashItems.Add(trashToAdd);
        }
        foreach (GameObject trashToAdd in GameObject.FindGameObjectsWithTag("MetalTrash"))
        {
            trashItems.Add(trashToAdd);
        }
        foreach (GameObject trashToAdd in GameObject.FindGameObjectsWithTag("GlassTrash"))
        {
            trashItems.Add(trashToAdd);
        }
        foreach (GameObject trashToAdd in GameObject.FindGameObjectsWithTag("TrashCrust"))
        {
            trashItems.Add(trashToAdd);
        }

        for (int i = 0; i < trashItems.Count; i++)
        {
            Destroy(trashItems[i]);
        }

        Time.timeScale = 0;

        drone.transform.position = new Vector3(-6, 20, 0);
        drone.transform.rotation = Quaternion.identity;
        GamePlay.SetActive(false);
        GameWon.SetActive(true);
    }

    IEnumerator LostEndGame()
    {
        yield return new WaitForSeconds(9f);

        Time.timeScale = 0;

        GamePlay.SetActive(false);
    }
}
