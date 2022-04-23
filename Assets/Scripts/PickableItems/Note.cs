using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Note : MonoBehaviour
{
    public GameObject player;

    public GameObject NoteTextOB;

    public GameObject cursor;

    public GameObject InteractImage;

    public AudioSource takeSound;

    public AudioSource putAwaySound;

    public bool inReach;

    public bool isOpened;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(inReach && Input.GetButtonDown("Interact") && !isOpened)
        {
            NoteTextOB.SetActive(true);
            player.GetComponent<FirstPersonController>().enabled = false;
            InteractImage.SetActive(false);
            cursor.SetActive(false);
            isOpened = true;
            takeSound.Play();
        }
        else
        {
            if (Input.GetButtonDown("Interact") && isOpened)
            {
                NoteTextOB.SetActive(false);
                putAwaySound.Play();
                cursor.SetActive(true);
                isOpened = false;
                player.GetComponent<FirstPersonController>().enabled = true;
                InteractImage.SetActive(true);
            }
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true;
            gameObject.GetComponent<Outline>().enabled = true;
            InteractImage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            gameObject.GetComponent<Outline>().enabled = false;
            InteractImage.SetActive(false);
        }
    }
}
