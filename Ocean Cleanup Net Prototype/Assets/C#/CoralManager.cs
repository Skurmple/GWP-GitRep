using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoralManager : MonoBehaviour
{
    //Array of sprites used to increase the trash pile inside the dingy net
    [SerializeField]
    Sprite[] trashPileArray;

    //2 Arrays, one stores the coral reef game objects and the other stores boolean values that turn true when a reef is cleared (No trash touching it)
    [SerializeField]
    GameObject[] coralReefs;

    [SerializeField]
    bool[] reefCleared;

    //Score variables used to display number of cleared reefs on screen
    int previousScore = 0;
    Vector3 largeTextScale = new Vector3(2, 2, 2);
    Vector3 smallTextScale = new Vector3(1, 1, 1);
    public Text scoreText;
    public Text scoreDrop;

    // Start is called before the first frame update
    void Start()
    {
        //Start by making all booleans false
        for (int i = 0; i < coralReefs.Length; i++)
        {
            reefCleared[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //For every coral reef in the array
        for (int i = 0; i < coralReefs.Length; i++)
        {
            //If there is no trash touching the reef turn the respective boolean to true or vice versa
            if (coralReefs[i].GetComponent<CoralTrashSpawner>().gotTrash == false)
            {
                reefCleared[i] = true;
            }
            else if (coralReefs[i].GetComponent<CoralTrashSpawner>().gotTrash == true)
            {
                reefCleared[i] = false;
            }
        }

        //Count how many reefs have been cleared
        int numReefsCleared = Count(reefCleared, true);

        Debug.Log(numReefsCleared);

        //If numReefsCleared has changed
        if (previousScore != numReefsCleared)
        {
            //Coroutine enlarges the text
            StartCoroutine(ScorePop(0.5f));
            previousScore = numReefsCleared;
        }

        //Display numReefsCleared onscreen
        scoreText.text = numReefsCleared.ToString()+"/8";
        scoreDrop.text = numReefsCleared.ToString()+"/8";

        switch (numReefsCleared)
        {
            case < 1:
                GameObject.Find("TrashPile").GetComponent<SpriteRenderer>().sprite = trashPileArray[0];
                break;

            case < 4:
                GameObject.Find("TrashPile").GetComponent<SpriteRenderer>().sprite = trashPileArray[1];
                break;

            case < 6:
                GameObject.Find("TrashPile").GetComponent<SpriteRenderer>().sprite = trashPileArray[2];
                break;

            case >= 6:
                GameObject.Find("TrashPile").GetComponent<SpriteRenderer>().sprite = trashPileArray[3];
                break;
        }

        //Check if all reefs are cleared
        AreReefsClear();

        //If all reefs are clear and stay clear for 5 seconds, advance to next level
        if (AreReefsClear() == true)
        {
            Invoke("NextLevel", 5);
        }
        else
        {
            CancelInvoke("NextLevel");
        }
    }

    private static int Count(bool[] array, bool flag) //array = reefCleared, flag = true
    {
        int value = 0;

        //For every boolean in the reefCleared array, if the boolean is true increment the value
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == flag)
            {
                value++;
            }
        }

        return value;
    }

    private bool AreReefsClear()
    {
        //For every boolean in reefCleared array, if any boolean is false then return false, else return true
        for (int j = 0; j < reefCleared.Length; j++)
        {
            if (reefCleared[j] == false)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator ScorePop(float duration)
    {
        //Smoothly changes the scale of the onscreen text to create a popping effect
        float time = 0;

        while (time < duration)
        {
            scoreText.gameObject.transform.localScale = Vector3.Lerp(smallTextScale, largeTextScale, time / duration);
            scoreDrop.gameObject.transform.localScale = Vector3.Lerp(smallTextScale, largeTextScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        time = 0;

        while (time < duration)
        {
            scoreText.gameObject.transform.localScale = Vector3.Lerp(largeTextScale, smallTextScale, time / duration);
            scoreDrop.gameObject.transform.localScale = Vector3.Lerp(largeTextScale, smallTextScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
    }

    private void NextLevel()
    {
        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "CavesTest"));
    }
}
