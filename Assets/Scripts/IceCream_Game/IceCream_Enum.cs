using System;
using UnityEngine;

[Serializable]
public enum IceCream_Type{
    NONE,
    RED,
    GREEN,
    BLUE
}

public class IceCream_Enum : MonoBehaviour 
{
    public  IceCream_Type iceCream_Type;
}