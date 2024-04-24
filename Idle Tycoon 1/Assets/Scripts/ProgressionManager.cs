using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : MonoBehaviour
{
    public static ProgressionManager Instance;

    private Dictionary<string, bool> achievements = new Dictionary<string, bool>();

    public event Action<string> OnAchievementUnlocked;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UnlockAchievement(string achievementName)
    {
        if (!achievements.ContainsKey(achievementName))
        {
            achievements.Add(achievementName, true);
            Debug.Log("Achievement unlocked: " + achievementName);
            OnAchievementUnlocked?.Invoke(achievementName);
        }
    }

    public bool IsAchievementUnlocked(string achievementName)
    {
        return achievements.ContainsKey(achievementName) && achievements[achievementName];
    }
}
