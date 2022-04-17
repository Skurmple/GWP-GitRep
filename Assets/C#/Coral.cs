using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coral : MonoBehaviour
{
    public int coralHealth = 2;
    int previousHealth;

    public TrashNet trashNet;

    public SpriteRenderer[] coral1Array, coral2Array, coral3Array, coral4Array, coral5Array;
    SpriteRenderer[][] allCoralArrays = new SpriteRenderer[5][];
    public Sprite[] coralSprites;
    public bool spriteChange;

    // Start is called before the first frame update
    void Start()
    {
        allCoralArrays[0] = coral1Array;
        allCoralArrays[1] = coral2Array;
        allCoralArrays[2] = coral3Array;
        allCoralArrays[3] = coral4Array;
        allCoralArrays[4] = coral5Array;
        spriteChange = true;
        previousHealth = coralHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(previousHealth!= coralHealth)
        {
            spriteChange = true;
            previousHealth = coralHealth;
        }
        else
        {
            previousHealth = coralHealth;
        }

        switch (coralHealth)
        {
            case 1:
            case 2:
                if (spriteChange)
                {
                    foreach (SpriteRenderer[] srs in allCoralArrays)
                    {
                        foreach (SpriteRenderer sr in srs)
                        {
                            switch (sr.sprite.name.Substring(5, 1))
                            {
                                case "1":
                                    sr.sprite = coralSprites[3];
                                    break;

                                case "2":
                                    sr.sprite = coralSprites[7];
                                    break;

                                case "3":
                                    sr.sprite = coralSprites[11];
                                    break;

                                case "4":
                                    sr.sprite = coralSprites[15];
                                    break;

                                case "5":
                                    sr.sprite = coralSprites[19];
                                    break;
                            }
                        }
                    }
                }
                spriteChange = false;
                break;


            case 3:
            case 4:
                if (spriteChange)
                { 
                    foreach (SpriteRenderer[] srs in allCoralArrays)
                    {
                        foreach (SpriteRenderer sr in srs)
                        {
                            switch (sr.sprite.name.Substring(5, 1))
                            {
                                case "1":
                                    sr.sprite = coralSprites[2];
                                    break;

                                case "2":
                                    sr.sprite = coralSprites[6];
                                    break;

                                case "3":
                                    sr.sprite = coralSprites[10];
                                    break;

                                case "4":
                                    sr.sprite = coralSprites[14];
                                    break;

                                case "5":
                                    sr.sprite = coralSprites[18];
                                    break;
                            }
                        }
                    }
                }
                spriteChange = false;
                break;

            case 5:
            case 6:
                if (spriteChange)
                {
                    foreach (SpriteRenderer[] srs in allCoralArrays)
                    {
                        foreach (SpriteRenderer sr in srs)
                        {
                            switch (sr.sprite.name.Substring(5, 1))
                            {
                                case "1":
                                    sr.sprite = coralSprites[1];
                                    break;

                                case "2":
                                    sr.sprite = coralSprites[5];
                                    break;

                                case "3":
                                    sr.sprite = coralSprites[9];
                                    break;

                                case "4":
                                    sr.sprite = coralSprites[13];
                                    break;

                                case "5":
                                    sr.sprite = coralSprites[17];
                                    break;
                            }
                        }
                    }
                }
                spriteChange = false;
                break;

            case 7:
            case >=8:
                if (spriteChange)
                {
                    foreach (SpriteRenderer[] srs in allCoralArrays)
                    {
                        foreach (SpriteRenderer sr in srs)
                        {
                            switch (sr.sprite.name.Substring(5, 1))
                            {
                                case "1":
                                    sr.sprite = coralSprites[0];
                                    break;

                                case "2":
                                    sr.sprite = coralSprites[4];
                                    break;

                                case "3":
                                    sr.sprite = coralSprites[8];
                                    break;

                                case "4":
                                    sr.sprite = coralSprites[12];
                                    break;

                                case "5":
                                    sr.sprite = coralSprites[16];
                                    break;
                            }
                        }
                    }
                }
                spriteChange = false;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!trashNet.trashList.Contains(collision.gameObject))
        {
            switch (collision.gameObject.tag)
            {
                case "MetalTrash":
                case "GlassTrash":
                case "PlasticTrash":
                    //Trash hitting the coral will decrease the score
                    trashNet.score--;


                    //Allows for trash to damage coral, may want this in the future
                    //if(coralHealth >= 1)
                    //{
                    //    coralHealth -= 1;
                    //}
                    
                    break;
            }
        }
    }
}
