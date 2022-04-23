using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGlock : MonoBehaviour
{
    public GameObject GlockOB;
    public GameObject invOB;
    public GameObject pickUpText;
    public AudioSource GunPickUpSound;

    public GameObject Knife; //will be used to disable knife (the one in the inventory if active) before showing the Glock

    public bool inReach;


    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        invOB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            Destroy(GlockOB);
            GunPickUpSound.Play();
            if(Knife.activeInHierarchy)
            {
                Knife.SetActive(false);
                invOB.SetActive(true);
                invOB.GetComponent<GunSystem>().isAvailable = true;
            }
            else
            {
                invOB.SetActive(true);
                invOB.GetComponent<GunSystem>().isAvailable = true;
            }
            
            pickUpText.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }
}
