using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    Wood,
    Stone,
    Money
}

[System.Serializable]
public abstract class Resource
{
    public ResourceType Type { get; private set; }
    public int Amount { get; set; }

    public Resource(ResourceType type, int amount)
    {
        Type = type;
        Amount = amount;
    }
}
