using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorIsClosed : MonoBehaviour
{
    public DoorEnigma doorEnigma;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void doorIsClosed()
    {
        doorEnigma.doorIsClosed = true;
    }
}
