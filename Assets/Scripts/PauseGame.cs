using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    public FirstPersonController playerScript;
    public GameObject pauseMenuUI;
    public GameObject HowToPlayMEnuUI;
    [SerializeField] bool on;
    static PlayerInput input;
    //public bool off;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
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

        pauseMenuUI.SetActive(true);
        on = true;
    }

    public void Resume()
    {
        playerScript.enabled = true;
        Time.timeScale = 1;

        pauseMenuUI.SetActive(false);
        HowToPlayMEnuUI.SetActive(false);
        on = false;
    }

    public void openHowToPlayMenu()
    {
        playerScript.enabled = false;
        Time.timeScale = 0;

        pauseMenuUI.SetActive(false);
        HowToPlayMEnuUI.SetActive(true);
        on = true;
    }

    public void closeHowToPlayMenu()
    {
        playerScript.enabled = false;
        Time.timeScale = 0;

        pauseMenuUI.SetActive(true);
        HowToPlayMEnuUI.SetActive(false);
        on = true;
    }



    public void Exit()
    {
        Application.Quit();
    }
}
