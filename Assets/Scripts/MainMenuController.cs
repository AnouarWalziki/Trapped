using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenuPage;
    public GameObject HowToPlayMenuPage;
    public GameObject ChooseStartPage;
    public GameObject ChooseLevelPage;

    public GameObject sceneLoader;

    private void Start()
    {
        MainMenuPage.SetActive(true);
        HowToPlayMenuPage.SetActive(false);
        HowToPlayMenuPage.SetActive(false);
        ChooseStartPage.SetActive(false);
        ChooseLevelPage.SetActive(false);

        Cursor.visible = true;
        Screen.lockCursor = false;
    }

    public void NewGame()
    {
        sceneLoader.GetComponent<SceneLoader>().sceneToLoad = "StartingLevel";
        sceneLoader.GetComponent<SceneLoader>().StartLoad();
    }

    public void LoadLevel1()
    {
        sceneLoader.GetComponent<SceneLoader>().sceneToLoad = "Room1";
        sceneLoader.GetComponent<SceneLoader>().StartLoad();
    }

    public void LoadLevel2()
    {
        sceneLoader.GetComponent<SceneLoader>().sceneToLoad = "Room2";
        sceneLoader.GetComponent<SceneLoader>().StartLoad();
    }

    public void LoadEnding()
    {
        sceneLoader.GetComponent<SceneLoader>().sceneToLoad = "Ending";
        sceneLoader.GetComponent<SceneLoader>().StartLoad();
    }

    public void OpenMainMenu()
    {
        MainMenuPage.SetActive(true);
        HowToPlayMenuPage.SetActive(false);
        ChooseStartPage.SetActive(false);
        ChooseLevelPage.SetActive(false);
    }

    public void OpenHelpMenu()
    {       
        HowToPlayMenuPage.SetActive(true);
        MainMenuPage.SetActive(false);
        ChooseStartPage.SetActive(false);
        ChooseLevelPage.SetActive(false);
    }

    public void OpenChooseStartMenu()
    {
        ChooseStartPage.SetActive(true);
        MainMenuPage.SetActive(false);
        HowToPlayMenuPage.SetActive(false);       
        ChooseLevelPage.SetActive(false);
    }

    public void OpenChooseLevelMenu()
    {
        ChooseLevelPage.SetActive(true);
        ChooseStartPage.SetActive(false);
        MainMenuPage.SetActive(false);
        HowToPlayMenuPage.SetActive(false);       
    }

    public void Quit()
    {
        Application.Quit();
    }
}
