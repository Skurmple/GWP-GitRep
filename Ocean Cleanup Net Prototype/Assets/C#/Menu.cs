using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    int sceneBuildIndex;

    public GameObject mainMenu;
    public GameObject helpMenu;
    public GameObject creditMenu;

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void PlayLvl3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        Time.timeScale = 1;
    }

    public void Help()
    {
        mainMenu.SetActive(false);
        helpMenu.SetActive(true);
        creditMenu.SetActive(false);
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        helpMenu.SetActive(false);
        creditMenu.SetActive(false);
    }

    public void CreditMenu()
    {
        mainMenu.SetActive(false);
        helpMenu.SetActive(false);
        creditMenu.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}