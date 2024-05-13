using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IceCreamList", menuName = "ScriptableObjects/IceCreamList", order = 1)]
public class IceCream_List_Scriptable : ScriptableObject
{
   [SerializeField] public List<IceCream_Asset> iceCream_List = new();
}

[Serializable]
public class IceCream_Asset{
    public IceCream_Type iceCream_Type;
    public GameObject iceCream_Prefab;
}
