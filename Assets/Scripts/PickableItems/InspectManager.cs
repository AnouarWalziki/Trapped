using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InspectManager : MonoBehaviour
{
    public Transform InspectSocket;

    public GameObject interctImage;
    //public GameObject crosshair;
    public GameObject reachOB;
    public GameObject playerCam;
    public GameObject inspectorCam;

    private GameObject parentObject;
    private Vector3 originalPos;
    private Quaternion originalRotation;
    private bool onInspect;
    private bool inReach;
    private Outline outline;

    public FirstPersonController playerScript;
    public PauseGame pauseScript;

    private void Start()
    {
        interctImage.SetActive(false);
        outline = gameObject.GetComponent<Outline>();
        if (gameObject.transform.parent.gameObject != null)
            parentObject = gameObject.transform.parent.gameObject;

        originalPos = gameObject.transform.position;
        originalRotation = gameObject.transform.rotation;
        onInspect = false;
        inReach = false;
    }
    private void Update()
    {
        
        if (inReach && !onInspect)
        {
            if(Input.GetButtonDown("Interact"))
            {
                originalPos = gameObject.transform.position;
                onInspect = true;

                StartCoroutine(pickupItem());
            }
        }
        else {
            if (onInspect)
            {
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, InspectSocket.position, 0.2f);
                InspectSocket.Rotate(new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 125f);
            }
            //else
            //{
               // gameObject.transform.SetParent(null);
               // gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, originalPos, 0.1f);
            //}

            if ((Input.GetButtonDown("Interact") || Input.GetKeyDown(KeyCode.Escape)) && onInspect)
            {
                StartCoroutine(dropItem());
                onInspect = false;
            }
        }
        
        
    }

    IEnumerator pickupItem()
    {
        reachOB.SetActive(false);
        pauseScript.enabled = false;
        playerScript.enabled = false;
        interctImage.SetActive(false);
        //crosshair.SetActive(false);
        outline.enabled = false;
        yield return new WaitForSeconds(0.2f);
        gameObject.transform.SetParent(InspectSocket);
        playerCam.SetActive(false);
        inspectorCam.SetActive(true);
    }

    IEnumerator dropItem()
    {
        gameObject.transform.rotation = originalRotation;
        if(parentObject != null)
        {
            gameObject.transform.SetParent(parentObject.transform);
        }
        else
        {
            gameObject.transform.SetParent(null);
        }
        
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, originalPos, 1f);
        yield return new WaitForSeconds(0.2f);
        playerScript.enabled = true;
        interctImage.SetActive(true);
        outline.enabled = true;
        //crosshair.SetActive(true);
        reachOB.SetActive(true);
        playerCam.SetActive(true);
        inspectorCam.SetActive(false);
        pauseScript.enabled = true;

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
        }
    }
}
