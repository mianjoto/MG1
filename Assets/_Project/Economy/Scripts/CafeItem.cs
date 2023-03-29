using UnityEngine;

public class CafeItem : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public uint Price;
    public string Description;

    public uint NumberOfCoffeeBagsRequiredToProduce;
    public uint NumberOfTeaBagsRequiredToProduce;
    public uint NumberOfMilkCartonsRequiredToProduce;
}
