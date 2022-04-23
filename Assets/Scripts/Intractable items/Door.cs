using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator door;
    public GameObject InteractImage;

    public AudioSource doorOpenSound;

    public AudioSource doorCloseSound;

    public bool inReach = false;

    public int moveDoor = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact") && moveDoor != 1)
        {
            moveDoor = 1;
            DoorOpens();
        }
        else if (inReach  && Input.GetButtonDown("Interact") && moveDoor != -1)
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
        if (other.gameObject.tag == "Reach" && this.enabled)
        {
            inReach = true;
            InteractImage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach" && this.enabled)
        {
            inReach = false;
            InteractImage.SetActive(false);
        }
    }

    void DoorOpens()
    {
        door.SetBool("Open", true);
        doorOpenSound.Play();
    }

    void DoorCloses()
    {
        door.SetBool("Open", false);
        doorCloseSound.Play();
    }
}
