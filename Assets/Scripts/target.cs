using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    private Vector2 followSpot;
    public float speed;

    public bool inDialog;
    public bool cutSceneInProgress;

    public void ExitDialogue()
    {
        inDialog = false;
        cutSceneInProgress = false;
    }

    public void EnterDialogue()
    {
        inDialog = true;
        cutSceneInProgress = true;
    }

}
