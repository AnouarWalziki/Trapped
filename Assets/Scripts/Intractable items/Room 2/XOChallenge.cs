using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class XOChallenge : MonoBehaviour
{
    public GameObject playerOb;
    
    public GameObject[] challengeGameObjects;

    private Vector3 oldPosition;
    private Vector3 newPosition;

    public float zMoveStep;
    public float yMoveStep;

    public GameObject playerCam;
    public GameObject challengeCam;

    private int selectedObjectIndex = 0;

    public bool inReach;

    private bool doingChallenge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && inReach && !doingChallenge)
        {
            doingChallenge = true;
        }

        if(doingChallenge)
        {

        }
        
    }

    void SeletObjectToMove()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Reach"))
        {
            inReach = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Reach"))
        {
            inReach = false;
        }
    }
}
