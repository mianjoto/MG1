using System;
using System.Collections;
using UnityEngine;

public class CafeEconomy : MonoBehaviour
{
    Coroutine _cafeSellingCoroutine;
    void OnEnable()
    {
        if (_cafeSellingCoroutine != null)
            StopCoroutine(_cafeSellingCoroutine);
        
        _cafeSellingCoroutine = StartCoroutine(Sell());
    }

    IEnumerator Sell()
    {
        while (CafeHasStockAvailable)
        {
            yield return new WaitForSeconds(GameManager.Instance.GetSellingCooldown());
            // Sell
        }
    }


    void OnDisable()
    {
        StopCoroutine(_cafeSellingCoroutine);
    }
}
