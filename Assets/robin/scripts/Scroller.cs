using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Scroller : MonoBehaviour
{
    private int randNum;
    private int RanNumVariation = 0;
    public float tempo;
    public float speedPerSecond;
    public bool _isStarted;
    private bool _musicPlayin = false;
    [SerializeField] private bool _hasSecondCharacter;
    [SerializeField] private ArrowCreationPoints[] _arrowCreationPoints;
    private bool _startCoroutine;
    [SerializeField] float[] timeVariation;
    [SerializeField] Color FirstCharacter;
    [SerializeField] Color SecondCharacter;
    [SerializeField] private AudioSource _battle1;
    [SerializeField] private Flowchart _flowchart;
    private float audio1Volume = 1.0f;
    public string nextBlock;
    public List<GameObject> _songNotes;
    public List<string> blocksToUse;
    public List<string> failOrWin;
    public int n = 0;
    private ScoreManager score;
    public float stopMusicTime;
    private void Start()
    {
        score = FindObjectOfType<ScoreManager>();
        tempo = tempo / speedPerSecond;

        nextBlock = blocksToUse[0];

        foreach (ArrowCreationPoints ACP in _arrowCreationPoints)
        {
            ACP.SetScroller(this);
        }
    }

    public void Update()
    {
        if (_isStarted)
        {
            transform.position -= new Vector3(0f, tempo * Time.deltaTime, 0f);
            if (!_startCoroutine)
            {
                _startCoroutine = true;
            }

        }
    }
    public void NextSection()
    {
        n++;
        nextBlock = blocksToUse[n];
        foreach(GameObject obj in _songNotes)
        {
            obj.SetActive(false);
        }
        _songNotes[n].SetActive(true);
    }
    public void startmusic()
    {
        if (!_musicPlayin)
        {
            _battle1.Play();
            StartCoroutine(stopMusic());
            _musicPlayin = true;
        }
    }
    public IEnumerator stopMusic()
    {
        yield return new WaitWhile(()=> _battle1.isPlaying);
        StartCoroutine(LowerVolume());
        _isStarted = false;
        score._isdroppingHealth = false;
        _songNotes[0].SetActive(false);
        GameManager.Instance.StartNext();
        _flowchart.ExecuteBlock("Fight 1");
    }
    public IEnumerator LowerVolume()
    {
        while (audio1Volume > 0.0)
        {
            audio1Volume -= 0.05f;
            yield return new WaitForSeconds(0.05f);
            _battle1.volume = audio1Volume;
        }
    }
    private IEnumerator GetRandomArrow()
    {
        if (_isStarted)
        {
            yield return new WaitForSecondsRealtime(timeVariation[RanNumVariation]);
            RanNumVariation++;
            if(RanNumVariation >= timeVariation.Length)
            {
                RanNumVariation = 0;
            }
            randNum = Random.Range(0, _arrowCreationPoints.Length);
            ArrowCreationPoints prefab = _arrowCreationPoints[randNum];
            prefab.Create(FirstCharacter);


            int probability = Random.Range(0, 3);
            if (probability == 1)
            {
                if (_hasSecondCharacter)
                {
                    if (randNum == _arrowCreationPoints.Length - 1)
                    {
                        randNum = -1;
                    }

                    ArrowCreationPoints prefab2 = _arrowCreationPoints[randNum + 1];
                    prefab2.Create(SecondCharacter);
                }
            }
        }
    }
}
    public enum ArrowType
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }