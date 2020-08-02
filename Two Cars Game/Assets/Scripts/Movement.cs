using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject right;
    public GameObject left;
    private Vector3 _destination;
    private Quaternion _targetRotation;
    public bool moveRight;
    public bool move;
    private float _speed;
    private GameObject gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager");
        moveRight = true;
        _speed = 10.0f;
        transform.position = right.GetComponent<Transform>().position;
        _destination = transform.position;
    }

    private void FixedUpdate()
    {
        if (move)
        {
            if (!gm.GetComponent<GameManager>().GetIsPaused())
            {
                if (moveRight)
                {
                    _destination = right.GetComponent<Transform>().position;
                }
                else
                {
                    _destination = left.GetComponent<Transform>().position;
                }
            }


            move = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, _destination, _speed * Time.deltaTime);
        
    }
}