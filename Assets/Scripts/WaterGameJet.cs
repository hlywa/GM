using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGameJet : MonoBehaviour
{
    public PointEffector2D jetEffector;

    private void Start()
    {
        GetComponent<CircleCollider2D>().isTrigger = false;
    }

    void OnMouseDown()
    {
        jetEffector.enabled = true;
    }

    void OnMouseUp()
    {
        jetEffector.enabled = false;
    }
}
