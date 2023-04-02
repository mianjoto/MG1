using System;
using System.Collections.Generic;
using UnityEngine;

public class CafeFactory : BaseFactory, IFactory
{
    Coroutine _produceCoroutine;

    void Awake()
    {
        InitializeFactoryProducts();        
    }

    public void InitializeFactoryProducts()
    {
        foreach (ResourceData productData in ProductDatas)
        {
            Resource product = new Resource(productData);
            InitializeProduct(product);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ProduceOneCoffee();
        }
    }

    void ProduceOneCoffee()
    {
        Resource coffee = GetProductFromName("Instant \"Coffee\"");
        _produceCoroutine = StartCoroutine(ProduceResource(coffee, 1));
    }
}
