using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class InsideRoom2 : MonoBehaviour
{
    public GameObject doorOb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorOb.GetComponent<Door>().enabled = false;
            doorOb.GetComponent<DoorWithKey>().enabled = true;
            doorOb.GetComponent<Animator>().SetBool("Open", false);
            doorOb.GetComponent<Door>().doorCloseSound.Play();
            Destroy(gameObject);
        }
    }
}
