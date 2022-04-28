using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsCloseToLock : MonoBehaviour
{
    static public bool playerIsCloseToLock = false;

    void OnEnablePlayerIsCloseToLock()
    {
        playerIsCloseToLock = true;
    }

    void OnDisablePlayerIsCloseToLock()
    {
        playerIsCloseToLock = false;
    }
}
