using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    public GameObject flames;

    public AudioSource lighterSound;

    public bool onFire;
    // Start is called before the first frame update
    void Start()
    {
        flames.SetActive(false);
        onFire = false;
    }

    private void OnDisable()
    {
        onFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!onFire && Input.GetButtonDown("ToggleOnOff"))
        {
            lighterSound.Play();
            flames.SetActive(true);
            onFire = true;
        }
        else if (onFire && Input.GetButtonDown("ToggleOnOff"))
        {
            flames.SetActive(false);
            onFire = false;
        }
    }
}
