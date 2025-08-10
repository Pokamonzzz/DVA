using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChecklistManager : MonoBehaviour
{
    [Header("Checklist Settings")]
    public int totalTargets = 3;      
    private int completedCount = 0;

    [Header("UI References")]
    public TextMeshProUGUI progressText;
    public GameObject finishPanel;    
    public GameObject doneButton;     // New: button shown when all are clicked

    void Start()
    {
        completedCount = 0;
        UpdateUI();

        if (finishPanel != null)
            finishPanel.SetActive(false);

        if (doneButton != null)
            doneButton.SetActive(false);
    }

    public void RegisterClick()
    {
        completedCount++;
        UpdateUI();

        if (completedCount >= totalTargets)
            ShowDoneButton();
    }

    private void UpdateUI()
    {
        if (progressText != null)
            progressText.text = completedCount + "/" + totalTargets;
    }

    private void ShowDoneButton()
    {
        if (doneButton != null)
            doneButton.SetActive(true);
    }

    public void ShowFinishPanel()
    {
        if (finishPanel != null)
            finishPanel.SetActive(true);

        if (doneButton != null)
            doneButton.SetActive(false);
    }

    public void GoToOutMunch()
    {
        SceneManager.LoadScene("OutMunch");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
