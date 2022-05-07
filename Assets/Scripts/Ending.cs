using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Ending : MonoBehaviour
{
    public GameObject sceneLoader;

    public FirstPersonController playerScript;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerScript.enabled = false;
            sceneLoader.GetComponent<SceneLoader>().sceneToLoad = "Fin";
            sceneLoader.GetComponent<SceneLoader>().StartLoad();
        }
    }
}
