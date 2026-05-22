using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Main Panels")]
    [SerializeField] private GameObject mainButtons;

    [Header("Sub Panels")]
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    // CONTROLS
    public void OpenControls()
    {
        if (controlsPanel != null)
            controlsPanel.SetActive(true);

        if (mainButtons != null)
            mainButtons.SetActive(false);
    }

    public void CloseControls()
    {
        if (controlsPanel != null)
            controlsPanel.SetActive(false);

        if (mainButtons != null)
            mainButtons.SetActive(true);
    }

    // SETTINGS
    public void OpenSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(true);

        if (mainButtons != null)
            mainButtons.SetActive(false);
    }

    public void CloseSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        if (mainButtons != null)
            mainButtons.SetActive(true);
    }

    // CREDITS
    public void OpenCredits()
    {
        if (creditsPanel != null)
            creditsPanel.SetActive(true);

        if (mainButtons != null)
            mainButtons.SetActive(false);
    }

    public void CloseCredits()
    {
        if (creditsPanel != null)
            creditsPanel.SetActive(false);

        if (mainButtons != null)
            mainButtons.SetActive(true);
    }
}