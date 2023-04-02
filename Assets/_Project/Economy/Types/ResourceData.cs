using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Resources/Resource", order = 0)]
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
    [SerializeReference]
    public Dictionary<Resource, uint> IngredientsRequired;
}