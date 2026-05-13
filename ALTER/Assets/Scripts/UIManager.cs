using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public static event Action<bool> PauseStateChanged;

    public static bool IsGamePaused => Instance != null && Instance.IsPaused;

    [Header("Paneles")]
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelUI;
    [SerializeField] private GameObject settingsPanel;

    public bool IsPaused =>
        (panelPause != null && panelPause.activeSelf) ||
        (settingsPanel != null && settingsPanel.activeSelf);

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Se detectó un UIManager duplicado. Se destruirá la instancia más nueva.", this);
            Destroy(gameObject);
            return;
        }

        Instance = this;
        ValidateEventSystem();
    }

    private void Start()
    {
        ApplyPauseState(IsPaused);
    }

    private void Update()
    {
        if (!CanTogglePause())
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void OnDestroy()
    {
        if (Instance != this)
            return;

        Instance = null;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PauseStateChanged?.Invoke(false);
    }

    public void OpenPause()
    {
        ApplyPauseState(true);
    }

    public void ClosePause()
    {
        ApplyPauseState(false);
    }

    private void TogglePause()
    {
        ApplyPauseState(!IsPaused);
    }

    private void ApplyPauseState(bool paused)
    {
        bool previousState = IsPaused;

        // Panel de pausa
        if (panelPause != null)
            panelPause.SetActive(paused);

        // Cerrar settings al salir de pausa
        if (settingsPanel != null && !paused)
            settingsPanel.SetActive(false);

        // Panel de UI principal
        if (panelUI != null)
            panelUI.SetActive(!paused);

        // Pausar o continuar tiempo
        Time.timeScale = paused ? 0f : 1f;

        // Manejo del cursor
        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = paused;

        // Notificar cambio de estado
        bool currentState = IsPaused;
        if (currentState != previousState)
            PauseStateChanged?.Invoke(currentState);
    }

    private bool CanTogglePause()
    {
        return panelPause != null;
    }

    private void ValidateEventSystem()
    {
        if (EventSystem.current == null)
            Debug.LogWarning("No se encontró un EventSystem activo en la escena. Añade uno manualmente.", this);
    }
}