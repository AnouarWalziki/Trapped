
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectKeyInPlace : MonoBehaviour
{
    public GameObject ImageOB;

    public Vector3 KeyPosition;

    public Quaternion KeyRotation;

    public bool inPlace;

    private GameObject trigger;

    private void FixedUpdate()
    {
        if(trigger != null && trigger.GetComponent<Candle>() != null)
        {
            trigger.GetComponent<Rigidbody>().isKinematic = true;
            trigger.transform.position = KeyPosition;
            trigger.transform.rotation = KeyRotation;
            trigger.GetComponent<PickObject>().enabled = false;

            if (trigger.GetComponent<Candle>().fireOn)
                ImageOB.GetComponent<MoveImageWithKey>().keyInPlace = true;
            else
                ImageOB.GetComponent<MoveImageWithKey>().keyInPlace = false;
        }
        else
        {
            ImageOB.GetComponent<MoveImageWithKey>().keyInPlace = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LevelKey")
        {
            trigger = collision.gameObject;
            inPlace = true;
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "LevelKey")
        {
            if(trigger.GetComponent<Candle>() == null)
            {
                trigger = null;
                inPlace = false;
            }
        }
    }
}
