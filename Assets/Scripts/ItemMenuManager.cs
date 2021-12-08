using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemMenuManager : MonoBehaviour
{
    public Collider2D exitButton;
    public Collider2D keepButton;
    public Collider2D trashButton;
    public Collider2D playButton;

    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;

    public Transform trashTransform;
    public Transform keepTransform;

    public GameObject miniGame;

    public bool showing = false; 

    private GameObject[] menuChildren;
    [HideInInspector]
    public ClickItemHandler lastClickedItem;

    private void Start()
    {
        menuChildren = GameObject.FindGameObjectsWithTag("MenuItemObject");
    }

    public void Show(bool value, bool withPlayButton = false)
    {
        foreach (GameObject child in menuChildren)
        {
            if (value == true && child == playButton.gameObject && !withPlayButton)
            {
                continue;
            }

            child.GetComponent<SpriteRenderer>().enabled = value;

            Collider2D collider = child.GetComponent<Collider2D>();

            if (collider) {
                collider.enabled = value;
            }
        }

        if (value)
        {
            SetItemText(lastClickedItem.name.Replace(" Item", ""), lastClickedItem.description);
        }
        else
        {
            SetItemText("", "");
        }

        showing = value;
    }

    public void SetItemText(string name, string description)
    {
        itemName.text = name;
        itemDescription.text = description;
    }
}
