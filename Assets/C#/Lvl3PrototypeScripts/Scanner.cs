using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public GameObject spotlight;
    public Emotions emotions;
    FishDexManager fdm;
    ScoreManager scoreManager;
    int o = 0, c = 0, a = 0, s = 0, l = 0, sw = 0, wf = 0, hv = 0, numScanned = 0, numPrevScanned;

    // Start is called before the first frame update
    void Start()
    {
        numPrevScanned = numScanned;
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

            if (!collision.gameObject.GetComponent<ScannableFish>().finishedScanning)
            {
                FindObjectOfType<AudioManager>().Play("Scanning");
            }
        }
    }

    void Update()
    {
        scoreManager.scoreText.text = numScanned.ToString() + "/8";
        scoreManager.scoreDrop.text = numScanned.ToString() + "/8";

        Debug.Log(a);

        if (numPrevScanned != numScanned)
        {
            scoreManager.ScorePop(2.5f);
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
                spotlight.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
                emotions.HappyFace();
                collision.gameObject.GetComponent<ScannableFish>().finishedScanning = true;
                FindObjectOfType<AudioManager>().Play("ScanSuccess");

                if (collision.gameObject.name.Contains("Oarfish") && fdm.hasScanned[0] == false)
                {
                    o++;
                    if(o >= 3)
                    {
                        fdm.hasScanned[0] = true;
                        numScanned++;
                    }
                }
                else if (collision.gameObject.name.Contains("Catshark") && fdm.hasScanned[1] == false)
                {
                    c++;
                    if(c >= 2)
                    {
                        fdm.hasScanned[1] = true;
                        numScanned++;
                    }
                }
                else if (collision.gameObject.name.Contains("AnglerFish") && fdm.hasScanned[2] == false)
                {
                    a++;
                    if(a >= 3)
                    {
                        fdm.hasScanned[2] = true;
                        numScanned++;
                    }
                }
                else if (collision.gameObject.name.Contains("Squid") && fdm.hasScanned[3] == false)
                {
                    s++;
                    if(s >= 2)
                    {
                        fdm.hasScanned[3] = true;
                        numScanned++;
                    }
                }
                else if (collision.gameObject.name.Contains("Loosejaw") && fdm.hasScanned[4] == false)
                {
                    l++;
                    if(l >= 2)
                    {
                        fdm.hasScanned[4] = true;
                        numScanned++;
                    }
                }
                else if (collision.gameObject.name.Contains("SubmarineWreck") && fdm.hasScanned[5] == false)
                {
                    sw++;
                    if (sw >= 1)
                    {
                        fdm.hasScanned[5] = true;
                        numScanned++;
                    }
                }
                else if (collision.gameObject.name.Contains("WhaleFall") && fdm.hasScanned[6] == false)
                {
                    wf++;
                    if (wf >= 1)
                    {
                        fdm.hasScanned[6] = true;
                        numScanned++;
                    }
                }
                else if (collision.gameObject.name.Contains("Hydrothermal") && fdm.hasScanned[7] == false)
                {
                    hv++;
                    if (hv >= 3)
                    {
                        fdm.hasScanned[7] = true;
                        numScanned++;
                    }
                }

                if (numScanned == 8)
                {
                    scoreManager.Invoke("NextLevel", 3f);
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
