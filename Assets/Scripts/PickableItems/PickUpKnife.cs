using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKnife : MonoBehaviour
{
    public GameObject knifeOB;
    public GameObject invOB;
    public GameObject pickUpText;
    public AudioSource KnifePickUpSound;

    public GameObject Glock; //will be used to disable Glock (the one in the inventory if active) before showing the Knife

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
            Destroy(knifeOB);
            KnifePickUpSound.Play();
            if (Glock.activeInHierarchy)
            {
                Glock.SetActive(false);
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
