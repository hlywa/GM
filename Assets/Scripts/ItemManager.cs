using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ItemManager : MonoBehaviour
{
    public Color spriteGlowColor;
    private GameObject[] items;
    private GameObject[] navArrows;

    void Start()
    {
        items = GameObject.FindGameObjectsWithTag("ClickableItem");
        navArrows = GameObject.FindGameObjectsWithTag("Arrows");

        foreach (GameObject item in items)
        {
            SpriteGlow.SpriteGlowEffect spriteGlowEffect = item.AddComponent<SpriteGlow.SpriteGlowEffect>();
            item.AddComponent<ItemGlowToggle>();

            spriteGlowEffect.GlowColor = spriteGlowColor;
            spriteGlowEffect.OutlineWidth = 0;
        }

        SetItemsClickable(false);
    }

    public void SetItemsClickable(bool value)
    {
        foreach (GameObject item in items)
        {
            item.GetComponent<Clickable2D>().ClickEnabled = value;
            item.GetComponent<SpriteGlow.SpriteGlowEffect>().enabled = value;
        }

        foreach (GameObject arrow in navArrows)
        {
            arrow.GetComponent<SpriteRenderer>().enabled = value;
            arrow.GetComponent<BoxCollider2D>().enabled = value;
        }
    }
}
