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
    public Text plasticTrashUI;
    public Text metalTrashUI;
    public Text glassTrashUI;
    public Text timerUI;

    public float timer = 300;
    public bool timerIsRunning = true;

    public TrashNet trashNet;
    public Coral coral;
    public GameObject netCounter0, netCounter1, netCounter2, netCounter3, netCounter4, netCounter5;
    public GameObject GamePlay, GameWon;
    GameObject drone;

    public void Start()
    {
        drone = GameObject.Find("Drone");
    }
    public void Update()
    {
        if (timerIsRunning)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                DisplayTime(timer);
            }
            else
            {
                //trashTide.SpawnTide();
                //LostGame();
                timer = 0;
                timerIsRunning = false;
            }
        }

        if (coral.coralHealth >= 8)
        {
            StartEndGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitToMenu();
        }

        scoreUI.text = "Score: " + player.score.ToString();
        plasticTrashUI.text = player.plasticTrashAmt.ToString();
        metalTrashUI.text = player.metalTrashAmt.ToString();
        glassTrashUI.text = player.glassTrashAmt.ToString();

        switch (trashNet.trashList.Count)
        {
            case 0:
                netCounter0.SetActive(true);
                netCounter1.SetActive(false);
                netCounter2.SetActive(false);
                netCounter3.SetActive(false);
                netCounter4.SetActive(false);
                netCounter5.SetActive(false);
                break;
            case 1:
                netCounter0.SetActive(false);
                netCounter1.SetActive(true);
                netCounter2.SetActive(false);
                netCounter3.SetActive(false);
                netCounter4.SetActive(false);
                netCounter5.SetActive(false);
                break;
            case 2:
                netCounter0.SetActive(false);
                netCounter1.SetActive(false);
                netCounter2.SetActive(true);
                netCounter3.SetActive(false);
                netCounter4.SetActive(false);
                netCounter5.SetActive(false);
                break;
            case 3:
                netCounter0.SetActive(false);
                netCounter1.SetActive(false);
                netCounter2.SetActive(false);
                netCounter3.SetActive(true);
                netCounter4.SetActive(false);
                netCounter5.SetActive(false);
                break;
            case 4:
                netCounter0.SetActive(false);
                netCounter1.SetActive(false);
                netCounter2.SetActive(false);
                netCounter3.SetActive(false);
                netCounter4.SetActive(true);
                netCounter5.SetActive(false);
                break;
            case 5:
                netCounter0.SetActive(false);
                netCounter1.SetActive(false);
                netCounter2.SetActive(false);
                netCounter3.SetActive(false);
                netCounter4.SetActive(false);
                netCounter5.SetActive(true);
                break;
        }
    }

    private void DisplayTime(float timer)
    {
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        timerUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

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
