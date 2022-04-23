using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject onOB;
    public GameObject offOB;

    public GameObject lightsText;

    public GameObject lightOB;

    public AudioSource switchClick;

    public bool lightsAreOn;
    public bool lightsAreOff;
    public bool inReach;

    // Start is called before the first frame update
    void Start()
    {
        lightsAreOn = false;
        lightsAreOff = true;
        inReach = false;
        onOB.SetActive(false);
        offOB.SetActive(true);
        lightOB.SetActive(false);
}

// Update is called once per frame
void Update()
    {
        if( inReach && lightsAreOn && Input.GetButtonDown("Interact"))
        {
            lightsAreOn = false;
            lightsAreOff = true;
            onOB.SetActive(false);
            offOB.SetActive(true);
            switchClick.Play();
            lightOB.SetActive(false);

        }
        else if (inReach && lightsAreOff && Input.GetButtonDown("Interact"))
        {
            lightsAreOn = true;
            lightsAreOff = false;
            onOB.SetActive(true);
            offOB.SetActive(false);
            switchClick.Play();
            lightOB.SetActive(true);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true;
            lightsText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            lightsText.SetActive(false);
        }
    }


}
