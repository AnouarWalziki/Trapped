using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject flashlightON;
    public GameObject flashlightOFF;
    public GameObject flashlightOB;

    public GameObject glock;
    public GameObject glockOB;

    public GameObject knife;
    public GameObject knifeOB;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flashlightOB.activeInHierarchy)
        {
            flashlightON.SetActive(true);
            flashlightOFF.SetActive(false);
        }
        else
        {
            flashlightON.SetActive(false);
            flashlightOFF.SetActive(true);
        }

        if (glockOB.activeInHierarchy)
        {
            glock.SetActive(true);
        }
        else
        {
            glock.SetActive(false);
        }

        if (knifeOB.activeInHierarchy)
        {
            knife.SetActive(true);
        }
        else
        {
            knife.SetActive(false);
        }
    }
}
