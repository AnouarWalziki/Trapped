using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenuPage;
    public GameObject HowToPlayMenuPage;

    public GameObject sceneLoader;

    private void Start()
    {
        MainMenuPage.SetActive(true);
        HowToPlayMenuPage.SetActive(false);
    }

    public void Play()
    {
        sceneLoader.GetComponent<SceneLoader>().sceneToLoad = "StartingLevel";
        sceneLoader.GetComponent<SceneLoader>().StartLoad();
    }

    public void LoadMainMenuScene()
    {
        sceneLoader.GetComponent<SceneLoader>().sceneToLoad = "MainMenu";
        sceneLoader.GetComponent<SceneLoader>().StartLoad();
    }

    public void OpenHelpMenu()
    {
        MainMenuPage.SetActive(false);
        HowToPlayMenuPage.SetActive(true);
    }

    public void CloseHelpMenu()
    {
        MainMenuPage.SetActive(true);
        HowToPlayMenuPage.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
