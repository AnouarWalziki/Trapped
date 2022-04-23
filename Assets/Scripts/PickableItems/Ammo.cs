using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public GameObject theAmmo;
    public GameObject weaponOB;
    public GameObject pickUpAmmoText;

    public AudioSource pickUpSound;

    public int ammoBoxAmount;

    public bool inReach;

    // Update is called once per frame
    void Update()
    {
        if(inReach && Input.GetButtonDown("Interact"))
        {
            weaponOB.GetComponent<GunSystem>().ammoCache += ammoBoxAmount;
            pickUpAmmoText.SetActive(false);
            Destroy(theAmmo);
            pickUpSound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpAmmoText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpAmmoText.SetActive(false);
        }
    }
}

