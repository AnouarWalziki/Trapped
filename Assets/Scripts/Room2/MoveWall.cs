using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public AudioSource movingSound;

    private Animator anim;   

    private bool startMovingWall;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        startMovingWall = FindObjectOfType<XOChallenge>().challengDone;

        if(startMovingWall)
        {
            StartCoroutine(startMovingAnimation());
            gameObject.GetComponent<MoveWall>().enabled = false;
        }

    }

    IEnumerator startMovingAnimation()
    {
        yield return new WaitForSeconds(3);
        anim.SetBool("Move", true);
        movingSound.Play();
    }
}
