using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapRooms : MonoBehaviour
{
    public GameObject roomToRemove;

    public Vector3 posToSpawnNewRoom;

    public AudioSource roomMovingSound;

    private PadLock padlockSript;

    private bool moveRoom;

    private bool newRoomAlreadyInPlace;

    // Start is called before the first frame update
    void Start()
    {
        padlockSript = FindObjectOfType<PadLock>().GetComponent<PadLock>();
    }

    // Update is called once per frame
    void Update()
    {
        moveRoom = padlockSript.lockOpened;

        if(moveRoom && !newRoomAlreadyInPlace)
        {
            Destroy(roomToRemove);
            StartCoroutine(StartMovingRoom());
        }
    }

    IEnumerator StartMovingRoom()
    {
        roomMovingSound.Play();

        newRoomAlreadyInPlace = true;

        float lerpDuration = 3.0f;

        float timeElapsed = 0.0f;

        Vector3 startPos = transform.position;

        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(startPos,
                    posToSpawnNewRoom, timeElapsed / lerpDuration);

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = posToSpawnNewRoom;
    }
}
