using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StallLogo : MonoBehaviour
{
    public StallData stallData;        
    public GameObject popupPrefab;     
    private GameObject activePopup;

    private void OnMouseDown()
    {
        OpenPopup();
    }

    public void OpenPopup()
    {
        if (stallData == null || popupPrefab == null)
        {
            Debug.LogWarning("StallData or popupPrefab not set on " + name);
            return;
        }

        if (activePopup != null) Destroy(activePopup);

        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("No Canvas found in scene.");
            return;
        }

        activePopup = Instantiate(popupPrefab, canvas.transform);
        PopupController pc = activePopup.GetComponent<PopupController>();
        if (pc != null)
        {
            pc.Init(stallData, () => {
                if (activePopup != null) Destroy(activePopup);
                activePopup = null;
            });
        }
    }
}