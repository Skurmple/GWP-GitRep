using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishDexManager : MonoBehaviour
{
    public Image Nautilus;
    public Image SeaTurtle;
    public Image Salmon;
    public Image Pufferfish;
    public Image AnglerFish;
    public Image SwordFish;

    public Image SeaTurtle_NotScanned;
    public Sprite SeaTurtle_Scanned;

    public Image Salmon_NotScanned;
    public Sprite Salmon_Scanned;

    public Image Pufferfish_NotScanned;
    public Sprite Pufferfish_Scanned;

    public Image AnglerFish_NotScanned;
    public Sprite AnglerFish_Scanned;

    public Image SwordFish_NotScanned;
    public Sprite Swordfish_Scanned;

    public Text nautilus;
    public Text oarfish;
    public Text salmon;
    public Text pufferfish;
    public Text anglerfish;
    public Text squid;
    public Text seaTurtle;
    public Text swordfish;

    public bool[] hasScanned;

    public GameObject NautilusInfo;
    public GameObject SeaTurtleInfo;

    public GameObject Fishdex;

    public bool[] opened;

    public GameObject DrawingTurtle;
    public GameObject PictureTurtle;

    public GameObject DrawingNautilus;
    public GameObject PictureNautilus;



    void Update()
    {
        DiscoveryOfSpecies();
    }

    public void DiscoveryOfSpecies()
    {
        if (hasScanned[0])
        {
            Nautilus.color = new Color32(255, 255, 255, 255);
            nautilus.text = "Nautilus";
        }
        else
        {
            Nautilus.color = new Color32(0, 0, 0, 100);
        }

        if (hasScanned[1])
        {
            SeaTurtle_NotScanned.sprite = SeaTurtle_Scanned;
            seaTurtle.text = "Sea Turtle";
        }
        else
        {
            SeaTurtle.color = new Color32(0, 0, 0, 100);
        }

        if (hasScanned[2])
        {
            Salmon.color = new Color32(255, 255, 255, 255);
            salmon.text = "Salmon";
        }
        else
        {
            Salmon.color = new Color32(0, 0, 0, 100);
        }

        if (hasScanned[3])
        {
            Pufferfish.color = new Color32(255, 255, 255, 255);
            pufferfish.text = "Pufferfish";
        }
        else
        {
            Pufferfish.color = new Color32(0, 0, 0, 100);
        }

        if (hasScanned[4])
        {
            AnglerFish.color = new Color32(255, 255, 255, 255);
            anglerfish.text = "Anglerfish";
        }
        else
        {
            AnglerFish.color = new Color32(0, 0, 0, 100);
        }

        if (hasScanned[5])
        {
            SwordFish_NotScanned.sprite = Swordfish_Scanned;
            swordfish.text = "Swordfish";
        }
        else
        {
            SwordFish.color = new Color32(0, 0, 0, 100);
        }
    }
    public void BackToFishDex()
    {
        SeaTurtleInfo.SetActive(false);
        NautilusInfo.SetActive(false);
        Fishdex.SetActive(true);

        //sets all to false
        for (int i = 0; i < opened.Length; i++) { opened[i] = false; }
    }

    public void NextOrPrevious()
    {
        if(opened[0])
        {
            DrawingNautilus.SetActive(!DrawingNautilus.activeSelf);
            PictureNautilus.SetActive(!PictureNautilus.activeSelf);
        }
        if(opened[1])
        {
            DrawingTurtle.SetActive(!DrawingTurtle.activeSelf);
            PictureTurtle.SetActive(!PictureTurtle.activeSelf);
        }
    }


    public void OpenNautilus()
    {
        if (hasScanned[0])
        {
            opened[0] = true;
            NautilusInfo.SetActive(true);
            Fishdex.SetActive(false);
        }
    }
    public void OpenSeaTurtle()
    {
        if (hasScanned[1])
        {
            opened[1] = true;
            SeaTurtleInfo.SetActive(true);
            Fishdex.SetActive(false);
        }
    }

}
