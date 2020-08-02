using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public GameObject car;
    private GameObject gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager");
    }

    private void OnMouseDown()
    {
        if (!gm.GetComponent<GameManager>().GetIsPaused())
        {
            car.GetComponent<Movement>().move = true;
            car.GetComponent<Movement>().moveRight = !car.GetComponent<Movement>().moveRight;  
        }
    }
}
