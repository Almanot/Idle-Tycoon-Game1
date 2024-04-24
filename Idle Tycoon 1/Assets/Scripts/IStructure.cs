using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStructure
{
    public bool isComplete { get; }
    public BuildingStats buildingStats { get; }
}
