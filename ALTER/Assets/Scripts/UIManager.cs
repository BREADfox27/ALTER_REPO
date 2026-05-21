using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public static event Action<bool> PauseStateChanged;

    [Header("Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject settingsPanel;

    public bool IsPaused => pausePanel != null && pausePanel.activeSelf;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        ApplyPause(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        ApplyPause(!IsPaused);
    }

    public void OpenPause()
    {
        ApplyPause(true);
    }

    public void ClosePause()
    {
        ApplyPause(false);
    }

    public void OpenSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
        }
    }

    public void CloseSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }

    private void ApplyPause(bool paused)
    {
        // Panel pausa
        if (pausePanel != null)
        {
            pausePanel.SetActive(paused);
        }

        // UI gameplay
        if (gameplayUI != null)
        {
            gameplayUI.SetActive(!paused);
        }

        // Si se cierra pausa, cerrar settings también
        if (!paused && settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }

        // Pausar juego
        Time.timeScale = paused ? 0f : 1f;

        // Cursor
        Cursor.lockState = paused
            ? CursorLockMode.None
            : CursorLockMode.Locked;

        Cursor.visible = paused;

        // Evento
        PauseStateChanged?.Invoke(paused);
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}