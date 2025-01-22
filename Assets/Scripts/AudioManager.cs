using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Música")]
    public AudioClip backgroundMusic;
    private AudioSource musicSource;

    [Header("Configuración")]
    [Range(0, 1)] public float musicVolume = 0.5f;
    public bool musicLoop = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persistir entre escenas
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Configurar fuente de música
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = backgroundMusic;
        musicSource.volume = musicVolume;
        musicSource.loop = musicLoop;
        musicSource.playOnAwake = true;

        PlayMusic();
    }

    public void PlayMusic()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void StopMusic(float fadeDuration = 1f)
    {
        //StartCoroutine(FadeOutMusic(fadeDuration));
        musicSource.Stop();
    }

    //private System.Collections.IEnumerator FadeOutMusic(float duration)
    //{
    //    float startVolume = musicSource.volume;

    //    while (musicSource.volume > 0)
    //    {
    //        musicSource.volume -= startVolume * Time.deltaTime / duration;
    //        yield return null;
    //    }

    //    musicSource.Stop();
    //    musicSource.volume = startVolume; // Restaurar volumen original
    //}

    //public void ChangeMusic(AudioClip newClip, float fadeDuration = 2f)
    //{
    //    StartCoroutine(CrossfadeMusic(newClip, fadeDuration));
    //}

    //private System.Collections.IEnumerator CrossfadeMusic(AudioClip newClip, float duration)
    //{
    //    // Fade out música actual
    //    yield return StartCoroutine(FadeOutMusic(duration));

    //    // Cambiar clip y fade in
    //    musicSource.clip = newClip;
    //    musicSource.Play();

    //    float startVolume = 0;
    //    float targetVolume = musicVolume;

    //    while (musicSource.volume < targetVolume)
    //    {
    //        musicSource.volume += targetVolume * Time.deltaTime / duration;
    //        yield return null;
    //    }
    //}

    //public void SetMusicVolume(float volume)
    //{
    //    musicSource.volume = Mathf.Clamp(volume, 0f, 1f);
    //    PlayerPrefs.SetFloat("MusicVolume", volume);
    //}

    //void OnApplicationPause(bool pauseStatus)
    //{
    //    if (pauseStatus)
    //    {
    //        musicSource.Pause();
    //    }
    //    else
    //    {
    //        musicSource.UnPause();
    //    }
    //}
}