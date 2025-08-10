using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBtn : MonoBehaviour
{
    public ChecklistManager checklistManager;
    private bool alreadyClicked = false;

    public void OnClick()
    {
        Debug.Log($"{name} button clicked!"); // Debug log to confirm click

        if (alreadyClicked)
        {
            Debug.Log($"{name} was already clicked, ignoring.");
            return;
        }

        alreadyClicked = true;

        if (checklistManager != null)
        {
            Debug.Log($"Registering click with {checklistManager.name}");
            checklistManager.RegisterClick();
        }
        else
        {
            Debug.LogError("ChecklistManager is not assigned in TargetButton!");
        }

    }
}
