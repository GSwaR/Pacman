using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingInputHandler : InputHandler
{
    private Command Button;
    //private Command ContinueButton;

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
        //ContinueButton = ScriptableObject.CreateInstance<ContinueMoving>();
    }
}

class Moving : Command
{
    protected Vector2 previousDirection = Vector2.left;

    public override void Execute(GameObject gameObject, Vector2 direction, Vector2 pos, float speed)
    {
        if (direction != Vector2.zero && isWall(gameObject, direction))
        {
            Vector2 position = Vector2.MoveTowards(gameObject.transform.position, pos, speed);
            previousDirection = direction;
            gameObject.GetComponent<Rigidbody2D>().MovePosition(position);
        }
        else if (isWall(gameObject, previousDirection))
        {
            pos = (Vector2)gameObject.transform.position + previousDirection;
            Vector2 position = Vector2.MoveTowards(gameObject.transform.position, pos, speed);
            gameObject.GetComponent<Rigidbody2D>().MovePosition(position);
        }
        
    }

    protected bool isWall(GameObject gameObject, Vector2 direction)
    {
        Vector2 pos = gameObject.transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + direction * 1.15f, pos);
        return !(hit.collider.CompareTag("obstacle"));
    }

}


//class ContinueMoving : Moving
//{
//    public override void Execute(GameObject gameObject, Vector2 direction, Vector2 pos, float speed)
//    {
//        Debug.Log(previousDirection);
//        if (isWall(gameObject, previousDirection))
//        {
            
//            pos = (Vector2)gameObject.transform.position + previousDirection;
//            Vector2 position = Vector2.MoveTowards(gameObject.transform.position, pos, speed);
//            gameObject.GetComponent<Rigidbody2D>().MovePosition(position);
//        }
//        else if (isWall(gameObject, direction))
//        {
//            Vector2 position = Vector2.MoveTowards(gameObject.transform.position, pos, speed);
//            //previousDirection = direction;
//            gameObject.GetComponent<Rigidbody2D>().MovePosition(position);
//        }
//    }
//}

public class DirrectionHandler 
{

    public Vector2 HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {

            return Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {

            return Vector2.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
  
            return Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            return Vector2.right;
        }
        else return Vector2.zero;
    }
} 
