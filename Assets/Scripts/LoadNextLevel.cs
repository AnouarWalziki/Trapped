using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextLevel : MonoBehaviour
{
    public string sceneToLoad;

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
            sceneLoader.GetComponent<SceneLoader>().sceneToLoad = sceneToLoad;
            sceneLoader.GetComponent<SceneLoader>().StartLoad();
        }
            

    }
}
