using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SifonerDoors : MonoBehaviour
{
    public Animator anim;

    public GameObject interactImage;

    public AudioSource OpenSound;

    public bool inReach;

    public int moveDoors;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        interactImage.SetActive(false);
        moveDoors = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact") && moveDoors != 1)
        {
            moveDoors = 1;
            anim.SetBool("Open", true);
            OpenSound.Play();
            interactImage.SetActive(false);
        }
        else if (inReach && Input.GetButtonDown("Interact") && moveDoors != -1)
        {
            moveDoors = -1;
            anim.SetBool("Open", false);
            interactImage.SetActive(false);
        }
        else if (moveDoors == 0)
        {

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true;
            interactImage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            interactImage.SetActive(false);
        }
    }
}
