using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInputHandler : InputHandler
{
    private Command Button;
    //private Command ButtonUp;
    //private Command ButtonDown;
    //private Command ButtonLeft;
    //private Command ButtonRight;v

    public override Command HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow)) return Button;
        else if (Input.GetKey(KeyCode.DownArrow)) return Button;
        else if (Input.GetKey(KeyCode.LeftArrow)) return Button;
        else if (Input.GetKey(KeyCode.RightArrow)) return Button;

        else return null;
    }

    private void Awake()
    {
        Button = ScriptableObject.CreateInstance<Animation>();
        //ButtonUp = ScriptableObject.CreateInstance<AnimationMovingUp>();
        //ButtonDown = ScriptableObject.CreateInstance<AnimationMovingDown>();
        //ButtonLeft = ScriptableObject.CreateInstance<AnimationMovingLeft>();
        //ButtonRight = ScriptableObject.CreateInstance<AnimationMovingRight>();
    }
}

class Animation : Command
{
    private Vector2 previousDirection = Vector2.zero;

    public override void Execute(Animator animator, GameObject gameObject, Vector2 direction, float animationSpeed)
    {
        if (isWall(gameObject, direction))
        {
            Debug.Log("We move because of arrows!");
            animator.SetFloat(name: "X", value: direction.x);
            animator.SetFloat(name: "Y", value: direction.y);
            animator.speed = animationSpeed;
        }
        else if (isWall(gameObject, previousDirection))
        {
            Debug.Log("We continue movement in the right way!");
            animator.SetFloat(name: "X", value: previousDirection.x);
            animator.SetFloat(name: "Y", value: previousDirection.y);
            animator.speed = animationSpeed;
        }
        else
        {
            Debug.Log("We stuck in the wall!");
            animator.speed = 0f;
        }


    }

    private bool isWall(GameObject gameObject, Vector2 direction)
    {
        Vector2 pos = gameObject.transform.position;

        RaycastHit2D hit = Physics2D.Linecast(pos + direction * 1.15f, pos);
        return !(hit.collider.CompareTag("obstacle"));
    }
}

//class AnimationMovingUp : Command
//{
//    public override void Execute(Animator animator, GameObject gameObject, Vector2 direction)
//    {
//        // animation for moving up
//        animator.SetFloat(name: "X", value: 0f);
//        animator.SetFloat(name: "Y", value: 1f);
//        animator.speed = 0.9f;
//    }
//}

//class AnimationMovingDown : Command
//{
//    public override void Execute(Animator animator, GameObject gameObject, Vector2 direction)
//    {
//        // animation for moving down
//        animator.SetFloat(name: "X", value: 0f);
//        animator.SetFloat(name: "Y", value: -1f);
//        animator.speed = 0.9f;
//    }
//}

//class AnimationMovingLeft : Command
//{
//    public override void Execute(Animator animator, GameObject gameObject, Vector2 direction)
//    {
//        // animation for moving left
//        animator.SetFloat(name: "Y", value: 0f);
//        animator.SetFloat(name: "X", value: -1f);
//        animator.speed = 0.9f;
//    }
//}

//class AnimationMovingRight : Command
//{
//    public override void Execute(Animator animator, GameObject gameObject, Vector2 direction)
//    {
//        // animation for moving right
//        animator.SetFloat(name: "Y", value: 0f);
//        animator.SetFloat(name: "X", value: 1f);
//        animator.speed = 0.9f;
//    }
//}