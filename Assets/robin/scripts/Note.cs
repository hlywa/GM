using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Poolable))]
public class Note : MonoBehaviour
{
    private bool _canBePressed;
    private Poolable _poolable;
    [SerializeField] private KeyCode _keyToPress;
    [SerializeField] private int _score;
    [SerializeField] List<KeyCode> possibleButtons;
    private MoonCharacter _mooncharacter;
    private Animator _moonAnim;
    private Animator _sunAnim;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private ParticleSystem badHit;
    private void Awake()
    {
        _mooncharacter = FindObjectOfType<MoonCharacter>();
        _moonAnim = _mooncharacter.GetComponent<Animator>();
        _sunAnim = FindObjectOfType<SunCharacter>().GetComponent<Animator>();
    }
    private void Start()
    {
        _poolable = GetComponent<Poolable>();

        _keyToPress = possibleButtons[Random.Range(0, possibleButtons.Count)];

        float xValue = transform.position.x;


        switch (_keyToPress)
        {
            case KeyCode.UpArrow:
                xValue = -7;
                break;
            case KeyCode.DownArrow:
                xValue = -6;
                break;
            case KeyCode.RightArrow:
                xValue = -5;
                break;
            case KeyCode.LeftArrow:
                xValue = -8;
                break;
        }

        this.transform.position = new Vector3(xValue, transform.position.y);

    }
    private void Update()
    {

        if (Input.GetKeyDown(_keyToPress))
        {
            if (_canBePressed)
            {
                particle.transform.position = transform.position;
                GameEvents.OnNoteHitCheck(true, _score);
                switch (_keyToPress)
                {
                    case KeyCode.UpArrow:
                        particle.Emit(8);
                        _moonAnim.SetTrigger("Up");
                        _sunAnim.SetTrigger("Down");
                        Destroy(this.gameObject);
                        break;
                    case KeyCode.DownArrow:
                        particle.Emit(8);
                        _moonAnim.SetTrigger("Down");
                        _sunAnim.SetTrigger("Up");
                        Destroy(this.gameObject);
                        break;
                    case KeyCode.RightArrow:
                        particle.Emit(8);
                        _moonAnim.SetTrigger("Right");
                        _sunAnim.SetTrigger("Left");
                        Destroy(this.gameObject);
                        break;
                    case KeyCode.LeftArrow:
                        particle.Emit(8);
                        _moonAnim.SetTrigger("Left");
                        _sunAnim.SetTrigger("Right");
                        Destroy(this.gameObject);
                        break;
                    default:
                        break;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ActivateSpace")
        {
            _canBePressed = true;
        }
        if (collision.tag == "FailSpace")
        {
            _moonAnim.SetTrigger("Miss");
            GetComponent<SpriteRenderer>().color = Color.red;
            GameEvents.OnNoteHitCheck(false, _score);
            StartCoroutine(DeleteNote());
        }
    }

    private IEnumerator DeleteNote()
    {
        yield return new WaitForSeconds(0.2f);
        badHit.transform.position = transform.position;
        badHit.Emit(8);
        Destroy(this.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ActivateSpace")
        {
            _canBePressed = false;
        }
    }
}
