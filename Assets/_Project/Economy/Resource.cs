using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resource
{
    [field:SerializeField]
    public uint Amount { get; private set; }
    [SerializeField]
    string _name;
    private ResourceData _resourceData;

    #region Constructors
    public Resource(ResourceData resourceData)
    {
        _resourceData = resourceData;
        _name = resourceData.Name;
        Amount = 0;
    }

    public Resource(ResourceData resourceData, uint initialAmount)
    {
        _resourceData = resourceData;
        _name = resourceData.Name;
        Amount = initialAmount;
    }
    #endregion

    #region Amount Accessors and Mutators
    public void AddAmount(uint amount)
    {
        Amount += amount;
    }

    public void RemoveAmount(uint amount)
    {
        if (Amount - amount < 0)
            Amount = 0;
        else
            Amount -= amount;
    }

    public void SetAmount(uint amount)
    {
        Amount = amount;
    }
    #endregion

    #region Resource Getters
    public TimeToProduce GetBaseTimeToProduce()
    {
        return _resourceData.BaseTimeToProduce;
    }

    public FactoryResource ToFactoryResource()
    {
        return new FactoryResource(this, GetBaseTimeToProduce());
    }

    public Dictionary<Resource, uint> GetIngredientsRequired()
    {
        return _resourceData.IngredientsRequired;
    }
    #endregion

    #region Overrides
    public override bool Equals(object obj)
    {
        return this.Amount == ((Resource)obj).Amount;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Amount, _resourceData);
    }

    public override string ToString()
    {
        return _resourceData.Name + ": " + Amount + " units";
    }
    #endregion
}
