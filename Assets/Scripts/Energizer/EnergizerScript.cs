using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergizerScript : MonoBehaviour
{
    public StateManager stateManager;

    private void OnDestroy()
    {
        GetComponent<Animator>().StopPlayback();
        stateManager.SetState();
    }
}
