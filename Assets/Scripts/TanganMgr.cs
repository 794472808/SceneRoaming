using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TanganMgr : MonoBehaviour
{
    public GameObject target;


    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag($"fCollider")) return;
        Debug.Log("抬杆");
        target.transform.DORotate(new Vector3(0,0,90), 0.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear);
    }
    
}
