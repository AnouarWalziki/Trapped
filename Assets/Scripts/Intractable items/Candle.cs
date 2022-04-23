using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    public GameObject flames;

    public GameObject lighter;

    public GameObject InteractImage;

    public Outline outline;

    public bool inReach;

    public bool canBeLighted;

    public bool fireOn;

    // Start is called before the first frame update
    void Start()
    {
        outline = gameObject.GetComponent<Outline>();
        flames.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(inReach && canBeLighted && !fireOn && lighter.GetComponent<Lighter>().onFire && Input.GetButtonDown("Interact"))
        {
            flames.SetActive(true);
            fireOn = true;
        }
        else if (inReach && fireOn && !lighter.GetComponent<Lighter>().onFire && Input.GetButtonDown("Interact"))
        {
            flames.SetActive(false);
            fireOn = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            InteractImage.SetActive(true);
            outline.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            InteractImage.SetActive(false);
            outline.enabled = false;
        }
    }
}
