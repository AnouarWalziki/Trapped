using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PadLock : MonoBehaviour
{
    public GameObject playerOb;
    private Animator playerAnim;
    public GameObject playerCrosshair;

    public Door leftDoorScript;
    public Door rightDoorScript;

    public GameObject key;

    public GameObject boxCollider; //To stop player from getting too close to the padlock.

    public Outline lockOutline;

    public bool inReach = false;

    
    public bool playerIsInspectingLock = false;
    public Vector3 playerPosWhileInspecting;
    public Quaternion playerRotationWhileInspecting;
    public Vector3 playerPosAfterInspecting;
    public Quaternion playerRotationAfterInspecting;

    private bool tryingToUnlockLock = false;
    public AudioSource OpenPadlockSound;
    public bool lockOpened = false;
    public float wheelsTruningAngle = 35f;

    public GameObject[] lockWheels;
    private int lockWheelToTurn = 0;

    public Vector4 correctLockCombination;
    private float[] LockNumbersToRotationAngles = new float[10] { 0, 36, 36 * 2, 36 * 3, 36 * 4, 36 * 5, 36 * 6, 36 * 7, 36 * 8, 36 * 9 };

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = playerOb.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerIsInspectingLock = PlayerIsCloseToLock.playerIsCloseToLock;

        if (Input.GetButtonDown("Interact") && inReach && !playerIsInspectingLock)
        {
            PlayerInspectingPadLock();
        }
        else if (Input.GetButtonDown("Interact") && playerIsInspectingLock)
        {
            PlayerStoppedInpectingPadLock();
        }

        if (tryingToUnlockLock)
        {
            TryingCombination();

            CheckLockCombination();
        }
        else
        {
            lockWheels[lockWheelToTurn].GetComponent<Outline>().enabled = false;
        }
        
    }

    void PlayerInspectingPadLock()
    {
        //Stop player from moving and play corresponding animations for "trying to unlock Padlock" action

        //playerOb.transform.position = playerPosWhileInspecting;
        //playerOb.transform.rotation = playerRotationWhileInspecting;

        playerAnim.enabled = true;

        lockOutline.enabled = false;
        playerOb.GetComponent<FirstPersonController>().enabled = false;
        playerAnim.applyRootMotion = false;
        playerAnim.SetBool("InspectLock", true);
        playerCrosshair.SetActive(false);
        gameObject.GetComponent<Animator>().SetBool("InspectLock", true);
        tryingToUnlockLock = true;
    }

    void PlayerStoppedInpectingPadLock()
    {
        //Play corresponding animations for "stop trying to unlock Padlock" action and enable player movements

        gameObject.GetComponent<Animator>().SetBool("InspectLock", false);
        playerAnim.SetBool("InspectLock", false);
        StartCoroutine(UnlockPlayerMovement(1));
        tryingToUnlockLock = false;
    }


    public void TryingCombination()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(lockWheelToTurn == 0)
            {
                lockWheelToTurn = 3;
            }
            else
            {
                lockWheelToTurn--;
            }

            if (lockWheelToTurn == 3)
            {
                lockWheels[0].GetComponent<Outline>().enabled = false;
            }
            else
            {
                lockWheels[lockWheelToTurn + 1].GetComponent<Outline>().enabled = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (lockWheelToTurn == 3)
            {
                lockWheelToTurn = 0;
            }
            else
            {
                lockWheelToTurn++;
            }

            if (lockWheelToTurn == 0)
            {
                lockWheels[3].GetComponent<Outline>().enabled = false;
            }
            else
            {
                lockWheels[lockWheelToTurn - 1].GetComponent<Outline>().enabled = false;
            }

        }

        lockWheels[lockWheelToTurn].GetComponent<Outline>().enabled = true;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            lockWheels[lockWheelToTurn].transform.Rotate(Vector3.up, wheelsTruningAngle);
        }
    }

    public void CheckLockCombination()
    {
        if (Mathf.RoundToInt(lockWheels[0].transform.localEulerAngles.y) == LockNumbersToRotationAngles[(int)correctLockCombination.x]
            && Mathf.RoundToInt(lockWheels[1].transform.localEulerAngles.y) == LockNumbersToRotationAngles[(int)correctLockCombination.y]
                && Mathf.RoundToInt(lockWheels[2].transform.localEulerAngles.y) == LockNumbersToRotationAngles[(int)correctLockCombination.z]
                    && Mathf.RoundToInt(lockWheels[3].transform.localEulerAngles.y) == LockNumbersToRotationAngles[(int)correctLockCombination.w]
            ) 
        {
            //Combiantion is correct 
            //Debug.Log("Unlocked");
            StartCoroutine(OpenLock());
        } 
        else
        {
            //Combiantion is not 
            lockOpened = false;
        }
        
    }

    IEnumerator OpenLock()
    {
        gameObject.GetComponent<Animator>().SetBool("OpenLock", true);
        yield return new WaitForSeconds(4);
        lockOpened = true;
        key.SetActive(true);
        leftDoorScript.enabled = true;
        rightDoorScript.enabled = true;
        Destroy(boxCollider);
        yield return StartCoroutine(UnlockPlayerMovement(0));
        GameObject.Find("Crosshair").SetActive(true);
        //tryingToUnlockLock = false;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true;
            lockOutline.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            lockOutline.enabled = false;
        }
    }

    IEnumerator UnlockPlayerMovement(int delay)
    {
        yield return new WaitForSeconds(delay);
        //playerAnim.applyRootMotion = true;
        /*
         float duration = 1.0;
        for (t=0.0; t<duration;t+=Time.deltaTime) {
        transform.position = Vector3.Lerp(Vector3(0,0,0), Vector3(0,0,5), t/duration);
        yield;
        }
         */
        playerAnim.enabled = false;
        
        //playerOb.transform.position = playerPosAfterInspecting;
        //playerOb.transform.rotation = playerRotationAfterInspecting;

        playerOb.GetComponent<FirstPersonController>().enabled = true;
        playerCrosshair.SetActive(true);
    }
    
}
