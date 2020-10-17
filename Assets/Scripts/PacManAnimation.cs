using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManAnimation : AnimationInputHandler
{
    // this class is responsible for animations of pacman
    private Animator animator;

    void OnEnable()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Command command = HandleInput();
        if (command)
        {
            command.Execute(animator);
        }
    }

    


}
