using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDirectionUpdater : MonoBehaviour
{
    public Animator animator;
    public Vector3 movement;
    public Vector3 lastMovement;

    public SpriteRenderer spriteRenderer;

    public void Start()
    {
        StartCoroutine(Wait(0.1f));
        lastMovement = new Vector3();
    }

    // TODO: develop state machine

    IEnumerator Wait(float time)
    {
        while (true)
        {
            // set current movement
            Vector3 currentMovementDirection = (lastMovement - transform.position).normalized * -1f;

            if (lastMovement != transform.position)
            {
                movement.x = currentMovementDirection.x;
                movement.y = currentMovementDirection.y;

                animator.SetFloat("Horisontal", movement.x);
                animator.SetFloat("Vertical", movement.y);

            }
            else
            {
                animator.SetFloat("Horisontal", movement.x);
                animator.SetFloat("Vertical", movement.y);

            }
            lastMovement = transform.position;

            yield return time;
        }

    }
}
