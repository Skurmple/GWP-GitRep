using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public TrashNet player;
    public Text scoreUI;
    public Text trashUI;
    public Text redTrashUI;
    public Text greenTrashUI;


    public void Update()
    {
        scoreUI.text = "Score: " + player.score.ToString();
        trashUI.text = "Trash in Net: " + player.trashList.Count.ToString() + "/5";
        redTrashUI.text = "Red Trash:     " + player.redTrashAmt.ToString();
        greenTrashUI.text = "Green Trash:     " + player.greenTrashAmt.ToString();
    }
}
