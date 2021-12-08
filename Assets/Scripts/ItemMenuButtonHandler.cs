using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemMenuButtonHandler : MonoBehaviour
{
    public enum MenuAction { CLOSE, KEEP, TRASH, PLAY }

    public MenuAction menuAction;

    private ItemMenuManager itemMenuManager;
    private ItemManager itemManager;

    private void Start()
    {
        itemMenuManager = GetComponentInParent<ItemMenuManager>();
        itemManager = FindObjectOfType<ItemManager>();
    }

    private void OnMouseDown()
    {
        if (menuAction == MenuAction.KEEP)
        {
            itemMenuManager.lastClickedItem.StartCoroutine("SendToKeepBox");
        }
        else if (menuAction == MenuAction.TRASH)
        {
            itemMenuManager.lastClickedItem.StartCoroutine("SendToTrash");
        }
        else if (menuAction == MenuAction.PLAY)
        {
            itemMenuManager.miniGame.SetActive(true);
            itemMenuManager.Show(false);
        }

        if (menuAction != MenuAction.PLAY)
        {
            itemMenuManager.Show(false);
            itemManager.SetItemsClickable(true);
        }
    }
}
