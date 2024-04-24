using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDepartment<T> where T : IStructure
{
    #region params
    // Name of building deparment depends on structures it hold
    public string Name { get; }
    // How many slots reserved for current buildings type
    public int availabeSlots { get; }
    // Buildings that already finished and canproduce resources
    List<T> finishedStructures;
    #endregion

    public BuildingDepartment(string name, int slots)
    {
        Name = name;
        availabeSlots = slots;
        finishedStructures = new List<T>();
    }

    public void AddStructure(T structure)
    {
        if (!finishedStructures.Contains(structure) && finishedStructures.Count < availabeSlots)
            finishedStructures.Add(structure);
    }

    public void RemoveStructure(T structure)
    {
        if (finishedStructures.Contains(structure)) finishedStructures.Remove(structure);
    }


}
