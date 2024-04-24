using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour, IStructure
{
    public bool isComplete { get; }
    [field: SerializeField] public BuildingStats buildingStats { get; private set; }
}
