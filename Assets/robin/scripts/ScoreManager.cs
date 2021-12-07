using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fungus;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private float _health = 1;
    [SerializeField] public bool _isdroppingHealth;
    [SerializeField] private Image HealthBar;
    private Scroller _scroller;
    private bool _isDecreasingHealth;
    [SerializeField] private Flowchart _flowchart;
    private int _lossAmount = 0;
    private bool lost;
    public string fightLossBit;
    private void Awake()
    {
        _flowchart.SetFloatVariable("Health", 1);
        GameEvents.OnNoteHitCheck += UpdateScore;
        _scroller = FindObjectOfType<Scroller>();
    }
    private void OnDestroy()
    {
        GameEvents.OnNoteHitCheck -= UpdateScore;
    }
    public void Update()
    {
        _flowchart.SetFloatVariable("Health", _health);
        HealthBar.fillAmount = _health;
        if(_health > 1)
        {
            _health = 1;
        }


        if(!_scroller._isStarted)
        {
            _isdroppingHealth = false;
            _isDecreasingHealth = false;
        }
        else
        {
            _isdroppingHealth = true;
            if (!_isDecreasingHealth)
            {
                StartCoroutine(HealthDrop());
                _isDecreasingHealth = true;
            }
        }

        if(_health <= 0)
        {
            _scroller._isStarted = false;
            _scroller._songNotes[0].SetActive(false);
            StartCoroutine(_scroller.LowerVolume());
            _flowchart.ExecuteBlock(_scroller.nextBlock);
            if (!lost)
            {
                GameManager.Instance.Lost();
                lost = true;
            }
            _flowchart.SetIntegerVariable(_scroller.failOrWin[_scroller.n], GameManager.Instance.losses);
        }


    }

    public IEnumerator HealthDrop()
    {
        while(_isdroppingHealth)
        {
            yield return new WaitForSecondsRealtime(1f);
            _health -= 0.03f;
        }
    }
    private void UpdateScore(bool hasBeenHit,int scoreToAdd)
    {
        if (hasBeenHit)
        {
            _health += 0.05f;
        }
        else
        {
            _health -= 0.04f;
        }
    }
}
