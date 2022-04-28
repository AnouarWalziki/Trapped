using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveImageWithKey : MonoBehaviour
{
    public Animator anim;

    public AudioSource MoveSound;

    public bool ShowKey;

    public bool haveMoved;

    public bool keyInPlace;

    // Start is called before the first frame update
    void Start()
    {
        ShowKey = false;
        keyInPlace = false;
        haveMoved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyInPlace)
        {
            anim.SetBool("Open", true);
            MoveSound.Play();
            ShowKey = true;
            haveMoved = true;
        }
        else if(!keyInPlace && haveMoved)
        {
            anim.SetBool("Open", false);
            MoveSound.Play();
            ShowKey = false;
            haveMoved = false;
        }
    }
}
