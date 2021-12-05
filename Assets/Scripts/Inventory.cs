using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using System.Linq;

public class Inventory : MonoBehaviour
{

    private MenuDialog[] menuDialogs;
    private SayDialog[] sayDialogs;
    public CanvasGroup canvasGroup;

    public InventoryItem[] inventoryItems;
    public ItemSlot[] itemSlots;

    private Flowchart[] flowcharts;

    // Start is called before the first frame update
    void Start()
    {
        menuDialogs = FindObjectsOfType<MenuDialog>();
        sayDialogs = FindObjectsOfType<SayDialog>();
        flowcharts = FindObjectsOfType<Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            ToggleInventory(!canvasGroup.interactable);
        }
    }

    private void ToggleInventory(bool setting)
    {
        JournalTools.ToggleCanvasGroup(canvasGroup, setting);
        InitializeItemSlots();

        if (!target.CutSceneInProgress)
        {
            target.inDialog = setting;
        }

        foreach (MenuDialog menuDialog in MenuDialogs)
        {
            JournalTools.ToggleCanvasGroup(menuDialog.GetComponent<CanvasGroup>(), !setting);
        }

        foreach (SayDialog in SayDialogs)
        {
            JournalTools.ToggleCanvasGroup(menuDialog.GetComponent<CanvasGroup>(), !setting);
        }
    }

    public void InitializeItemSlots()
    {
        List<InventoryItem> ownedItems = GetOwnedItems(inventoryItems.ToList());
    }
    private void ToggleCanvasGroup(CanvasGroup canvasGroup, bool setting)
    {
        canvasGroup.alpha = setting ? 1f : 0f;
        canvasGroup.interactable = setting;
        canvasGroup.blocksRaycasts = setting;

    }
}
