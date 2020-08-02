using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public Sprite Square, Circle;

    public GameObject gm;

    private Color _color;
    private float _startAlpha;
    private SpriteRenderer _spriteRenderer;
    private int _sprite;
    void Start () {	
        gm = GameObject.Find("GameManager");
        _sprite = Random.Range (0, 2);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_sprite == 0)
        {
            _spriteRenderer.sprite = Circle;
            gameObject.tag = "Circle";
        }
        else
        {
            _spriteRenderer.sprite = Square;
            gameObject.tag = "Square";
        }

        _color = _spriteRenderer.color;
        _startAlpha = _color.a;
    }

    void FixedUpdate()
    {
        if (!gm.GetComponent<GameManager>().GetIsPaused())
        {
            transform.position += Vector3.down * Generator.objectSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("End Line"))
        {
            if (gameObject.CompareTag("Circle"))
            {
                gm.GetComponent<GameManager>().SetIsPaused(true);
                gm.GetComponent<GameManager>().Lose();
                StartCoroutine(Flasher());
            }

            if (gameObject.CompareTag("Square"))
            {
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("Car"))
        {
            if (gameObject.CompareTag("Circle"))
            {
                gm.GetComponent<GameManager>().AddScore();
                gm.GetComponent<AudioManager>().Play("Pop");
                Destroy(gameObject);
            }

            if (gameObject.CompareTag("Square"))
            {
                gm.GetComponent<GameManager>().SetIsPaused(true);
                gm.GetComponent<GameManager>().Lose();
                StartCoroutine(Flasher());
            }
        }
    }
    IEnumerator Flasher() 
    {
        for (int i = 0; i < 5; i++)
        {
            _color.a = 0;
            _spriteRenderer.color = _color;
            yield return new WaitForSeconds(.2f);
            _color.a = _startAlpha;
            _spriteRenderer.color = _color;
            yield return new WaitForSeconds(.2f);
        }
    }
}
