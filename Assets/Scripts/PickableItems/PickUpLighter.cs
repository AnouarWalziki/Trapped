using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Michsky.UI.ModernUIPack;

public class PickUpLighter : MonoBehaviour
{
    public GameObject lighterInv;

    public GameObject InteractImage;

    //public ModalWindowManager ModalWindow;

    //public FirstPersonController playerScript;

    public bool inReach;

    private Outline outline;

    //private bool WindowOpen;


    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        lighterInv.SetActive(false);
        outline = gameObject.GetComponent<Outline>();
        outline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(inReach && Input.GetButtonDown("Interact"))
        {
            lighterInv.SetActive(true);
            InteractImage.SetActive(false);
            outline.enabled = false;
            //playerScript.enabled = false;
            inReach = false;
            Destroy(gameObject);
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            InteractImage.SetActive(true);
            outline.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            InteractImage.SetActive(false);
            outline.enabled = false;
        }
    }

}
