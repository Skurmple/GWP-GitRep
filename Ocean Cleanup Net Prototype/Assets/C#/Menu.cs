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
    public GameObject settingsMenu;

    public void PlayStage1()
    {
        SceneManager.LoadScene("Stage 1");
        Time.timeScale = 1;
    }

    public void PlayStage2()
    {
        SceneManager.LoadScene("Stage 2");
        Time.timeScale = 1;
    }

    public void PlayStage3()
    {
        SceneManager.LoadScene("Stage 3");
        Time.timeScale = 1;
    }
    public void CavesTest()
    {
        SceneManager.LoadScene("CavesTest");
        Time.timeScale = 1;
    }

    public void Help()
    {
        mainMenu.SetActive(false);
        helpMenu.SetActive(true);
        creditMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        helpMenu.SetActive(false);
        creditMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void CreditMenu()
    {
        mainMenu.SetActive(false);
        helpMenu.SetActive(false);
        creditMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void SettingsMenu()
    {
        mainMenu.SetActive(false);
        helpMenu.SetActive(false);
        creditMenu.SetActive(false);
        settingsMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void InGameSettings()
    {
        settingsMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseInGameSettings()
    {
        settingsMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
}