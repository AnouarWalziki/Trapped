using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinMenuController : MonoBehaviour
{
    public GameObject FinMenuUI;
    public GameObject sceneLoader;

    private void Start()
    {
        Cursor.visible = true;
        Screen.lockCursor = false;
        FinMenuUI.SetActive(true);
    }

    public void LoadMainMenuScene()
    {
        sceneLoader.GetComponent<SceneLoader>().sceneToLoad = "MainMenu";
        sceneLoader.GetComponent<SceneLoader>().StartLoad();
    }

    public void Quit()
    {
        Application.Quit();
    }

}
