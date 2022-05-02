using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class LoadNextLevel : MonoBehaviour
{
    public FirstPersonController playerScript;

    public string sceneToLoad;

    public AudioSource teleportSound;

    private GameObject sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = GameObject.Find("SceneLoader");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(loadScene());
        }          
    }

    IEnumerator loadScene()
    {
        playerScript.enabled = false;
        teleportSound.Play();
        yield return new WaitForSeconds(3);
        sceneLoader.GetComponent<SceneLoader>().sceneToLoad = sceneToLoad;
        sceneLoader.GetComponent<SceneLoader>().StartLoad();
    }
}
