using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class StartSong : MonoBehaviour
{
    private Scroller _scroller;
    public bool _startPlaying;
    public bool _scrollingstarted = false;
    void Start()
    {
        _scroller = FindObjectOfType<Scroller>();
    }
    private void Update()
    {
        if(_startPlaying)
        {
            if (!_scrollingstarted)
            {
                _scroller._isStarted = true;
                _scrollingstarted = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            _scroller.startmusic();
        }
    }

}
