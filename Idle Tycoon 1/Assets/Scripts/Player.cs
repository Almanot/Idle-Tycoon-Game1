using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] TMP_Text UImoneyValue;
    [SerializeField] TMP_Text UIwoodValue;
    [SerializeField] TMP_Text UIstoneValue;

    public int money { get; private set; }
    public int wood { get; private set; }
    public int stone { get; private set; }

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void UpdateResource(ResourceType resource, int value)
    {
        switch(resource)
        {
            case ResourceType.Money:
                if (value < 0 && value > money) return; // for subraction
                money += value;
                UImoneyValue.text = money.ToString();
                break;
            case ResourceType.Wood:
                if (value < 0 && value > wood) return;
                wood += value;
                UIwoodValue.text = money.ToString();
                break;
            case ResourceType.Stone:
                if (value < 0 && value > stone) return;
                stone += value;
                UIstoneValue.text = money.ToString();
                break;
        }
    }
}
