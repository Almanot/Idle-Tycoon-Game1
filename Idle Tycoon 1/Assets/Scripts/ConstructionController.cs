using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script should be on the parent of building object and control the single structure
/// </summary>
public class ConstructionController : MonoBehaviour
{
    [SerializeField] BuildingStats buildingStats;
    [SerializeField] GameObject buildingAnimation;
    bool BuildingComplete = false;
    float[] buildingStages;

    public void BeginConstruction()
    {
        if (!buildingStats)
        {
            Debug.LogWarning("Unable to begin building. Building stats is null");
            return;
        }
        if (!BuildingComplete)
        {
            // launch the dust in the eyes.
            if (buildingAnimation) buildingAnimation.gameObject.SetActive(true);
            StartCoroutine(ConstructionProcess(buildingStats.totalBuildingTime, buildingStats.buildingStages));
        }
    }

    IEnumerator ConstructionProcess(float timeLeft, int unfinishedBuildingStages)
    {
        // Do a building process extended over time.
        // prevent divide by zero
        if (unfinishedBuildingStages < 1) unfinishedBuildingStages = 1;
        buildingStages = new float[unfinishedBuildingStages];
        for (int i = unfinishedBuildingStages; i > 0; i--)
        {
            float t = timeLeft / i;
            yield return new WaitForSecondsRealtime(t);
            foreach (Transform building in transform)
            {
                building.gameObject.SetActive(true);
            }
        }
        buildingAnimation.gameObject.SetActive(false);
    }
}
