using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class XOChallenge : MonoBehaviour
{
    public FirstPersonController playerScript;

    public GameObject InteractImage;

    public GameObject[] challengeGameObjects;

    public GameObject SelectModeUI;
    public GameObject EditModeUI;


    private Vector3 oldPosition;
    private Vector3 newPosition;

    public float zMoveStep;
    public float yMoveStep;

    public Camera playerCam;
    public GameObject challengeCam;

    private int selectedObjectIndex = 0;

    //public GameObject ReachOb;
    public bool inReach;

    private bool doingChallenge;

    [SerializeField] private bool objectSelected;

    private string CHALLENGE_KEY_TAG = "Challenge key";

    [SerializeField] private bool verifyCombinationResult;

    [SerializeField] private bool canSelectObjects;

    [SerializeField] private float objectsInPlace = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && inReach && !doingChallenge)
        {
            doingChallenge = true;
            StartChallenge();
        }
        else if(Input.GetButtonDown("Interact") && doingChallenge)
        {
            doingChallenge = false;
            StopChallenge();
        }

        if(doingChallenge)
        {
            if(!objectSelected && canSelectObjects)
            {              
                SeletObjectToMove();

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    objectSelected = true;
                }
            }
            else if(objectSelected && canSelectObjects)
            {             
                MoveObject();

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    objectSelected = false;
                }
            }

            if(VerifyCombination())
            {
                //objectSelected = false;
                //canSelectObjects = false;

                doingChallenge = false;

                gameObject.GetComponent<BoxCollider>().enabled = false;

                inReach = false;

                StopChallenge();
                StartCoroutine(DestroyNotKeysObjects());
                //ShowChallengeResult();
                                              
            }
            else
            {
                canSelectObjects = true;
            }
            
        }
    }

    void StartChallenge()
    {
        InteractImage.SetActive(false);
        playerScript.enabled = false;
        playerCam.enabled = false;
        challengeCam.SetActive(true);
        
    }

    void StopChallenge()
    {
        challengeGameObjects[selectedObjectIndex].GetComponent<Outline>().enabled = false;
        selectedObjectIndex = 0;

        objectSelected = false;


        InteractImage.SetActive(false);

        playerCam.enabled = true;
        playerScript.enabled = true;
        challengeCam.SetActive(false);

        SelectModeUI.SetActive(false);
        EditModeUI.SetActive(false);
    }

    void SeletObjectToMove()
    {
        //Give player ability to highlight challenge object to move

        SelectModeUI.SetActive(true);
        EditModeUI.SetActive(false);

        challengeGameObjects[selectedObjectIndex].GetComponent<Outline>().enabled = true;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            challengeGameObjects[selectedObjectIndex].GetComponent<Outline>().enabled = false;
            if (selectedObjectIndex == 2
                || selectedObjectIndex == 5
                    || selectedObjectIndex == 8
                )
            {
                //Do nothning.
            }
            else
            {
                selectedObjectIndex++;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            challengeGameObjects[selectedObjectIndex].GetComponent<Outline>().enabled = false;
            if (selectedObjectIndex == 0
                || selectedObjectIndex == 3
                    || selectedObjectIndex == 6
                )
            {
                //Do nothning.
            }
            else
            {
                selectedObjectIndex--;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            challengeGameObjects[selectedObjectIndex].GetComponent<Outline>().enabled = false;
            if (selectedObjectIndex == 0
                || selectedObjectIndex == 1
                    || selectedObjectIndex == 2
                )
            {
                //Do nothning.
            }
            else
            {
                selectedObjectIndex -= 3;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            challengeGameObjects[selectedObjectIndex].GetComponent<Outline>().enabled = false;
            if (selectedObjectIndex == 6
                || selectedObjectIndex == 7
                    || selectedObjectIndex == 8
                )
            {
                //Do nothning.
            }
            else
            {
                selectedObjectIndex += 3;
            }
        }
    }

    void MoveObject()
    {
        EditModeUI.SetActive(true);
        SelectModeUI.SetActive(false);

        oldPosition = challengeGameObjects[selectedObjectIndex].transform.position;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (selectedObjectIndex == 2
                || selectedObjectIndex == 5
                    || selectedObjectIndex == 8
                )
            {
                //Do nothning.
            }
            else
            {
                //Switching positions
                newPosition = challengeGameObjects[selectedObjectIndex + 1].transform.position;

                challengeGameObjects[selectedObjectIndex].transform.position = newPosition;
                challengeGameObjects[selectedObjectIndex + 1].transform.position = oldPosition;

                //Switching indexes
                GameObject tmp = challengeGameObjects[selectedObjectIndex];
                challengeGameObjects[selectedObjectIndex] = challengeGameObjects[selectedObjectIndex + 1];
                challengeGameObjects[selectedObjectIndex + 1] = tmp;

                //Update index after switch
                selectedObjectIndex++;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (selectedObjectIndex == 0
                || selectedObjectIndex == 3
                    || selectedObjectIndex == 6
                )
            {
                //Do nothning.
            }
            else
            {
                //Switching positions
                newPosition = challengeGameObjects[selectedObjectIndex - 1].transform.position;

                challengeGameObjects[selectedObjectIndex].transform.position = newPosition;
                challengeGameObjects[selectedObjectIndex - 1].transform.position = oldPosition;

                //Switching indexes
                GameObject tmp = challengeGameObjects[selectedObjectIndex];
                challengeGameObjects[selectedObjectIndex] = challengeGameObjects[selectedObjectIndex - 1];
                challengeGameObjects[selectedObjectIndex - 1] = tmp;

                //Update index after switch
                selectedObjectIndex--;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (selectedObjectIndex == 0
                || selectedObjectIndex == 1
                    || selectedObjectIndex == 2
                )
            {
                //Do nothning.
            }
            else
            {
                //Switching positions
                newPosition = challengeGameObjects[selectedObjectIndex - 3].transform.position;

                challengeGameObjects[selectedObjectIndex].transform.position = newPosition;
                challengeGameObjects[selectedObjectIndex - 3].transform.position = oldPosition;

                //Switching indexes
                GameObject tmp = challengeGameObjects[selectedObjectIndex];
                challengeGameObjects[selectedObjectIndex] = challengeGameObjects[selectedObjectIndex - 3];
                challengeGameObjects[selectedObjectIndex - 3] = tmp;

                //Update index after switch
                selectedObjectIndex -= 3;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            if (selectedObjectIndex == 6
                || selectedObjectIndex == 7
                    || selectedObjectIndex == 8
                )
            {
                //Do nothning.
            }
            else
            {
                //Switching positions
                newPosition = challengeGameObjects[selectedObjectIndex + 3].transform.position;

                challengeGameObjects[selectedObjectIndex].transform.position = newPosition;
                challengeGameObjects[selectedObjectIndex + 3].transform.position = oldPosition;

                //Switching indexes
                GameObject tmp = challengeGameObjects[selectedObjectIndex];
                challengeGameObjects[selectedObjectIndex] = challengeGameObjects[selectedObjectIndex + 3];
                challengeGameObjects[selectedObjectIndex + 3] = tmp;

                //Update index after switch
                selectedObjectIndex += 3;
            }
        }

    }

    bool VerifyCombination()
    {
        Vector3 correctPos1 = new Vector3(16.501585f, 16.6000004f, -1.56999969f);
        Vector3 correctPos2 = new Vector3(16.4652462f, 16.6000004f, -2.39999962f);
        Vector3 correctPos3 = new Vector3(16.501585f, 15.8000002f, -2.39999962f);

        Vector3[] correctPosition= { correctPos1, correctPos2, correctPos3 };        

        GameObject[] challengeKeyObjects = GameObject.FindGameObjectsWithTag(CHALLENGE_KEY_TAG);
        Debug.Log(challengeKeyObjects[0].transform.localPosition);

        for(int i = 0; i < challengeKeyObjects.Length; i++)
        {
            for(int j = 0; j < correctPosition.Length; j++)
            {
                if(challengeKeyObjects[i].transform.localPosition == correctPosition[j])
                {
                    objectsInPlace++;
                    //break;
                }
            }
        }

        if(objectsInPlace == 3)
        {
            return true;
        }
        else
        {
            objectsInPlace = 0;
            return false;
        }
    }

    IEnumerator DestroyNotKeysObjects()
    {
        for (int i = 0; i < challengeGameObjects.Length; i++)
        {
            if (!challengeGameObjects[i].CompareTag(CHALLENGE_KEY_TAG))
            {
                yield return new WaitForSeconds(1);
                Destroy(challengeGameObjects[i]);
               
            } 
        }
        //Destroy(gameObject);
    }
    
    IEnumerator DestroyObject(GameObject ob,int delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(ob);

    }

    void ShowChallengeResult()
    {
        Vector3 centerPos = new Vector3(16.5017319f, 15.8000002f, -1.56999969f);

        GameObject[] challengeKeyObjects = GameObject.FindGameObjectsWithTag(CHALLENGE_KEY_TAG);

        float duration = 1.0f;

        for (int i = 0; i < challengeKeyObjects.Length; i++)
        {
            for (float t = 0.0f; t < duration; t += Time.deltaTime)
            {
                transform.localPosition = Vector3.Lerp(challengeKeyObjects[i].transform.localPosition,
                     centerPos, t / duration);

                //yield;
            }
        }

        
         
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Reach"))
        {
            inReach = true;
            InteractImage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Reach"))
        {
            inReach = false;
            InteractImage.SetActive(false);
        }
    }
}
