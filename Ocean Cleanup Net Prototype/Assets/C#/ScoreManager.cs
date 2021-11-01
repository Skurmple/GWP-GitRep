using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public TrashNet player;
    //public Text scoreUI;
    public Text plasticTrashUI;
    public Text metalTrashUI;
    public Text glassTrashUI;

    public TrashNet trashNet;
    public GameObject netCounter0, netCounter1, netCounter2, netCounter3, netCounter4, netCounter5;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitToMenu();
        }

        //scoreUI.text = player.score.ToString();
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
                break;
            case 2:
                netCounter1.SetActive(false);
                netCounter2.SetActive(true);
                break;
            case 3:
                netCounter2.SetActive(false);
                netCounter3.SetActive(true);
                break;
            case 4:
                netCounter3.SetActive(false);
                netCounter4.SetActive(true);
                break;
            case 5:
                netCounter4.SetActive(false);
                netCounter5.SetActive(true);
                break;
        }
    }

    private void ExitToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
