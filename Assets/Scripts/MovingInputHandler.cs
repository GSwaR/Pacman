using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingInputHandler : InputHandler
{
    private Command Button;

    public override Command HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow)) return Button;
        else if (Input.GetKey(KeyCode.DownArrow)) return Button;
        else if (Input.GetKey(KeyCode.LeftArrow)) return Button;
        else if (Input.GetKey(KeyCode.RightArrow)) return Button;

        else return Button;
    }

    private void Awake()
    {
        Button = ScriptableObject.CreateInstance<Moving>();
    }
}

class Moving : Command
{
    public override void Execute(GameObject gameObject, Vector2 direction, Vector2 pos, float speed)
    {
        if (isWall(gameObject, direction))
        {
            Vector2 position = Vector2.MoveTowards(gameObject.transform.position, pos, speed);
            gameObject.GetComponent<Rigidbody2D>().MovePosition(position);
        }
        else
        {

        }
        

    }

    private bool isWall(GameObject gameObject, Vector2 direction)
    {
        Vector2 pos = gameObject.transform.position;

        RaycastHit2D hit = Physics2D.Linecast(pos + direction * 0.45f, pos);
        return (hit.collider == gameObject.GetComponent<Collider2D>());
    }

}

public class DirrectionHandler 
{
    private Vector2 previousDirection = Vector2.zero;
    public Vector2 HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            previousDirection = Vector2.up;
            return Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            previousDirection = Vector2.down;
            return Vector2.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            previousDirection = Vector2.left;
            return Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            previousDirection = Vector2.right;
            return Vector2.right;
        }
        else return previousDirection;
    }
}