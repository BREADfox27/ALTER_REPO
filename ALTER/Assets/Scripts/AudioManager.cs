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
    [SerializeField] private AudioSource footstepsSource;

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
            return;
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
            // Evita reiniciar la misma música
            if (musicSource.clip == musicList[musicIndex] && musicSource.isPlaying)
                return;

            musicSource.clip = musicList[musicIndex];
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void ChangeMusic(int index)
    {
        PlayMusic(index);
    }

    public void PlaySFX(int sfxIndex)
    {
        if (sfxIndex >= 0 && sfxIndex < sfxList.Length)
        {
            sfxSource.PlayOneShot(sfxList[sfxIndex]);
        }
    }

    public void PlayUI()
    {
        PlaySFX(3);
    }

    // FOOTSTEPS
    public void PlayFootsteps(int index)
    {
        if (index >= 0 && index < sfxList.Length)
        {
            if (!footstepsSource.isPlaying)
            {
                footstepsSource.clip = sfxList[index];
                footstepsSource.loop = true;
                footstepsSource.Play();
            }
        }
    }

    public void StopFootsteps()
    {
        if (footstepsSource.isPlaying)
        {
            footstepsSource.Stop();
        }
    }
}