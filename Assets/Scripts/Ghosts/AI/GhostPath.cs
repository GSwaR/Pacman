using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class GhostPath : MonoBehaviour
{
    public AIPath path;
    public AIDestinationSetter setter;
    public Transform[] points;

    public Transform player;
    private bool timeExpired = false;

    public Transform SpawnUp;
    public Transform SpawnDown;

    private int i = 0;

    public float timeToExit;

    private bool dir = false;
    private bool started = false;

    void Start()
    {
        setter.target = SpawnUp;
        StartCoroutine(Wait(timeToExit));
    }

    public void StartAfterEnable()
    {
        setter.target = SpawnDown;
        timeExpired = false;
        StartCoroutine(Wait(timeToExit));
    }

    public void Update()
    {
        if (timeExpired)
        {
            StopAllCoroutines();
            PickUpNextPoint();
        }
        else
        {
            if (!dir)
            {
                if (!started)
                {
                    started = true;
                    StartCoroutine(PickDown(0.2f));
                }

            }
            else
            {
                if (!started)
                {
                    started = true;
                    StartCoroutine(PickUp(0.2f));
                }

            }
        }

    }

    public void PickUpNextPoint()
    {
        if (path.reachedDestination)
        {
            if (points.Length > i)
            {
                setter.target = points[i];
                i++;
            }
            else
            {
                setter.target = player;
                this.enabled = false;
            }

        }
    }

    IEnumerator PickUp(float time)
    {
        yield return new WaitForSeconds(time);
        dir = true;
        setter.target = SpawnUp;
        started = false;
    }
    IEnumerator PickDown(float time)
    {
        yield return new WaitForSeconds(time);
        dir = false;
        setter.target = SpawnDown;
        started = false;
    }


    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        timeExpired = true;
    }

}
