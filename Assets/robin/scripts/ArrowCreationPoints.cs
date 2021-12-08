using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class ArrowCreationPoints : MonoBehaviour
{
    public ArrowType arrowtype;
    public KeyCode buttonToPress;
    private ObjectPool _pool;
    private Scroller _scroller;
    public Animator ArrowCircle;
    private void Start()
    {
        _pool = GetComponent<ObjectPool>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(buttonToPress))
        {
            ArrowCircle.SetTrigger("lit");
        }
    }

    public void Create(Color col)
    {
        Poolable newArrow = _pool.Claim();
        newArrow.gameObject.GetComponent<SpriteRenderer>().color = col;
        newArrow.transform.position = this.transform.position;
        newArrow.transform.parent = _scroller.transform;
    }
    public void SetScroller(Scroller scroller)
    {
        _scroller = scroller;
    }
}
