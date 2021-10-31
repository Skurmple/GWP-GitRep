using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public bool gamePaused;
    int time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            switch (gamePaused)
            {
                case true:
                        gamePaused = false;
                        Time.timeScale = 1;
                    break;

                case false:
                        gamePaused = true;
                        Time.timeScale = 0;
                    break;
            }
        }
    }
}
