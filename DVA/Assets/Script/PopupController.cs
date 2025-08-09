using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PopupController : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public Image logoImage;
    public Transform recommendedContainer;   // parent for items
    public GameObject recommendedItemPrefab; // prefab with RecommendedItemUI
    public Button backButton;

    private Action onClose;

    public void Init(StallData data, Action onCloseCallback)
    {
        onClose = onCloseCallback;
        nameText.text = data.stallName;
        descriptionText.text = data.description;
        if (logoImage && data.logo) logoImage.sprite = data.logo;

        // clear old children
        foreach (Transform c in recommendedContainer) Destroy(c.gameObject);

        if (data.recommendedFoods != null)
        {
            foreach (var item in data.recommendedFoods)
            {
                GameObject go = Instantiate(recommendedItemPrefab, recommendedContainer);
                RecommendedItemUI ri = go.GetComponent<RecommendedItemUI>();
                if (ri != null) ri.SetData(item);
            }
        }

        backButton.onClick.RemoveAllListeners();
        backButton.onClick.AddListener(() => { onClose?.Invoke(); });
    }
}
