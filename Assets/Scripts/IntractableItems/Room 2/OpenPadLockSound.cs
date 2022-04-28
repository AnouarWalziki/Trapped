using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPadLockSound : MonoBehaviour
{
    public AudioSource openPadlockSound;
    // Start is called before the first frame update
    
    void PlayOpenPadLockSound()
    {
        openPadlockSound.Play();
    }
}
