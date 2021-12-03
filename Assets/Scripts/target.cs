using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    private Vector2 followSpot;
    public float speed;


    void Start()
    {
        followSpot = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            followSpot = new Vector2(mousePosition.x, mousePosition.y);
        }
        transform.position = Vector2.MoveTowards(transform.position, followSpot, Time.deltaTime * speed);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        followSpot = transform.position;
    }


}
