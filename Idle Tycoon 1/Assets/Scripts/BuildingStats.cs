using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is class for holding info about building stats and all other propertyes buldings can have.
/// </summary>
[CreateAssetMenu(fileName = "NewBuilding", menuName = "ProductionBuilding")]
public class BuildingStats : ScriptableObject
{
    public string visibleName;
    public ResourceType resourceType;
    //[field: SerializeField]
    public Dictionary<ResourceType, int> constructionCost;
    public float income;
    public float totalBuildingTime;
    public int buildingStages;
    public Sprite image;
}
