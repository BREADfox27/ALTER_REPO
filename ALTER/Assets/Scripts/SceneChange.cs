using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        SetMusicByScene();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetMusicByScene();
    }

    public void Play()
    {
        SceneManager.LoadScene("SceneXiaowei");
    }

    public void LoadVictoria()
    {
        SceneManager.LoadScene("SceneVictoria");
    }

    public void LoadJavier()
    {
        SceneManager.LoadScene("SceneJavier");
    }

    public void LoadEndMenu()
    {
        SceneManager.LoadScene("EndMenu");
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SceneXiaowei");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Debug.Log("Salir del juego");

        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void SetMusicByScene()
    {
        string scene = SceneManager.GetActiveScene().name;

        if (scene == "MainMenu")
        {
            AudioManager.Instance.ChangeMusic(0);
        }
        else if (
            scene == "SceneXiaowei" ||
            scene == "SceneVictoria" ||
            scene == "SceneJavier"
        )
        {
            AudioManager.Instance.ChangeMusic(1);
        }
        else if (scene == "EndMenu")
        {
            AudioManager.Instance.ChangeMusic(2);
        }
    }
}