using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ClickItemHandler : MonoBehaviour
{
    public string description;
    public float lerpDuration = 0.5f; 

    private ItemMenuManager itemMenuManager;

    void Start()
    {
        itemMenuManager = FindObjectOfType<ItemMenuManager>();
    }

    private void OnMouseDown()
    {
        if (!itemMenuManager.showing)
        {
            itemMenuManager.lastClickedItem = this;
        }
    }

    IEnumerator SendToTrash()
    {
        yield return LerpPosition(itemMenuManager.trashTransform.position, lerpDuration);
        gameObject.SetActive(false);
    }

    IEnumerator SendToKeepBox()
    {
        yield return LerpPosition(itemMenuManager.keepTransform.position, lerpDuration);
        gameObject.SetActive(false);
    }

    IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    {
        float time = 0;
        Vector2 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }


    // tinkering with more dynamic Fungus integration
    //public Flowchart flowchart;
    //public string[] dialog;

    //private bool firstClick = true;
    //private Block savedBlock;

    //private void OnMouseDown()
    //{
    //    if (firstClick)
    //    {
    //        Block sayBlock = flowchart.FindBlock("Say Item Dialog");
    //        List<Command> commandList = sayBlock.CommandList;
    //        int originalCount = commandList.Count;

    //        savedBlock = flowchart.CreateBlock(Vector2.zero);


    //        for (int i = originalCount - 2; i >= 0; i--)
    //        {
    //            Say say = (Say)commandList[i];

    //            if (i < dialog.Length)
    //            {
    //                say.SetStandardText(dialog[i]);

    //                savedBlock.CommandList[i] = (Command)say;
    //            }
    //            else
    //            {
    //                savedBlock.CommandList.Remove(say);
    //            }
    //        }

    //        firstClick = false;
    //    }

    //    savedBlock.Execute();
    //}
}
