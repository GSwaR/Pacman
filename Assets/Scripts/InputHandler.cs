using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputHandler : MonoBehaviour
{

    //private Command ButtonUp { get; set; }
    //protected Command ButtonDown;
    //protected Command ButtonLeft;
    //private Command ButtonRight;

    public abstract Command HandleInput();
    //public abstract Command HandleInput();

}
