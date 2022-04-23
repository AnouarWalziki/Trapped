using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class Ladder : MonoBehaviour
{
    public Transform playerController;
    bool inside = false;
    public float speed = 3f;
    public FirstPersonController player;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<FirstPersonController>();
        inside = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inside == true && Input.GetAxisRaw("Vertical") > 0)
        {
            player.transform.position += Vector3.up / speed * Time.deltaTime;
            sound.enabled = true;
            sound.loop = true;
        }
        else if (inside == true && Input.GetAxisRaw("Vertical") < 0)
        {
            player.transform.position += Vector3.down / speed * Time.deltaTime;
        }
        else
        {
            sound.enabled = false;
            sound.loop = false;
        }




    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ladder")
        {
            //Debug.Log("Touching Ladder true");
            player.enabled = false;
            inside = !inside;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            //Debug.Log("Touching Ladder false");
            player.enabled = true;
            inside = !inside;
        }
    }

}
