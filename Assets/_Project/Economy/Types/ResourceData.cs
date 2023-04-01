using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceData : ScriptableObject
{
    [Header("Resource Data")]
    public string Name;
    public string Description;
    public Sprite Sprite;

    [Header("Production Data")]
    [SerializeField]
    public TimeToProduce BaseTimeToProduce;
    [Tooltip("The types and number of ingredients required to produce this resource")]
    public Dictionary<Resource, uint> IngredientsRequired;
}