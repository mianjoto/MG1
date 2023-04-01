using System;
using System.Collections;
using UnityEngine;

public class CafeEconomy : MonoBehaviour
{
    [SerializeField] CafeFactory _cafeFactory;

    Coroutine _cafeSellingCoroutine;
    void OnEnable()
    {
        if (_cafeSellingCoroutine != null)
            StopCoroutine(_cafeSellingCoroutine);
        
        // _cafeSellingCoroutine = StartCoroutine(Sell());
    }



    void OnDisable()
    {
        StopCoroutine(_cafeSellingCoroutine);
    }
}
