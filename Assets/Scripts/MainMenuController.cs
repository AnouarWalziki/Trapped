using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject startButton;
    public GameObject ControlsButton;
    public GameObject QuitButton;
    public GameObject closeControlsButton;

    public GameObject HowToPlayMenu;

    public GameObject sceneLoader;

    public GameObject menuElements;

    public void Play()
    {
        sceneLoader.GetComponent<SceneLoader>().sceneToLoad = "Room1";
        sceneLoader.GetComponent<SceneLoader>().StartLoad();
    }

    public void OpenControls()
    {
        startButton.SetActive(false);
        ControlsButton.SetActive(false);
        QuitButton.SetActive(false);
        HowToPlayMenu.SetActive(true);
        closeControlsButton.SetActive(true);

    }

    public void CloseControls()
    {
        startButton.SetActive(true);
        ControlsButton.SetActive(true);
        QuitButton.SetActive(true);
        HowToPlayMenu.SetActive(false);
        closeControlsButton.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
