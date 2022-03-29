using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FishDexManager : MonoBehaviour
{
    //Level 1
    public Image AtlanticSalmon;
    public Image Otter;
    public Image JellyFish;
    public Image Ling;
    public Image RedFish;
    public Image Saithe;

    /*
    public Image Polychaete;
    public Image Catshark;
    public Image Octopus;
    public Image Starfish;
    public Image Shrimp;                IGNORE FOR NOW     Still have to decide which creatures go where
    public Image FeatherStar;
    public Image SeaFan;
    public Image Sponge;
    public Image SeaAnemone;
    */

    //Level 2
    public Image Seal;
    public Image KillerWhale;
    public Image BaskingShark;
    public Image Dolphin;

    //Level 3
    public Image Oarfish;
    public Image Alicella;
    public Image AnglerFish;

    //checks to see if the fish has been selected or scaneed
    public bool[] hasScanned;
    public bool[] fishSelected;

    //UI Screens GameObjects
    public GameObject LevelSelective;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;

    //text in front of sea creature images
    public GameObject[] headings;

    private void Update()
    {
        DiscoveryOfSpecies();
        ScannedFish();
    }

    //opening & closing the menus
    public void Level_1()
    {
        Level1.SetActive(true);
        Level2.SetActive(false);
        Level3.SetActive(false);
        LevelSelective.SetActive(false);
    }
    public void Level_2()
    {
        Level1.SetActive(false);
        Level2.SetActive(true);
        Level3.SetActive(false);
        LevelSelective.SetActive(false);
    }
    public void Level_3()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(true);
        LevelSelective.SetActive(false);
    }
    public void Back()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        LevelSelective.SetActive(true);
    }

    public void DiscoveryOfSpecies()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            AtlanticSalmon.color = new Color32(255, 255, 255, 255);
            Otter.color = new Color32(255, 255, 255, 255);
            JellyFish.color = new Color32(255, 255, 255, 255);
            Ling.color = new Color32(255, 255, 255, 255);
            RedFish.color = new Color32(255, 255, 255, 255);
            Saithe.color = new Color32(255, 255, 255, 255);

            /*
            Polychaete.color = new Color32(255, 255, 255, 255);
            Catshark.color = new Color32(255, 255, 255, 255);
            Octopus.color = new Color32(255, 255, 255, 255);
            Starfish.color = new Color32(255, 255, 255, 255);
            Shrimp.color = new Color32(255, 255, 255, 255);                 AGAIN IGNORE
            FeatherStar.color = new Color32(255, 255, 255, 255);
            SeaFan.color = new Color32(255, 255, 255, 255);
            Sponge.color = new Color32(255, 255, 255, 255);
            SeaAnemone.color = new Color32(255, 255, 255, 255);
            */

            headings[0].GetComponent<Text>().text = "Salmon";
            headings[1].GetComponent<Text>().text = "Otter";
            headings[2].GetComponent<Text>().text = "Jellyfish";
            headings[3].GetComponent<Text>().text = "Ling";
            headings[4].GetComponent<Text>().text = "Redfish";
            headings[5].GetComponent<Text>().text = "Saithe";

        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Seal.color = new Color32(255, 255, 255, 255);
            KillerWhale.color = new Color32(255, 255, 255, 255);
            BaskingShark.color = new Color32(255, 255, 255, 255);
            Dolphin.color = new Color32(255, 255, 255, 255);

            headings[6].GetComponent<Text>().text = "Seal";
            headings[7].GetComponent<Text>().text = "Killer Whale";
            headings[8].GetComponent<Text>().text = "Basking Shark";
            headings[9].GetComponent<Text>().text = "Dolphin";
        }
    }
    private void ScannedFish()
    {
        if (hasScanned[0])
        {
            Oarfish.color = new Color32(255, 255, 255, 255);
            headings[10].GetComponent<Text>().text = "Oarfish";
        }
        if (hasScanned[1])
        {
            Alicella.color = new Color32(255, 255, 255, 255);
            headings[11].GetComponent<Text>().text = "Alicella";
        }
        if (hasScanned[2])
        {
            AnglerFish.color = new Color32(255, 255, 255, 255);
            headings[12].GetComponent<Text>().text = "AnglerFish";
        }
    }


}
