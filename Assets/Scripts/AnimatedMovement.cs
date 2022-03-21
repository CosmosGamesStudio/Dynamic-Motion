using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedMovement : MonoBehaviour
{
    public DirectionType directionOfMovement;


    [Range(0, 10f)]
    public float speed = 2;

    public float distance;
    private float minHorizontal, maxHorizontal;
    private float minVertical, maxVertical;
    private float maxSlashVertical, maxSlashHorizontal, minSlashVertical, minSlashHorizontal;
    private float maxBackSlashVertical, maxBackSlashHorizontal, minBackSlashVertical, minBackSlashHorizontal;


    public bool reverse, dontMove;
    private bool stop;


    void Start()
    {
        if (directionOfMovement.ToString() == "Horizontal")
        {
            maxHorizontal = transform.position.x + distance;
            minHorizontal = transform.position.x - distance;
        }
        else if(directionOfMovement.ToString() == "Vertical")
        {
            maxVertical = transform.position.y + distance;
            minVertical = transform.position.y - distance;
        }
        else if(directionOfMovement.ToString() == "Slash")
        {
            maxSlashHorizontal = transform.position.x + distance;
            maxSlashVertical = transform.position.y + distance;

            minSlashHorizontal = transform.position.x - distance;
            minSlashVertical = transform.position.y - distance;
        }
        else if(directionOfMovement.ToString() == "BackSlash")
        {
            maxBackSlashHorizontal = transform.position.x - distance;
            maxBackSlashVertical = transform.position.y + distance;

            minBackSlashHorizontal = transform.position.x + distance;
            minBackSlashVertical = transform.position.y - distance;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!stop && !dontMove)
        {
            if (reverse)
            {
                if (directionOfMovement.ToString() == "Horizontal")
                {
                    transform.position += Vector3.right * speed * Time.deltaTime;
                    if (transform.position.x >= maxHorizontal)
                    {
                        reverse = false;
                    }
                }
                else if(directionOfMovement.ToString() == "Vertical")
                {
                    transform.position += Vector3.up * speed * Time.deltaTime;
                    if (transform.position.y >= maxVertical)
                    {
                        reverse = false;
                    }
                }
                else if(directionOfMovement.ToString() == "Slash")
                {
                    transform.position += Vector3.up * speed * Time.deltaTime;
                    transform.position += Vector3.right * speed * Time.deltaTime;
                    if (transform.position.x >= maxSlashHorizontal && transform.position.y >= maxSlashVertical)
                    {
                        reverse = false;
                    }
                }
                else if(directionOfMovement.ToString() == "BackSlash")
                {
                    transform.position += Vector3.up * speed * Time.deltaTime;
                    transform.position += Vector3.left * speed * Time.deltaTime;
                    if (transform.position.x <= maxBackSlashHorizontal && transform.position.y >= maxBackSlashVertical)
                    {
                        reverse = false;
                    }
                }

            }
            else 
            {
                if (directionOfMovement.ToString() == "Horizontal")
                {
                    transform.position += Vector3.left * speed * Time.deltaTime;
                    if (transform.position.x <= minHorizontal)
                    {
                        reverse = true;
                    }
                }
                else if(directionOfMovement.ToString() == "Vertical")
                {
                    transform.position += Vector3.down * speed * Time.deltaTime;
                    if (transform.position.y <= minVertical)
                    {
                        reverse = true;
                    }
                }
                else if(directionOfMovement.ToString() == "Slash")
                {
                    transform.position += Vector3.down * speed * Time.deltaTime;
                    transform.position += Vector3.left * speed * Time.deltaTime;
                    if (transform.position.x <= minSlashHorizontal && transform.position.y <= minSlashVertical)
                    {
                        reverse = true;
                    }
                }
                else if(directionOfMovement.ToString() == "BackSlash")
                {
                    transform.position += Vector3.down * speed * Time.deltaTime;
                    transform.position += Vector3.right * speed * Time.deltaTime;
                    if (transform.position.x >= minBackSlashHorizontal && transform.position.y <= minBackSlashVertical)
                    {
                        reverse = true;
                    }
                }

            }
        }
    }

    public enum DirectionType
    {
        Horizontal, Vertical, Slash, BackSlash
    }

}
