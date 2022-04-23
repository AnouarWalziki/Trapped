using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBoxScript : MonoBehaviour
{

    public Animator boxOB;
    public GameObject keyOBNeeded;
    public GameObject openText;
    public GameObject KeyMissingText;
    public AudioSource openSound;

    public bool inReach;
    public bool isOpen;


    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        isOpen = false;
        openText.SetActive(false);
        KeyMissingText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(keyOBNeeded.activeInHierarchy == true && inReach && Input.GetButtonDown("Interact"))
        {
            keyOBNeeded.SetActive(false);
            openSound.Play();
            boxOB.SetBool("open", true);
            openText.SetActive(false);
            KeyMissingText.SetActive(false);
            isOpen = true;
        }
        else if (keyOBNeeded.activeInHierarchy == false && inReach && Input.GetButtonDown("Interact"))
        {
            openText.SetActive(false);
            KeyMissingText.SetActive(true);
        }
        
        if(isOpen)
        {
            boxOB.GetComponent<BoxCollider>().enabled = false;
            boxOB.GetComponent<OpenBoxScript>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            KeyMissingText.SetActive(false);
        }
    }


}
