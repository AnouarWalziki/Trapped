using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveImage : MonoBehaviour
{
    public Animator anim;

    public GameObject interactImage;

    public AudioSource MoveSound;

    public bool inReach;

    public bool ShowKey;

    public bool HaveMoved;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        interactImage.SetActive(false);
        ShowKey = false;
        HaveMoved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!HaveMoved)
        {
            if (inReach && Input.GetButtonDown("Interact"))
            {
                anim.SetBool("Open", true);
                MoveSound.Play();
                interactImage.SetActive(false);
                ShowKey = true;
                HaveMoved = true;
                gameObject.GetComponent<Outline>().enabled = false;
            }
        }
    }
        

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            if (!HaveMoved)
            {
                inReach = true;
                gameObject.GetComponent<Outline>().enabled = true;
                interactImage.SetActive(true);
            }
                
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!HaveMoved)
        {
            inReach = false;
            gameObject.GetComponent<Outline>().enabled = false;
            interactImage.SetActive(false);
        }

    }
}
