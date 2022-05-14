using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    public GameObject flames;

    public GameObject lighter;

    public GameObject interactImage;

    public GameObject grabImage;

    public Outline outline;

    public bool inReach;

    public bool canBeLighted;

    public bool fireOn;

    public bool candleOntable;

    private DetectKeyInPlace scriptToDetectCandleOnTable;


    // Start is called before the first frame update
    void Start()
    {
        outline = gameObject.GetComponent<Outline>();
        flames.SetActive(false);
        scriptToDetectCandleOnTable = FindObjectOfType<DetectKeyInPlace>().GetComponent<DetectKeyInPlace>();
    }

    // Update is called once per frame
    void Update()
    {
        candleOntable = scriptToDetectCandleOnTable.inPlace;

        if (inReach && canBeLighted && !fireOn && lighter.GetComponent<Lighter>().onFire && Input.GetButtonDown("Interact")
            && FindObjectOfType<DetectKeyInPlace>().inPlace) 
        {
            flames.SetActive(true);
            fireOn = true;
        }
        else if (inReach && fireOn && !lighter.GetComponent<Lighter>().onFire && Input.GetButtonDown("Interact")
            && FindObjectOfType<DetectKeyInPlace>().inPlace)
        {
            flames.SetActive(false);
            fireOn = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            if(candleOntable)
            {
                inReach = true;
                grabImage.SetActive(false);
                interactImage.SetActive(true);
                outline.enabled = true;
            }         
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            if (candleOntable)
            {
                inReach = false;
                grabImage.SetActive(false);
                interactImage.SetActive(false);
                outline.enabled = false;
            }
        }
    }    
}
