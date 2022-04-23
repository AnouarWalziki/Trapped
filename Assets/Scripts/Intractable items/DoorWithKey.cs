using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithKey : MonoBehaviour
{
    public Animator door;
    public GameObject InteractImage;
    public GameObject lockedText;

    public AudioSource doorOpenSound;
    
    public AudioSource doorCloseSound;

    public AudioSource lockedSound;

    public GameObject KeyOB;

    public bool inReach;

    private int moveDoor;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        moveDoor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact") && moveDoor != 1)
        {
            if(KeyOB.activeInHierarchy)
                moveDoor = 1;
            DoorOpens();
        }
        else if (inReach && Input.GetButtonDown("Interact") && moveDoor != -1)
        {
            moveDoor = -1;
            DoorCloses();
        }
        else if (moveDoor == 0)
        {

        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            InteractImage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            InteractImage.SetActive(false);
            lockedText.SetActive(false);
        }
    }

    void DoorOpens()
    {
        if (KeyOB.activeInHierarchy)
        {
            door.SetBool("Open", true);
            doorOpenSound.Play();
        }
        else
        {
            InteractImage.SetActive(false);
            lockedText.SetActive(true);
            lockedSound.Play();
        }
        
    }

    void DoorCloses()
    {
        door.SetBool("Open", false);
        doorCloseSound.Play();
    }
}
