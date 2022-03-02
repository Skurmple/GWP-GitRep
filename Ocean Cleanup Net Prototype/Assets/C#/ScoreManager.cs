using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public TrashNet player;
    public Text scoreUI;
    public Text scoreDrop;
    //public Text plasticTrashUI;
    //public Text metalTrashUI;
    //public Text glassTrashUI;
    //public Text timerUI;
    //public Text timerDrop;

    //public float timer = 60;
    //public bool timerIsRunning;

    public Coral coral;
    public GameObject GamePlay, GameWon;
    GameObject drone;
    CrustSpawner crustGone;

    public void Start()
    {
        //timerIsRunning = false;
        drone = GameObject.Find("Drone");
        crustGone = GameObject.Find("TrashCrust").gameObject.GetComponent<CrustSpawner>();
    }
    public void Update()
    {
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

        if (coral.coralHealth >= 8)
        {
            StartEndGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitToMenu();
        }

        scoreUI.text = player.score.ToString();
        scoreDrop.text = player.score.ToString();
        //plasticTrashUI.text = player.plasticTrashAmt.ToString();
        //metalTrashUI.text = player.metalTrashAmt.ToString();
        //glassTrashUI.text = player.glassTrashAmt.ToString();

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

        Time.timeScale = 0;

        drone.transform.position = new Vector3(-6, 10, 0);
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

    public void ExitToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
