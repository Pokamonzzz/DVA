using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class RecommendedItemUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text nameText;
    public TMP_Text descText;

    public void SetData(RecommendedFood data)
    {
        if (icon && data.icon) icon.sprite = data.icon;
        nameText.text = data.name;
        descText.text = data.shortDescription;
    }
}