using System;
using UnityEngine;

[System.Serializable]
public class FactoryResource
{
    [SerializeField]
    public Resource Resource;
    [SerializeField]
    public TimeToProduce TimeToProduce;

    public FactoryResource(Resource resource, TimeToProduce timeToProduce)
    {
        Resource = resource;
        TimeToProduce = timeToProduce;
    }

    #region Overrides
    public override bool Equals(object obj)
    {
        return this.Resource == ((Resource)obj) && this.TimeToProduce == ((TimeToProduce)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Resource, TimeToProduce);
    }

    public override string ToString()
    {
        return "Factory Resource: " + Resource + " Time to Produce: " + TimeToProduce;
    }
    #endregion
}