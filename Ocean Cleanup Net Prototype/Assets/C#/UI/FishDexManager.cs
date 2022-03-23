using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishDexManager : MonoBehaviour
{
    public Image Nautilus_NotScanned;
    public Sprite Nautilus_Scanned;

    public Image Oarfish_NotScanned;
    public Sprite Oarfish_Scanned;

    public Image Salmon_NotScanned;
    public Sprite Salmon_Scanned;

    public Image Pufferfish_NotScanned;
    public Sprite Pufferfish_Scanned;

    public Image AnglerFish_NotScanned;
    public Sprite AnglerFish_Scanned;

    public Image Squid_NotScanned;
    public Sprite Squid_Scanned;

    public Text nautilus;
    public Text oarfish;
    public Text salmon;
    public Text pufferfish;
    public Text anglerfish;
    public Text squid;

    public bool isScanned_0;
    public bool isScanned_1;
    public bool isScanned_2;
    public bool isScanned_3;
    public bool isScanned_4;
    public bool isScanned_5;


    void Update()
    {
        if(isScanned_0)
        {
            Nautilus_NotScanned.sprite = Nautilus_Scanned;
            nautilus.text = "Nautilus";
        } 

        if(isScanned_1)
        {
            Oarfish_NotScanned.sprite = Oarfish_Scanned;
            oarfish.text = "Oarfish";
        }

        if (isScanned_2)
        {
            Salmon_NotScanned.sprite = Salmon_Scanned;
            salmon.text = "Salmon";
        }

        if (isScanned_3)
        {
            Pufferfish_NotScanned.sprite = Pufferfish_Scanned;
            pufferfish.text = "Pufferfish";
        }

        if (isScanned_4)
        {
            AnglerFish_NotScanned.sprite = AnglerFish_Scanned;
            anglerfish.text = "Anglerfish";
        }

        if (isScanned_5)
        {
            Squid_NotScanned.sprite = Squid_Scanned;
            squid.text = "Squid";
        }

    }
}
