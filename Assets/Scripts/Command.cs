using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : ScriptableObject
{
    public virtual void Execute(Animator animator) { }
    public virtual void Execute(GameObject gameObject, Vector2 direction, Vector2 pos, float speed) { }

}
