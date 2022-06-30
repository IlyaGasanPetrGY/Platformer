using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform 
{
    public enum StatusMovement
    {
        STAY,
        TOP,
        BOTTOM,
        LEFT,
        RIGHT
    }
    public abstract void MovementPlatform(ref StatusMovement se);
    
}
