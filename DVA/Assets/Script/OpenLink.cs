using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    [Tooltip("The URL to open when this button is clicked")]
    public string url = "https://example.com";

    public void OpenURL()
    {
        if (!string.IsNullOrEmpty(url))
        {
            Application.OpenURL(url);
        }
        else
        {
            Debug.LogWarning("URL is empty. Please assign a link in the inspector.");
        }
    }
}
