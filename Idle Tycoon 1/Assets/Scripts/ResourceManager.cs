using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private Dictionary<ResourceType, int> resourceStockpile = new Dictionary<ResourceType, int>(); // Запас ресурсов

    // Метод для добавления ресурсов к запасу
    public void AddResource(ResourceType type, int amount)
    {
        if (resourceStockpile.ContainsKey(type))
        {
            resourceStockpile[type] += amount;
        }
        else
        {
            resourceStockpile.Add(type, amount);
        }
    }

    // Метод для проверки наличия необходимых ресурсов
    public bool HasEnoughResources(Dictionary<ResourceType, int> requiredResources)
    {
        foreach (var kvp in requiredResources)
        {
            if (!resourceStockpile.ContainsKey(kvp.Key) || resourceStockpile[kvp.Key] < kvp.Value)
            {
                return false;
            }
        }
        return true;
    }

    // Метод для выдачи ресурсов для строительства
    public bool SpendResources(Dictionary<ResourceType, int> requiredResources)
    {
        if (!HasEnoughResources(requiredResources))
        {
            return false;
        }

        foreach (var kvp in requiredResources)
        {
            resourceStockpile[kvp.Key] -= kvp.Value;
        }

        return true;
    }
}
