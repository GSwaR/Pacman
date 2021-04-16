using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public float time;

    public GhostState[] ghostsStates;

    public void SetState()
    {
        for (int i = 0; i < ghostsStates.Length; i++)
        {
            if (!ghostsStates[i].GetComponent<Animator>().GetBool("Dead"))
            {
                ghostsStates[i].SetState(true);
            }
        }

        StartCoroutine(Wait(time));
    }

    public void SetDefaultState()
    {
        for (int i = 0; i < ghostsStates.Length; i++)
        {
            if (!ghostsStates[i].GetComponent<Animator>().GetBool("Dead"))
            {
                ghostsStates[i].SetState(false);
            }
        }
    }


    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        SetDefaultState();
    }
}
