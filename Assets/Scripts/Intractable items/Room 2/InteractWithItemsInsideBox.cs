using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithItemsInsideBox : MonoBehaviour
{

    public GameObject objectInside;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<Door>().moveDoor == 1)
        {
            objectInside.GetComponent<MeshCollider>().enabled = true;
            objectInside.GetComponent<InspectManager>().enabled = true;
        }
        else if (gameObject.GetComponent<Door>().moveDoor == -1 || gameObject.GetComponent<Door>().moveDoor == 0)
        {
            objectInside.GetComponent<MeshCollider>().enabled = false;
            objectInside.GetComponent<InspectManager>().enabled = false;
        }
    }
}
