using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Michsky.UI.ModernUIPack;

public class InsideRoom1 : MonoBehaviour
{

    public Door enterDoorScript;

    public Animator enterDoorAnim;

    public AudioSource closeDoorSound;

    public GameObject BlockAccess;

    public ModalWindowManager ModalWindow;

    public FirstPersonController playerScript;

    private bool WindowOpen;

    private bool HaveBeenTriggered;

    // Start is called before the first frame update
    void Start()
    {
        WindowOpen = false;
        HaveBeenTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (WindowOpen && Input.GetButtonDown("Interact"))
        {
            ModalWindow.CloseWindow();
            WindowOpen = false;
            playerScript.enabled = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !HaveBeenTriggered)
        {
            enterDoorScript.enabled = false;
            enterDoorAnim.SetBool("Open", false);
            BlockAccess.SetActive(true);
            closeDoorSound.Play();
            StartCoroutine(flashlightTip());
            HaveBeenTriggered = true;
        }
    }

    IEnumerator flashlightTip()
    {
        yield return new WaitForSeconds(10f);

        playerScript.enabled = false;
        ModalWindow.OpenWindow();
        WindowOpen = true;
    }
}
