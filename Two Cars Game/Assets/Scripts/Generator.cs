using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public static float objectSpeed;
    public float startSpeed; 
    public float startCooldown;
    public float cooldown;

    public GameObject gm;

    public GameObject Blue, Red;

    private int _gen;
    private int gener , mingener , maxgener;
    private int _loc;
    private Vector3 _dest;
    private static float speed;

    private bool getHard;
    public GameObject RLN, RLF, RRN, RRF, BLN, BLF, BRN, BRF;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager");
        speed = 0.1f;
        startSpeed = 0.0f;
        startCooldown = 2.0f;
        cooldown = 2.0f;
        _gen = 0;
        _loc = 0;
        gener = 50;
        mingener = 50;
        maxgener = 100;
        getHard = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!gm.GetComponent<GameManager>().GetIsPaused())
        {
            if (gener >= maxgener)
            {
                gener = maxgener;
                getHard = false;
            }

            if (gener <= mingener)
            {
                gener = mingener;
                getHard = true;
            }
            if (speed > 15.0f)
            {
                speed = startSpeed + 1.0f;
                if (startSpeed >= 10.0f)
                {
                    startSpeed = 10.0f;
                    if (getHard)
                    {
                        gener++;
                    }
                    else
                    {
                        gener--;
                    }
                }
                else
                {
                    startSpeed += 0.2f;
                }
            }
            else if (speed > 10.0f)
            {
                objectSpeed = 10.0f;
            }
            else
            {
                objectSpeed = speed;
            }

            if (cooldown > 0)
            {
                cooldown -= Time.deltaTime;
            }
            else
            {
                create();
                cooldown = startCooldown;
                if (startCooldown > 1f)
                {
                    startCooldown -= 0.1f;
                }
                else
                {
                    startCooldown = 2.0f;
                }
            }
        }
    }

    public void create()
    {
        _gen = Random.Range(0, 100);
        _loc = Random.Range(0, 2);
        if (_loc == 1)
        {
            _dest = RLF.transform.position;
        }
        else
        {
            _dest = RLN.transform.position;
        }
        if (_gen <= gener)
        {
            Instantiate(Red, _dest, Quaternion.identity);
        }

        _gen = Random.Range(0, 100);
        if (1 - _loc == 1)
        {
            _dest = RRF.transform.position;
        }
        else
        {
            _dest = RRN.transform.position;
        }
        if (_gen <= gener)
        {
            Instantiate(Red, _dest, Quaternion.identity);
        }


        _gen = Random.Range(0, 100);
        _loc = Random.Range(0, 2);
        if (_loc == 1)
        {
            _dest = BLF.transform.position;
        }
        else
        {
            _dest = BLN.transform.position;
        }
        if (_gen <= gener)
        {
            Instantiate(Blue, _dest, Quaternion.identity);
        }

        _gen = Random.Range(0, 100);
        if (1 - _loc == 1)
        {
            _dest = BRF.transform.position;
        }
        else
        {
            _dest = BRN.transform.position;
        }
        if (_gen <= gener)
        {
            Instantiate(Blue, _dest, Quaternion.identity);
        }
    }
    
    public static void getFaster()
    {
        speed += 0.1f;
    }
}
