using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInputHandler : InputHandler
{

    private Command ButtonUp;
    private Command ButtonDown;
    private Command ButtonLeft;
    private Command ButtonRight;

    public override Command HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow)) return ButtonUp;
        else if (Input.GetKey(KeyCode.DownArrow)) return ButtonDown;
        else if (Input.GetKey(KeyCode.LeftArrow)) return ButtonLeft;
        else if (Input.GetKey(KeyCode.RightArrow)) return ButtonRight;

        else return null;
    }

    private void Awake()
    {
        ButtonUp = ScriptableObject.CreateInstance<AnimationMovingUp>();
        ButtonDown = ScriptableObject.CreateInstance<AnimationMovingDown>();
        ButtonLeft = ScriptableObject.CreateInstance<AnimationMovingLeft>();
        ButtonRight = ScriptableObject.CreateInstance<AnimationMovingRight>();
    }
}

class AnimationMovingUp : Command
{
    public override void Execute(Animator animator)
    {
        // animation for moving up
        animator.SetFloat(name: "X", value: 0f);
        animator.SetFloat(name: "Y", value: 1f);
        animator.speed = 0.9f;
    }
}

class AnimationMovingDown : Command
{
    public override void Execute(Animator animator)
    {
        // animation for moving down
        animator.SetFloat(name: "X", value: 0f);
        animator.SetFloat(name: "Y", value: -1f);
        animator.speed = 0.9f;
    }
}

class AnimationMovingLeft : Command
{
    public override void Execute(Animator animator)
    {
        // animation for moving left
        animator.SetFloat(name: "Y", value: 0f);
        animator.SetFloat(name: "X", value: -1f);
        animator.speed = 0.9f;
    }
}

class AnimationMovingRight : Command
{
    public override void Execute(Animator animator)
    {
        // animation for moving right
        animator.SetFloat(name: "Y", value: 0f);
        animator.SetFloat(name: "X", value: 1f);
        animator.speed = 0.9f;
    }
}