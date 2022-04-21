using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class FishDexManager : MonoBehaviour
{
    //Level 1
    public Image AtlanticSalmon;
    public Image Otter;
    public Image JellyFish;
    public Image Ling;
    public Image RedFish;
    public Image Octopus;

    //Level 2
    public Image Seal;
    public Image KillerWhale;
    public Image BaskingShark;
    public Image Dolphin;
    public Image Shrimp;
    public Image Saithe;

    //Level 3
    public Image Oarfish;
    public Image Catshark;
    public Image AnglerFish;
    public Image Squid;
    public Image LooseJaw;

    //Habitats
    public Image SubWreck;
    public Image WhaleFall;
    public Image Vent;

    //checks youve loaded into the scene
    public bool hasLoadedScene1;
    public bool hasLoadedScene2;

    //checks to see if the fish has been selected or scaneed
    public bool[] hasScanned;
    public bool[] fishSelected;

    //UI Screens GameObjects
    public GameObject LevelSelective;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Habitats;
    public GameObject AdditionalInfo;

    //text in front of sea creature images
    public GameObject[] headings;

    //information for each sea creature
    public GameObject[] information;

    public GameObject tablet;
    int timer;
    private void Start()
    {
        timer = 1;
    }
    private void Update()
    {
        DiscoveryOfSpecies();
        ScannedFish();
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            OpenFishipedia();
        }
    }

    public void OpenFishipedia()
    {
        tablet.SetActive(!tablet.activeSelf);

        if (timer == 0)
        {
            timer = 1;
        }
        else if (timer == 1)
        {
            timer = 0;
        }
        Time.timeScale = timer;
    }

    //opening & closing the menus
    public void Level_1()
    {
        Level1.SetActive(true);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Habitats.SetActive(false);
        AdditionalInfo.SetActive(false);
        LevelSelective.SetActive(false);
    }
    public void Level_2()
    {
        Level1.SetActive(false);
        Level2.SetActive(true);
        Level3.SetActive(false);
        Habitats.SetActive(false);
        AdditionalInfo.SetActive(false);
        LevelSelective.SetActive(false);
    }
    public void Level_3()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(true);
        Habitats.SetActive(false);
        AdditionalInfo.SetActive(false);
        LevelSelective.SetActive(false);
    }
    public void Habitats_()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Habitats.SetActive(true);
        AdditionalInfo.SetActive(false);
        LevelSelective.SetActive(false);
    }
    public void Additional_Info()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Habitats.SetActive(false);
        AdditionalInfo.SetActive(true);
        LevelSelective.SetActive(false);
    }
    public void Back()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Habitats.SetActive(false);
        AdditionalInfo.SetActive(false);
        LevelSelective.SetActive(true);
        information[0].SetActive(false);
        information[1].SetActive(false);
        information[2].SetActive(false);
    }
    public void BackFromLevel1()
    {
        Level1.SetActive(true);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Habitats.SetActive(false);
        AdditionalInfo.SetActive(false);
        LevelSelective.SetActive(false);
        information[0].SetActive(false);
        information[1].SetActive(false);
        information[2].SetActive(false);
        information[3].SetActive(false);
        information[4].SetActive(false);
        information[5].SetActive(false);
    }
    public void BackFromLevel2()
    {
        Level1.SetActive(false);
        Level2.SetActive(true);
        Level3.SetActive(false);
        Habitats.SetActive(false);
        AdditionalInfo.SetActive(false);
        LevelSelective.SetActive(false);
        information[6].SetActive(false);
        information[7].SetActive(false);
        information[8].SetActive(false);
        information[9].SetActive(false);
        information[10].SetActive(false);
        information[11].SetActive(false);
    }
    public void BackFromLevel3()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(true);
        Habitats.SetActive(false);
        AdditionalInfo.SetActive(false);
        LevelSelective.SetActive(false);
        information[12].SetActive(false);
        information[13].SetActive(false);
        information[14].SetActive(false);
        information[15].SetActive(false);
        information[16].SetActive(false);
    }
    public void BackFromHabitats()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Habitats.SetActive(true);
        AdditionalInfo.SetActive(false);
        LevelSelective.SetActive(false);
        information[17].SetActive(false);
        information[18].SetActive(false);
        information[19].SetActive(false);
    }
    public void BackFromAdditionalInfo()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Habitats.SetActive(false);
        AdditionalInfo.SetActive(true);
        LevelSelective.SetActive(false);
        information[20].SetActive(false);
        information[21].SetActive(false);
        information[22].SetActive(false);
        information[23].SetActive(false);
        information[24].SetActive(false);
    }
    public void DiscoveryOfSpecies()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (PlayerPrefs.GetInt("loadedLevel1") == 1)
            {
                AtlanticSalmon.color = new Color32(255, 255, 255, 255);
                Otter.color = new Color32(255, 255, 255, 255);
                JellyFish.color = new Color32(255, 255, 255, 255);
                Ling.color = new Color32(255, 255, 255, 255);
                RedFish.color = new Color32(255, 255, 255, 255);
                Octopus.color = new Color32(255, 255, 255, 255);

                headings[0].GetComponent<Text>().text = "Salmon";
                headings[1].GetComponent<Text>().text = "Otter";
                headings[2].GetComponent<Text>().text = "Jellyfish";
                headings[3].GetComponent<Text>().text = "Ling";
                headings[4].GetComponent<Text>().text = "Redfish";
                headings[5].GetComponent<Text>().text = "Octopus";
                hasLoadedScene1 = true;
            }
            if (PlayerPrefs.GetInt("loadedLevel2") == 1)
            {
                Seal.color = new Color32(255, 255, 255, 255);
                KillerWhale.color = new Color32(255, 255, 255, 255);
                BaskingShark.color = new Color32(255, 255, 255, 255);
                Dolphin.color = new Color32(255, 255, 255, 255);
                Shrimp.color = new Color32(255, 255, 255, 255);
                Saithe.color = new Color32(255, 255, 255, 255);

                headings[6].GetComponent<Text>().text = "Seal";
                headings[7].GetComponent<Text>().text = "Orca";
                headings[8].GetComponent<Text>().text = "Dolphin";
                headings[9].GetComponent<Text>().text = "Basking Shark";
                headings[10].GetComponent<Text>().text = "Shrimp";
                headings[11].GetComponent<Text>().text = "Saithe";
                hasLoadedScene2 = true;
            }
            if (PlayerPrefs.GetInt("scanned1") == 1)
            {
                Oarfish.color = new Color32(255, 255, 255, 255);
                headings[12].GetComponent<Text>().text = "Oarfish";
                hasScanned[0] = true;
            }
            if (PlayerPrefs.GetInt("scanned2") == 1)
            {
                Catshark.color = new Color32(255, 255, 255, 255);
                headings[13].GetComponent<Text>().text = "Catshark";
                hasScanned[1] = true;
            }
            if (PlayerPrefs.GetInt("scanned3") == 1)
            {
                AnglerFish.color = new Color32(255, 255, 255, 255);
                headings[14].GetComponent<Text>().text = "AnglerFish";
                hasScanned[2] = true;
            }
            if (PlayerPrefs.GetInt("scanned4") == 1)
            {
                Squid.color = new Color32(255, 255, 255, 255);
                headings[15].GetComponent<Text>().text = "Squid";
                hasScanned[3] = true;
            }
            if (PlayerPrefs.GetInt("scanned5") == 1)
            {
                LooseJaw.color = new Color32(255, 255, 255, 255);
                headings[16].GetComponent<Text>().text = "Loose Jaw";
                hasScanned[4] = true;
            }
            if (PlayerPrefs.GetInt("scanned6") == 1)
            {
                SubWreck.color = new Color32(255, 255, 255, 255);
                headings[17].GetComponent<Text>().text = "Submarine Wreck";
                hasScanned[5] = true;
            }
            if (PlayerPrefs.GetInt("scanned7") == 1)
            {
                WhaleFall.color = new Color32(255, 255, 255, 255);
                headings[18].GetComponent<Text>().text = "Whalefall";
                hasScanned[6] = true;
            }
            if (PlayerPrefs.GetInt("scanned8") == 1)
            {
                Vent.color = new Color32(255, 255, 255, 255);
                headings[19].GetComponent<Text>().text = "Hydrothermal Vents";
                headings[19].GetComponent<Text>().fontSize = 30;
                hasScanned[7] = true;
            }
        }

        if (SceneManager.GetActiveScene().buildIndex >= 1 && !hasLoadedScene1)
        {
            AtlanticSalmon.color = new Color32(255, 255, 255, 255);
            Otter.color = new Color32(255, 255, 255, 255);
            JellyFish.color = new Color32(255, 255, 255, 255);
            Ling.color = new Color32(255, 255, 255, 255);
            RedFish.color = new Color32(255, 255, 255, 255);
            Octopus.color = new Color32(255, 255, 255, 255);

            headings[0].GetComponent<Text>().text = "Salmon";
            headings[1].GetComponent<Text>().text = "Otter";
            headings[2].GetComponent<Text>().text = "Jellyfish";
            headings[3].GetComponent<Text>().text = "Ling";
            headings[4].GetComponent<Text>().text = "Redfish";
            headings[5].GetComponent<Text>().text = "Octopus";

            hasLoadedScene1 = true;
            PlayerPrefs.SetInt("loadedLevel1", 1);
        }

        if (SceneManager.GetActiveScene().buildIndex >= 2 && !hasLoadedScene2)
        {
            Seal.color = new Color32(255, 255, 255, 255);
            KillerWhale.color = new Color32(255, 255, 255, 255);
            BaskingShark.color = new Color32(255, 255, 255, 255);
            Dolphin.color = new Color32(255, 255, 255, 255);
            Shrimp.color = new Color32(255, 255, 255, 255);
            Saithe.color = new Color32(255, 255, 255, 255);

            headings[6].GetComponent<Text>().text = "Seal";
            headings[7].GetComponent<Text>().text = "Orca";
            headings[8].GetComponent<Text>().text = "Dolphin";
            headings[9].GetComponent<Text>().text = "Basking Shark";
            headings[10].GetComponent<Text>().text = "Shrimp";
            headings[11].GetComponent<Text>().text = "Saithe";

            hasLoadedScene2 = true;
            PlayerPrefs.SetInt("loadedLevel2", 1);
        }
    }
    private void ScannedFish()
    {
        if (hasScanned[0])
        {
            Oarfish.color = new Color32(255, 255, 255, 255);
            headings[12].GetComponent<Text>().text = "Oarfish";
            PlayerPrefs.SetInt("scanned1", 1);
        }
        if (hasScanned[1])
        {
            Catshark.color = new Color32(255, 255, 255, 255);
            headings[13].GetComponent<Text>().text = "Catshark";
            PlayerPrefs.SetInt("scanned2", 1);
        }
        if (hasScanned[2])
        {
            AnglerFish.color = new Color32(255, 255, 255, 255);
            headings[14].GetComponent<Text>().text = "AnglerFish";
            PlayerPrefs.SetInt("scanned3", 1);
        }
        if (hasScanned[3])
        {
            Squid.color = new Color32(255, 255, 255, 255);
            headings[15].GetComponent<Text>().text = "Squid";
            PlayerPrefs.SetInt("scanned4", 1);
        }
        if (hasScanned[4])
        {
            LooseJaw.color = new Color32(255, 255, 255, 255);
            headings[16].GetComponent<Text>().text = "Loose Jaw";
            PlayerPrefs.SetInt("scanned5", 1);
        }
        if (hasScanned[5])
        {
            SubWreck.color = new Color32(255, 255, 255, 255);
            headings[17].GetComponent<Text>().text = "Submarine Wreck";
            PlayerPrefs.SetInt("scanned6", 1);
        }
        if (hasScanned[6])
        {
            WhaleFall.color = new Color32(255, 255, 255, 255);
            headings[18].GetComponent<Text>().text = "Whalefall";
            PlayerPrefs.SetInt("scanned7", 1);
        }
        if (hasScanned[7])
        {
            Vent.color = new Color32(255, 255, 255, 255);
            headings[19].GetComponent<Text>().text = "Hydrothermal Vents";
            headings[19].GetComponent<Text>().fontSize = 30;
            PlayerPrefs.SetInt("scanned8", 1);
        }
    }
    public void OpenSalmon()
    {
        if (hasLoadedScene1)
        {
            information[0].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenOtter()
    {
        if (hasLoadedScene1)
        {
            information[1].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenJellyFish()
    {
        if (hasLoadedScene1)
        {
            information[2].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenLing()
    {
        if (hasLoadedScene1)
        {
            information[3].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenRedFish()
    {
        if (hasLoadedScene1)
        {
            information[4].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false); 
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenOctopus()
    {
        if (hasLoadedScene1)
        {
            information[5].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false); 
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenSeal()
    {
        if (hasLoadedScene2)
        {
            information[6].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenKillerWhale()
    {
        if (hasLoadedScene2)
        {
            information[7].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenBaskingShark()
    {
        if (hasLoadedScene2)
        {
            information[8].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenDolphin()
    {
        if (hasLoadedScene2)
        {
            information[9].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenShrimp()
    {
        if (hasLoadedScene2)
        {
            information[10].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenSaithe()
    {
        if (hasLoadedScene2)
        {
            information[11].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenOarFish()
    {
        if (hasScanned[0])
        {
            information[12].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenCatshark()
    {
        if (hasScanned[1])
        {
            information[13].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenAnglerFish()
    {
        if (hasScanned[2])
        {
            information[14].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenSquid()
    {
        if (hasScanned[3])
        {
            information[15].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenLooseJaw()
    {
        if (hasScanned[4])
        {
            information[16].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenSubWreck()
    {
        if (hasScanned[5])
        {
            information[17].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenWhaleFall()
    {
        if (hasScanned[6])
        {
            information[18].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenVents()
    {
        if (hasScanned[7])
        {
            information[19].SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Habitats.SetActive(false);
            AdditionalInfo.SetActive(false);
            LevelSelective.SetActive(false);
        }
    }
    public void OpenRisingSea()
    {
        information[20].SetActive(true);
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Habitats.SetActive(false);
        AdditionalInfo.SetActive(false);
        LevelSelective.SetActive(false);
    }
    public void OpenCoralExinct()
    {
        information[21].SetActive(true);
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Habitats.SetActive(false);
        AdditionalInfo.SetActive(false);
        LevelSelective.SetActive(false);
    }
    public void OpenCans()
    {
        information[22].SetActive(true);
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Habitats.SetActive(false);
        AdditionalInfo.SetActive(false);
        LevelSelective.SetActive(false);
    }
    public void OpenGlass()
    {
        information[23].SetActive(true);
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Habitats.SetActive(false);
        AdditionalInfo.SetActive(false);
        LevelSelective.SetActive(false);
    }
    public void OpenPlastic()
    {
        information[24].SetActive(true);
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Habitats.SetActive(false);
        AdditionalInfo.SetActive(false);
        LevelSelective.SetActive(false);
    }
}