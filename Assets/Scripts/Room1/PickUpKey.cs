using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public GameObject SmallImageOB;

    public GameObject ReachOB;

    public GameObject keyOB;
    public GameObject invOB;
    //public GameObject pickUpText;
    public AudioSource keySound;

    public bool inReach;

    private bool doOneTime;


    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        //pickUpText.SetActive(false);
        invOB.SetActive(false);
        doOneTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if( SmallImageOB.GetComponent<MoveImageWithKey>().ShowKey)
        {
            if (doOneTime)
            {
                ReachOB.GetComponent<BoxCollider>().enabled = false;
                ReachOB.GetComponent<BoxCollider>().enabled = true;
                doOneTime = false;
            }
            
            if (inReach && Input.GetButtonDown("Pickup"))
            {
                Destroy(keyOB);
                keySound.Play();
                invOB.SetActive(true);
                //pickUpText.SetActive(false);
            }
        }
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            if (SmallImageOB.GetComponent<MoveImageWithKey>().ShowKey)
            {
                inReach = true;
                gameObject.GetComponent<Outline>().enabled = true;
                //pickUpText.SetActive(true);
            }
                
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (SmallImageOB.GetComponent<MoveImageWithKey>().ShowKey)
        {
            inReach = false;
            gameObject.GetComponent<Outline>().enabled = false;
            //pickUpText.SetActive(false);
        }
    }

}
