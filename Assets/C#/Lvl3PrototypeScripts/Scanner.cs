using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public GameObject spotlight;
    public Emotions emotions;
    FishDexManager fdm;
    ScoreManager scoreManager;
    int o = 0, c = 0, a = 0, s = 0, l = 0, numScanned = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("FishDexManager") != null)
        {
            fdm = GameObject.Find("FishDexManager").GetComponent<FishDexManager>();
        }
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Scannable")
        {
            collision.gameObject.GetComponent<ScannableFish>().beingScanned = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Scannable")
        {
            if(collision.gameObject.GetComponent<ScannableFish>().scanProgress < 100 && !collision.gameObject.GetComponent<ScannableFish>().finishedScanning)
            {
                collision.gameObject.GetComponent<ScannableFish>().scanProgress += 1.5f;
                spotlight.GetComponent<SpriteRenderer>().color = new Vector4(0.7f, 1, 0.7f, 1);
            }
            else if(collision.gameObject.GetComponent<ScannableFish>().scanProgress >= 100 && !collision.gameObject.GetComponent<ScannableFish>().finishedScanning)
            {
                numScanned++;
                scoreManager.scoreText.text = numScanned.ToString() + "/8";
                scoreManager.scoreDrop.text = numScanned.ToString() + "/8";
                scoreManager.ScorePop(2.5f);

                spotlight.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
                emotions.HappyFace();
                collision.gameObject.GetComponent<ScannableFish>().finishedScanning = true;

                if (collision.gameObject.name.Contains("Oarfish") && fdm.hasScanned[0] == false)
                {
                    o++;
                    if(o >= 3)
                    {
                        fdm.hasScanned[0] = true;
                    }
                }
                else if (collision.gameObject.name.Contains("Catshark") && fdm.hasScanned[1] == false)
                {
                    c++;
                    if(c >= 2)
                    {
                        fdm.hasScanned[1] = true;
                    }
                }
                else if (collision.gameObject.name.Contains("Anglerfish") && fdm.hasScanned[2] == false)
                {
                    a++;
                    if(a >= 3)
                    {
                        fdm.hasScanned[2] = true;
                    }
                }
                else if (collision.gameObject.name.Contains("Squid") && fdm.hasScanned[3] == false)
                {
                    s++;
                    if(s >= 2)
                    {
                        fdm.hasScanned[3] = true;
                    }
                }
                else if (collision.gameObject.name.Contains("Loosejaw") && fdm.hasScanned[4] == false)
                {
                    l++;
                    if(l >= 2)
                    {
                        fdm.hasScanned[4] = true;
                    }
                }

                if(numScanned == 8)
                {
                    //Put win stuff here
                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Scannable")
        {
            spotlight.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
        }
    }
}
