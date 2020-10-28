using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManMoving : MovingInputHandler
{
    public float speed = 0.5f;
    private DirrectionHandler handler;
    private Vector2 dest;

    private void Start()
    {
        handler = new DirrectionHandler();
        dest = transform.position;
    }

    void FixedUpdate()
    {
        
        Vector2 direction = handler.HandleInput();
        Command command = HandleInput();
        if (command)
        {
            dest = (Vector2)transform.position + direction;
            command.Execute(gameObject, direction, dest, speed);
            
        }

    }

}
