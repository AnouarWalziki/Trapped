using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKeyR2 : MonoBehaviour
{
    public GameObject cam;
    public GameObject keyFoundImage;
    public float range = 5f;

    public GameObject keyOB;
    public GameObject invOB;
    public GameObject pickUpText;
    public AudioSource keySound;

    public bool inReach = false;


    // Start is called before the first frame update
    void Start()
    {
        pickUpText.SetActive(false);
        invOB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bool keyInFocus = playerSeeTheKey();

        if(keyInFocus)
        {
            gameObject.GetComponent<Outline>().enabled = true;
            pickUpText.SetActive(true);
        }
        else
        {
            gameObject.GetComponent<Outline>().enabled = false;
            pickUpText.SetActive(false);
        }

        if (keyInFocus && Input.GetButtonDown("Interact"))
        {            
            keySound.Play();
            invOB.SetActive(true);
            pickUpText.SetActive(false);
            keyFoundImage.SetActive(true);
            Destroy(keyOB);
        }    
    }

    bool playerSeeTheKey()
    {
        RaycastHit hit;
        //Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.red);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)) ;
        {
            return hit.transform.gameObject.CompareTag("LevelKey");
        }
    }
/*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            gameObject.GetComponent<Outline>().enabled = true;
            pickUpText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inReach = false;
        gameObject.GetComponent<Outline>().enabled = false;
        pickUpText.SetActive(false);
        
    }
*/
}
