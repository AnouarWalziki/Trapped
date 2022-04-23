using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PickObject : MonoBehaviour
{
    public Transform playerSocket;

    public GameObject interctImage;

    public GameObject crosshair;

    private bool onPickup;
    private bool inReach;
    private Outline outline;

    public Quaternion originalRotation;

    public GameObject ReachOB;

    private float smooth = 5.0f;

    private void Start()
    {
        //originalRotation = gameObject.transform.rotation;
        interctImage.SetActive(false);
        outline = gameObject.GetComponent<Outline>();
        onPickup = false;
        inReach = false;
    }
    private void Update()
    {
        
        if (inReach && !onPickup)
        {
            if (Input.GetButtonDown("Pickup"))
            {
                onPickup = true;
                StartCoroutine(pickupItem());
            }
        }
        else
        {
            if (onPickup)
            {
                crosshair.SetActive(false);
                outline.enabled = false;
                interctImage.SetActive(false);
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, playerSocket.position, 0.2f);
            }

            if (Input.GetButtonDown("Pickup") && onPickup)
            {
                StartCoroutine(dropItem());
                onPickup = false;
            }
        }


    }


    IEnumerator pickupItem()
    {
        //crosshair.SetActive(false);
       // outline.enabled = false;
        
        gameObject.GetComponent<Rigidbody>().isKinematic = true;

        gameObject.transform.rotation = originalRotation;


        yield return new WaitForSeconds(0.2f);
        gameObject.transform.SetParent(playerSocket);
        ReachOB.SetActive(false);
    }

    IEnumerator dropItem()
    {
        crosshair.SetActive(true);
        gameObject.transform.SetParent(null);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        ReachOB.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            interctImage.SetActive(true);
            outline.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            
            inReach = false;
            interctImage.SetActive(false);
            outline.enabled = false;
            crosshair.SetActive(true);
        }
    }
}
