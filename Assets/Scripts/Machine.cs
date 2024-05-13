using System.Collections;
using System.Collections.Generic;
using BezierSolution;
using BezierSolution.Extras;
using DG.Tweening;
using UnityEngine;

public class Machine : BezierWalkerWithSpeed
{
    [SerializeField] private IceCream_List_Scriptable iceCream_List_Scriptable;
    [SerializeField] private Transform iceCreamCone;
    [SerializeField] private Transform creamFilter;
    [SerializeField] [Range(1,10)] private float durationOfFallingPiece;
    private bool machineIsRunning ;
    private bool iceCreamFinished;
    private float initialHeight;
    private GameObject iceCreamPrefab;
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
        if(iceCreamPrefab != null && machineIsRunning && !iceCreamFinished)
        {
            iceCreamGO = Instantiate(iceCreamPrefab, creamFilter.position, transform.rotation);

            iceCreamGO.transform.DOMove((spline.GetPoint(NormalizedT)), durationOfFallingPiece);

            iceCreamGO.transform.SetParent(iceCreamCone);
            
        }
    }


    public void OnPathComplete(){
        iceCreamFinished = true;
        iceCreamPrefab = null;
        machineIsRunning = false;
    }

    public void OnMachineStart(IceCream_Enum type)
    {
        IceCream_Asset asset = iceCream_List_Scriptable.iceCream_List.Find(item => item.iceCream_Type == type.iceCream_Type);
        iceCreamPrefab = asset.iceCream_Prefab;  
        machineIsRunning = true;
    }

    public void OnMachineStop(){
        iceCreamPrefab = null;
        machineIsRunning = false;
    }

    public void Quit() => Application.Quit();
}
