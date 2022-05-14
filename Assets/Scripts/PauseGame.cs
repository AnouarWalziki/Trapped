using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    public FirstPersonController playerScript;
    public GameObject sceneLoader;
    public GameObject pauseMenuUI;
    public GameObject HowToPlayMenuUI;
    [SerializeField] bool on;
    static PlayerInput input;
    //public bool off;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
        on = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!on && Input.GetButtonDown("pause"))
        {
            Pause();
        }
        else if (on && Input.GetButtonDown("pause"))
        {
            Resume();
        }
    }

    public void Pause()
    {
        playerScript.enabled = false;
        Time.timeScale = 0;

        Cursor.visible = true;
        Screen.lockCursor = false;

        pauseMenuUI.SetActive(true);
        on = true;
    }

    public void Resume()
    {
        playerScript.enabled = true;
        Time.timeScale = 1;

        Cursor.visible = false;
        Screen.lockCursor = true;

        pauseMenuUI.SetActive(false);
        HowToPlayMenuUI.SetActive(false);
        on = false;
    }

    public void OpenHowToPlayMenu()
    {
        playerScript.enabled = false;
        Time.timeScale = 0;

        pauseMenuUI.SetActive(false);
        HowToPlayMenuUI.SetActive(true);
        on = true;
    }

    public void LoadMainMenuScene()
    {
        Cursor.visible = false;
        Screen.lockCursor = true;

        Time.timeScale = 1;
        sceneLoader.GetComponent<SceneLoader>().sceneToLoad = "MainMenu";
        sceneLoader.GetComponent<SceneLoader>().StartLoad();
    }

    public void CloseHowToPlayMenu()
    {
        playerScript.enabled = false;
        Time.timeScale = 0;

        pauseMenuUI.SetActive(true);
        HowToPlayMenuUI.SetActive(false);
        on = true;
    }



    public void Exit()
    {
        Application.Quit();
    }
}
