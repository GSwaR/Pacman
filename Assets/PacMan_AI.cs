using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PacMan_AI : MonoBehaviour
{
    public void GameReset()
    {
        SceneManager.LoadScene("gameScene", LoadSceneMode.Single);
    }

    public void OnKill()
    {
        GetComponent<PacManMoving>().enabled = false;
        GetComponent<Animator>().SetBool("isDead", true);
    }

}
