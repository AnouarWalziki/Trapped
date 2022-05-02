using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public Animator anim;

    public AudioSource openSound;

    public GameObject interactHand;

    private BoxCollider obCollider;

    private Outline outlineScript;

    private bool inReach;

    // Start is called before the first frame update
    void Start()
    {
        obCollider = gameObject.GetComponent<BoxCollider>();
        outlineScript = gameObject.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inReach && Input.GetButtonDown("Interact"))
        {
            anim.SetBool("Open", true);
            openSound.Play();
            obCollider.enabled = false;
            interactHand.SetActive(false);
            this.enabled = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            interactHand.SetActive(true);
            //outlineScript.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            interactHand.SetActive(false);
            //outlineScript.enabled = false;
        }
    }
}
