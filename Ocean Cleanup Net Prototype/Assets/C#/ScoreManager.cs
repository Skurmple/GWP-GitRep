using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public TrashNet player;
    public Text scoreUI;
    public Text trashUI;


    public void Update()
    {
        scoreUI.text = "Score: " + player.score.ToString();
        trashUI.text = "Trash: " + player.trashList.Count.ToString();
    }
}
