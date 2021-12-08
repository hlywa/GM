using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGameJet : MonoBehaviour
{
    public PointEffector2D jetEffector;

    void OnMouseDown()
    {
        jetEffector.enabled = true;
    }

    void OnMouseUp()
    {
        jetEffector.enabled = false;
    }
}
