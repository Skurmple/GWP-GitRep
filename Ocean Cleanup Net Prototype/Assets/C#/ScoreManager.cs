using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public TrashNet player;
    public Text scoreUI;
    public Text trashUI;
    public Text plasticTrashUI;
    public Text metalTrashUI;
    public Text glassTrashUI;


    public void Update()
    {
        scoreUI.text = "Score: " + player.score.ToString();
        trashUI.text = "Trash in Net: " + player.trashList.Count.ToString() + "/5";
        plasticTrashUI.text = "Plastic: " + player.plasticTrashAmt.ToString();
        metalTrashUI.text = "Metal: " + player.metalTrashAmt.ToString();
        glassTrashUI.text = "Glass: " + player.glassTrashAmt.ToString();
    }
}
