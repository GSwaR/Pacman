using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManAnimation : AnimationInputHandler
{
    // this class is responsible for animations of pacman
    private Animator animator;
    private DirrectionHandler handler;

    void OnEnable()
    {
        animator = GetComponent<Animator>();
        handler = new DirrectionHandler();
    }

    void FixedUpdate()
    {
        Vector2 direction = handler.HandleInput();
        Command command = HandleInput();
        if (command)
        {
            command.Execute(animator, gameObject, direction, 1.2f);
        }
    }

    


}
