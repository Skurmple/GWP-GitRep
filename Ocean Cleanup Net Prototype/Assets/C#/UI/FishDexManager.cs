using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishDexManager : MonoBehaviour
{
    public Image Nautilus_NotScanned;
    public Sprite Nautilus_Scanned;

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
    public Text seaTurtle;
    public Text salmon;
    public Text pufferfish;
    public Text anglerfish;
    public Text swordfish;

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
            SeaTurtle_NotScanned.sprite = SeaTurtle_Scanned;
            seaTurtle.text = "Sea Turtle";
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
            SwordFish_NotScanned.sprite = Swordfish_Scanned;
            swordfish.text = "Swordfish";
        }

    }
}
