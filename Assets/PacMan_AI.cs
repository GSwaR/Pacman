using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PacMan_AI : MonoBehaviour
{
    public AudioSource audio;
    public void GameReset()
    {
        SceneManager.LoadScene("gameScene", LoadSceneMode.Single);
    }

    public void OnKill()
    {
        audio.Play();
        GetComponent<PacManMoving>().enabled = false;
        GetComponent<Animator>().SetBool("isDead", true);
    }

}
