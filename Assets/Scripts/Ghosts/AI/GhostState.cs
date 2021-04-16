using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GhostState : MonoBehaviour
{
    private GhostPath ghostPath;
    public Collider2D collider;

    public AIPath path;
    public Animator animator;
    public AIDestinationSetter setter;

    public Transform[] points;

    public Transform player;

    public bool State = false;

    public Transform spawner;

    private void Start()
    {
        ghostPath = gameObject.GetComponent<GhostPath>();
    }

    public void SetState(bool state) // false - default state
    {
        if (state)
        {
            int rnd = Random.Range(0, points.Length);
            setter.target = points[rnd];
            animator.SetBool("WalkingDead", true);
        }
        else
        {
            animator.SetBool("WalkingDead", false);
            setter.target = player;
        }

        State = state;
    }

    public void Update()
    {
        if (State && !animator.GetBool("Dead"))
        {
            PickUpNextPoint();
        }

        if (animator.GetBool("Dead"))
        {
            setter.target = spawner;
            if (path.reachedDestination)
            {
                ghostPath.enabled = true;
                ghostPath.StartAfterEnable();
                animator.SetBool("Dead", false);
                collider.enabled = true;
            }
        }

    }

    public void PickUpNextPoint()
    {
        if (path.reachedDestination)
        {
            int rnd = Random.Range(0, points.Length);
            setter.target = points[rnd];
        }
    }

    public void OnBecameDead()
    {
        State = false;
        collider.enabled = false;
        animator.SetBool("Dead", true);
        animator.SetBool("WalkingDead", false);

        setter.target = spawner;
    }

    public void OnBecameAllive()
    {
        collider.enabled = true;
        setter.target = player;
        animator.SetBool("WalkingDead", false);
        animator.SetBool("Dead", false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (State)
        {
            if (collision.CompareTag("Player"))
            {
                OnBecameDead();
            }
        }
        else
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PacMan_AI>().OnKill();
                collider.enabled = false;
            }
        }
    }
}
