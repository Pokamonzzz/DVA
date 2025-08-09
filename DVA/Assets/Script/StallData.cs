using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StallData", menuName = "Munch/Stall Data")]
public class StallData : ScriptableObject
{
    public string stallName;
    [TextArea] public string description;
    public Sprite logo;
    public List<RecommendedFood> recommendedFoods;
}

[System.Serializable]
public class RecommendedFood
{
    public string name;
    public Sprite icon;
    [TextArea] public string shortDescription;
}
