using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeManager : MonoBehaviour
{
    public ResourceType resourceType;
    public int amountPerTick;
    public float tickInterval = 1.0f;

    private ResourceManager resourceManager;
    private float timer;

    private void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
        if (resourceManager == null)
        {
            Debug.LogError("Resource manager not found in the scene!");
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= tickInterval)
        {
            GatherResources();
            timer = 0.0f;
        }
    }

    private void GatherResources()
    {
        resourceManager.AddResource(resourceType, amountPerTick);
    }
}
