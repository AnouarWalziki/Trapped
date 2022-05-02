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

    }

    // Update is called once per frame
    void Update()
    {
        if (keyInPlace && !haveMoved)
        {
            StartCoroutine(moveToShowKey());
        }
        else if(!keyInPlace && haveMoved)
        {
            StartCoroutine(moveToHideKey());
        }
    }

    IEnumerator moveToShowKey()
    {
        yield return new WaitForSeconds(1);
        MoveSound.Play();
        anim.SetBool("Open", true);
        ShowKey = true;
        haveMoved = true;
    }

    IEnumerator moveToHideKey()
    {
        yield return new WaitForSeconds(1);
        MoveSound.Play();
        anim.SetBool("Open", false);
        ShowKey = false;
        haveMoved = false;
    }

}
