using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemsSwitch : MonoBehaviour
{
    public GameObject object1;
    //public GameObject object2;
    //public GameObject object3;

    public GameObject object1Inv;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("1") || Input.GetButtonDown("[1]"))
        {
            object1.SetActive(false);
            //object2.SetActive(false);
            //object3.SetActive(false);
        }
        else if (object1Inv.activeInHierarchy && (Input.GetButtonDown("2") || Input.GetButtonDown("[2]")))
        {
            object1.SetActive(true);
        }

            /*
        {
            if (object1.GetComponent<GunSystem>().isAvailable)
            {
                object1.SetActive(true);
                object2.SetActive(false);
            }
            //object3.SetActive(false);
        }
        else if (Input.GetButtonDown("3"))
        {
            if (object2.GetComponent<GunSystem>().isAvailable)
            {
                object1.SetActive(false);
                object2.SetActive(true);
            }
            //object3.SetActive(false);
        }*/
    }
}
