using System.Collections;
using System.Collections.Generic;
using BezierSolution;
using BezierSolution.Extras;
using DG.Tweening;
using UnityEngine;

public class Machine : BezierWalkerWithSpeed
{
    [SerializeField] private IceCream_List_Scriptable iceCream_List_Scriptable;
    [SerializeField] private Transform @base;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] [Range(1,10)] private float duration;
    private bool machineIsRunning ;
    private bool iceCreamFinished;
    private float initialHeight;
    private GameObject iceCream_Prefab;
    private GameObject iceCreamGO;

    void Start()
    {
        initialHeight = transform.position.y;
    }

    protected override void Update()
    {
        transform.position = new Vector3(transform.position.x, initialHeight, transform.position.z);

        if (machineIsRunning && !iceCreamFinished)
        {
            base.Update();          
            transform.position = new Vector3(transform.position.x, initialHeight, transform.position.z);
        }
        else
        {
            return;
        }
    }

    private void FixedUpdate()
    {
        if(iceCream_Prefab != null && machineIsRunning && !iceCreamFinished)
        {
            iceCreamGO = Instantiate(iceCream_Prefab, spawnPoint.position, transform.rotation);

            iceCreamGO.transform.DOMove((spline.GetPoint(NormalizedT)), duration);

            iceCreamGO.transform.SetParent(@base);
            
        }
    }

    public void OnPathComplete(){
        iceCreamFinished = true;
        iceCream_Prefab = null;
        machineIsRunning = false;
    }

    public void OnMachineStart(IceCream_Enum type)
    {
        IceCream_Asset asset = iceCream_List_Scriptable.iceCream_List.Find(item => item.iceCream_Type == type.iceCream_Type);
        iceCream_Prefab = asset.iceCream_Prefab;  
        machineIsRunning = true;
    }

    public void OnMachineStop(){
        iceCream_Prefab = null;
        machineIsRunning = false;
    }

    public void Quit() => Application.Quit();
}
