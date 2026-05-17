using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Clip Arrays")]
    public AudioClip[] musicList;
    public AudioClip[] sfxList;

    [Header("Audio Source References")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private int musicToPlay;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(musicToPlay);
    }

    public void PlayMusic(int musicIndex)
    {
        if (musicIndex >= 0 && musicIndex < musicList.Length)
        {
            musicSource.clip = musicList[musicIndex];
            musicSource.Play();
        }
    }

    public void PlaySFX(int sfxIndex)
    {
        if (sfxIndex >= 0 && sfxIndex < sfxList.Length)
        {
            sfxSource.PlayOneShot(sfxList[sfxIndex]);
        }
    }
}
