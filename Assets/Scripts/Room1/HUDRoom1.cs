using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDRoom1 : MonoBehaviour
{
    public GameObject flashlightON;
    public GameObject flashlightOFF;
    public GameObject flashlightOB;

    public GameObject lighterOB;
    public GameObject lighter;

    // Update is called once per frame
    void Update()
    {
        if (flashlightOB.activeInHierarchy)
        {
            flashlightON.SetActive(true);
            flashlightOFF.SetActive(false);
        }
        else
        {
            flashlightON.SetActive(false);
            flashlightOFF.SetActive(true);
        }

        if (lighterOB.activeInHierarchy)
        {
            lighter.SetActive(true);
        }
        else
        {
            lighter.SetActive(false);
        }
    }
}
