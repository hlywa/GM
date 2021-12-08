using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGlowToggle : MonoBehaviour
{
    private SpriteGlow.SpriteGlowEffect spriteGlow;

    // Start is called before the first frame update
    void Start()
    {
        spriteGlow = GetComponent<SpriteGlow.SpriteGlowEffect>();
    }

    private void OnMouseEnter()
    {
        spriteGlow.OutlineWidth = 1;
    }

    private void OnMouseExit()
    {
        spriteGlow.OutlineWidth = 0;
    }
}
