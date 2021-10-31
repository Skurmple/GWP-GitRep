using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    int sceneBuildIndex;

    public GameObject mainMenu;
    public GameObject helpMenu;

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Help()
    {
        mainMenu.SetActive(false);
        helpMenu.SetActive(true);
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        helpMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}