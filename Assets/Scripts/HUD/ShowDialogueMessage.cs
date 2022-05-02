using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDialogueMessage : MonoBehaviour
{
    private Text textScript;
    public string[] dialogues;
    public float[] dialoguesTimeOut;
    private bool alreadyShowingDialogues;

    // Start is called before the first frame update
    private void Start()
    {
        textScript = GameObject.Find("Subtitles_Text").GetComponent<Text>();
    }
    public IEnumerator dialogueMessage()
    {
        for (int i = 0; i < dialogues.Length; i++)
        {
            textScript.text = dialogues[i];
            yield return new WaitForSeconds(dialoguesTimeOut[i]);
            textScript.text = "";
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !alreadyShowingDialogues)
        {
            alreadyShowingDialogues = true;
            StartCoroutine(dialogueMessage());
        }
    }
}
