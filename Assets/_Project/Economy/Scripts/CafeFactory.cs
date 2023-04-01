using System.Collections.Generic;
using UnityEngine;

public class CafeFactory : BaseFactory, IFactory
{
    void Awake()
    {
        InitializeFactoryProducts();        
    }

    public void InitializeFactoryProducts()
    {
        foreach (ResourceData productData in ProductDatas)
        {
            Resource product = new Resource(productData);
            InitializeFactoryResource(product);
        }
    }
}
