using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBtn : MonoBehaviour
{
    public ChecklistManager checklistManager;
    private bool alreadyClicked = false;

    public void OnClick()
    {
        if (alreadyClicked) 
            return; // Ignore repeat clicks

        alreadyClicked = true;

        if (checklistManager != null)
            checklistManager.RegisterClick();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
