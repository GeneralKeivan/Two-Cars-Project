using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyCarMovement : MonoBehaviour
{
    public GameObject redCar;
    public GameObject blueCar;
    private GameObject gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager");
    }

    private void OnMouseOver()
    {
        if (!gm.GetComponent<GameManager>().GetIsPaused())
        {
            if (Input.GetMouseButtonDown(0))
            {
                redCar.GetComponent<Movement>().move = true;
                redCar.GetComponent<Movement>().moveRight = !redCar.GetComponent<Movement>().moveRight;
            }
            if (Input.GetMouseButtonDown(1))
            {
                blueCar.GetComponent<Movement>().move = true;
                blueCar.GetComponent<Movement>().moveRight = !blueCar.GetComponent<Movement>().moveRight;
            }
        }
    }
}
