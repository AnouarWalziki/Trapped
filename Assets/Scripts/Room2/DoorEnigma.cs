using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnigma : MonoBehaviour
{
    public bool doorIsClosed;
    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (doorIsClosed)
        {
            Destroy(wall);
            Destroy(gameObject);
        }         
    }
}