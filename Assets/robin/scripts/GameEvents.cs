using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static Action<bool,int> OnNoteHitCheck = (hasBeenHit, scoreToAdd) => { };
}
