using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The manager of zones available for construction
// And all buildings that already constructed
// And info about building that can be builded
public class StructuresManager : MonoBehaviour
{
    [SerializeField] List<BuildingDepartment<IStructure>> Departments = new List<BuildingDepartment<IStructure>>();

    public bool CreateDepartment<T>(string departmentName, int slots) where T : IStructure
    {
        BuildingDepartment<T> newDepartment = new BuildingDepartment<T>(departmentName, slots);
        Departments.Add(newDepartment as BuildingDepartment<IStructure>);
        return true;
    }

    public void AddBuilding(string departmentName, IStructure structure)
    {
        // Searching for department by name.
        var department = Departments.Find(d => d.Name == departmentName);
        if (department != null)
        {
            department.AddStructure(structure);
        }
    }

    public void RemoveBuilding(string departmentName, IStructure structure)
    {
        var department = Departments.Find(d => d.Name == departmentName);
        if (department != null)
        {
            department.RemoveStructure(structure);
        }
    }
}
